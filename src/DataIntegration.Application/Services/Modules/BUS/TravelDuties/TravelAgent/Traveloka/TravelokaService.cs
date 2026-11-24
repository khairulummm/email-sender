using DataIntegration.Application.Extensions;
using DataIntegration.Application.Helper;
using DataIntegration.Application.Interfaces.Entities.TBIGSADB01.TBGSecureAccess;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties.TravelAgent.Traveloka;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Domain.Enums.BUS.TravelDuties;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka;
using DataIntegration.Infrastructure;
using DataIntegration.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Services.Modules.BUS.TravelDuties.TravelAgent.Traveloka
{
    public class TravelokaService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider, IOptions<Dictionary<string, string>> appSettings, ILogger<TravelokaService> logger)
        : ITravelokaService
    {
        private readonly Dictionary<string, string> _appSettings = appSettings.Value;
        public async Task<vmAccessToken> GetToken(TravelokaCredentialName credName, string logPath, string userID)
        {
            try
            {
                var _dtNow = DateTime.Now;
                var cName = Convert.ToString(credName);
                var rCode = Convert.ToString(TravelokaRootCode.OAuth_API);
                var eCode = Convert.ToString(TravelokaEndpointCode.GetAccessToken);
                var env = _appSettings["traveloka-environment"];


                var crdService = serviceProvider.GetRequiredService<ImstCredentialTravelokaService>();
                var _aCredential = await crdService.GetListAsync(filter: x => x.Environment == env && x.CredentialName == cName);
                var _credential = _aCredential.FirstOrDefault();

                var rtService = serviceProvider.GetRequiredService<ImstRootTravelokaService>();
                var _aRoot = await rtService.GetListAsync(filter: x => x.Environment == env && x.Code == rCode);
                var _root = _aRoot.FirstOrDefault();

                var epService = serviceProvider.GetRequiredService<ImstEndpointTravelokaService>();
                var _aEndpoint = await epService.GetListAsync(filter: x => x.Environment == env && x.Code == eCode);
                var _endpoint = _aEndpoint.FirstOrDefault();

                var dict = new Dictionary<string, string>();
                dict.Add("Accept", "application/json");
                dict.Add("Content-Type", "application/x-www-form-urlencoded");

                var clientID = Parameter.CreateParameter("client_id", CryptoHelper.Decrypt(_credential.ClientID), ParameterType.QueryString);
                var clientSecret = Parameter.CreateParameter("client_secret", CryptoHelper.Decrypt(_credential.ClientSecret), ParameterType.QueryString);
                var parameter = new List<Parameter>();
                parameter.Add(clientID);
                parameter.Add(clientSecret);

                pAddLogger("ENV :{env}", env);
                pAddLogger("Root :{root}", _root.Root);
                pAddLogger("Endpoint : {endpoint})", _endpoint.Endpoint);

                RestSharpHelper helper = new RestSharpHelper(_root.Root);
                var Response = await helper.PostAsync<object, vmAccessToken>(_endpoint.Endpoint, customHeaders: dict, body: null, parameters: parameter);
                var data = Response.Data;

                if (data != null)
                    data.ExpiredDate = _dtNow.AddSeconds(Convert.ToInt32(data.expires_in));

                var request = new Dictionary<string, string>();
                request.Add("client_id", CryptoHelper.Decrypt(_credential.ClientID));
                request.Add("client_secret", CryptoHelper.Decrypt(_credential.ClientSecret));

                var log = new trxAPITravelokaHistory()
                {
                    Token = "",
                    SentDate = _dtNow,
                    Endpoint = _root.Root + _endpoint.Endpoint,
                    Request = JsonConvert.SerializeObject(request),
                    Response = JsonConvert.SerializeObject(data),
                    StatusID = (int)TravelokaAPIStatus.Success,
                    APIStatusCode = (int)HttpStatusCode.OK,
                    CreatedDate = _dtNow,
                    CreatedBy = userID
                };
                var logParam = new dtPostApiLog<trxAPITravelokaHistory>()
                {
                    BookingCoreID = 0,
                    EndpointCode = _endpoint.Code,
                    LogPath = logPath,
                    Log = log,
                };
                await pSaveLogHistory(logParam);

                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<vmAccomAffiliateBookingAPIResponse> CreateBooking(IUnitOfWork uow, dtPostApi<vmAccomAffiliateBookingAPISpec> param)
        {
            try
            {
                var dtPost = new dtPostSubmitApiTraveloka()
                {
                    CredentialName = TravelokaCredentialName.corp_tower_bersama_accom,
                    RootName = TravelokaRootCode.Accom_Booking_API,
                    EndpointName = TravelokaEndpointCode.CreateBooking,
                };
                param.Method = Method.Post;
                var Response = await pSubmitApiTraveloka<vmAccomAffiliateBookingAPISpec, vmAccomAffiliateBookingAPIResponse>(
                    dtPost,
                    param);
                Response.APIStatusCode = (int)HttpStatusCode.OK;
                return Response;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmAccomAffiliateBookingAPIResponse((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID), 0);
            }
        }

        public async Task<vmAccomAffiliateViewItinerariesResult> ViewItinerary(IUnitOfWork uow, dtPostApi<vmAccomAffiliateViewItinerariesSpec> param)
        {
            try
            {

                var dtPost = new dtPostSubmitApiTraveloka()
                {
                    CredentialName = TravelokaCredentialName.corp_tower_bersama_accom,
                    RootName = TravelokaRootCode.Accom_Booking_API,
                    EndpointName = TravelokaEndpointCode.ViewItinerary,
                };
                param.Method = Method.Post;
                var Response = await pSubmitApiTraveloka<vmAccomAffiliateViewItinerariesSpec, vmAccomAffiliateViewItinerariesResult>(
                    dtPost,
                    param);
                Response.APIStatusCode = (int)HttpStatusCode.OK;

                return Response;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmAccomAffiliateViewItinerariesResult((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID), 0);
            }
        }

        public async Task<vmFlightBookingRS> FlightBooking(IUnitOfWork uow, dtPostApi<vmFlightBookingRQ> param)
        {
            try
            {
                var dtPost = new dtPostSubmitApiTraveloka()
                {
                    CredentialName = TravelokaCredentialName.corp_tower_bersama_flight,
                    RootName = TravelokaRootCode.Flight_API,
                    EndpointName = TravelokaEndpointCode.FlightBooking,
                };
                param.Method = Method.Post;
                var Response = await pSubmitApiTraveloka<vmFlightBookingRQ, vmFlightBookingRS>(
                    dtPost,
                    param);

                Response.APIStatusCode = (int)HttpStatusCode.OK;
                return Response;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmFlightBookingRS((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID), 0);
            }
        }

        public async Task<vmFlightBookingStatusRS> FlightBookingStatus(IUnitOfWork uow, dtPostApi<vmFlightBookingStatusRQ> param)
        {
            try
            {
                var dtPost = new dtPostSubmitApiTraveloka()
                {
                    CredentialName = TravelokaCredentialName.corp_tower_bersama_flight,
                    RootName = TravelokaRootCode.Flight_API,
                    EndpointName = TravelokaEndpointCode.FlightBookingStatus,
                };
                param.Method = Method.Post;
                var Response = await pSubmitApiTraveloka<vmFlightBookingStatusRQ, vmFlightBookingStatusRS>(
                    dtPost,
                    param);

                Response.APIStatusCode = (int)HttpStatusCode.OK;
                return Response;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmFlightBookingStatusRS((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID), 0);
            }
        }

        public async Task<vmPaymentConfirmationRS> FlightConfirm(IUnitOfWork uow, dtPostApi<vmPaymentConfirmationRQ> param)
        {
            try
            {
                var dtPost = new dtPostSubmitApiTraveloka()
                {
                    CredentialName = TravelokaCredentialName.corp_tower_bersama_flight,
                    RootName = TravelokaRootCode.Flight_API,
                    EndpointName = TravelokaEndpointCode.FlightConfirm,
                };
                param.Method = Method.Post;
                var Response = await pSubmitApiTraveloka<vmPaymentConfirmationRQ, vmPaymentConfirmationRS>(
                    dtPost,
                    param);

                Response.APIStatusCode = (int)HttpStatusCode.OK;
                return Response;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmPaymentConfirmationRS((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID), 0);
            }
        }

        #region private
        private async Task<TResponse?> pSubmitApiTraveloka<TRequest, TResponse>(
                                        dtPostSubmitApiTraveloka post,
                                        dtPostApi<TRequest> data,
                                        List<Parameter>? parameters = null)
        {
            try
            {
                var getToken = await GetToken(post.CredentialName, data.LogPath, data.UserID);
                var token = getToken.access_token;

                var _dtNow = DateTime.Now;
                var cName = Convert.ToString(post.CredentialName);
                var rCode = Convert.ToString(post.RootName);
                var eCode = Convert.ToString(post.EndpointName);
                var env = _appSettings["traveloka-environment"];

                var crdService = serviceProvider.GetRequiredService<ImstCredentialTravelokaService>();
                var _aCredential = await crdService.GetListAsync(filter: x => x.Environment == env && x.CredentialName == cName);
                var _credential = _aCredential.FirstOrDefault();

                var rtService = serviceProvider.GetRequiredService<ImstRootTravelokaService>();
                var _aRoot = await rtService.GetListAsync(filter: x => x.Environment == env && x.Code == rCode);
                var _root = _aRoot.FirstOrDefault();

                var epService = serviceProvider.GetRequiredService<ImstEndpointTravelokaService>();
                var _aEndpoint = await epService.GetListAsync(filter: x => x.Environment == env && x.Code == eCode);
                var _endpoint = _aEndpoint.FirstOrDefault();

                var dict = new Dictionary<string, string>();
                //dict.Add("Content-Type", "application/json");
                dict.Add("Authorization", token);


                var log = new trxAPITravelokaHistory()
                {
                    Token = token,
                    SentDate = _dtNow,
                    Endpoint = _root.Root + _endpoint.Endpoint,
                    Request = parameters != null ? JsonConvert.SerializeObject(parameters) : JsonConvert.SerializeObject(data.Model),
                    StatusID = (int)TravelokaAPIStatus.Success,
                    APIStatusCode = (int)HttpStatusCode.OK,
                    CreatedDate = _dtNow,
                    CreatedBy = data.UserID
                };

                var logParam = new dtPostApiLog<trxAPITravelokaHistory>()
                {
                    BookingCoreID = data.BookingCoreID,
                    EndpointCode = _endpoint.Code,
                    LogPath = data.LogPath,
                    Log = log,
                };

                pAddLogger("ENV :{env}", env);
                pAddLogger("Root :{root}", _root.Root);
                pAddLogger("Endpoint : {endpoint})", _endpoint.Endpoint);
                pAddLogger("Data : {data})", JsonConvert.SerializeObject(data.Model));

                RestSharpHelper helper = new RestSharpHelper(_root.Root);
                switch (data.Method)
                {
                    case Method.Get:
                        var gResponse = await helper.GetAsync<TResponse>(_endpoint.Endpoint, customHeaders: dict, parameters: parameters);
                        log.Response = JsonConvert.SerializeObject(gResponse.Content);
                        await pSaveLogHistory(logParam);
                        var gContent = pGetContent(gResponse);
                        return gContent;
                    case Method.Post:
                        var pResponse = await helper.PostAsync<TRequest, TResponse>(_endpoint.Endpoint, customHeaders: dict, parameters: parameters, body: data.Model);
                        log.Response = JsonConvert.SerializeObject(pResponse.Content);
                        await pSaveLogHistory(logParam);
                        var pContent = pGetContent(pResponse);
                        return pContent;
                    case Method.Put:
                        var ptResponse = await helper.PutAsync<TRequest, TResponse>(_endpoint.Endpoint, customHeaders: dict, body: data.Model);
                        log.Response = JsonConvert.SerializeObject(ptResponse.Content);
                        await pSaveLogHistory(logParam);
                        var ptContent = pGetContent(ptResponse);
                        return ptContent;
                    case Method.Delete:
                        var dResponse = await helper.DeleteAsync<TResponse>(_endpoint.Endpoint, customHeaders: dict);
                        log.Response = JsonConvert.SerializeObject(dResponse.Content);
                        await pSaveLogHistory(logParam);
                        var dContent = pGetContent(dResponse);
                        return dContent;
                    default:
                        throw new Exception("Method not supported");
                }
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<trxAPITravelokaHistory> pSaveLogHistory(dtPostApiLog<trxAPITravelokaHistory> logParam)
        {
            try
            {
                pAddLogger("log : {log})", JsonConvert.SerializeObject(logParam.Log));
                var logService = serviceProvider.GetRequiredService<ItrxAPITravelokaHistoryService>();
                await logService.AddAsync(logParam.Log);
                //pCreateLogFile(logParam);
                //logger.LogInformation("log : {log})", JsonConvert.SerializeObject(logParam.Log));
                return logParam.Log;
            }
            catch (Exception ex)
            {
                pCreateLogFile(logParam);
                throw;
            }
        }

        private TResponse pGetContent<TResponse>(RestResponse<TResponse> response)
        {
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
                    var result = Convert.ToString(content);
                    var data = JsonConvert.DeserializeObject<TResponse>(result);
                    return data;
                }
                catch (Exception)
                {
                    throw new ApiException(response.StatusCode, response.Content);
                }
            }
            else
            {
                throw new ApiException(response.StatusCode, response.Content);
            }
        }

        private void pCreateLogFile(dtPostApiLog<trxAPITravelokaHistory> logParam)
        {
            if (!Directory.Exists(logParam.LogPath))
            {
                Directory.CreateDirectory(logParam.LogPath);
            }

            var filePath = string.Format("{0}\\{1:yyyyMMdd_hhmmss}.json", logParam.LogPath, logParam.Log.SentDate);
            string isi = JsonConvert.SerializeObject(logParam, Formatting.Indented);

            int counter = 1;
            while (File.Exists(filePath))
            {
                filePath = string.Format("{0}\\{1:yyyyMMdd_hhmmss}({2}).json", logParam.LogPath, logParam.Log.SentDate, counter);
                counter++;
            }

            File.WriteAllText(filePath, isi);
        }

        private void pAddLogger(string LogName, object LogData)
        {
            logger.LogInformation(LogName, LogData);
            Console.WriteLine(string.Format("[{0}] {1}", LogName, LogData));
        }
        #endregion private
    }
}
