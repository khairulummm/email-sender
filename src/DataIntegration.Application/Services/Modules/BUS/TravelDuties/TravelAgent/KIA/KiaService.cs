using DataIntegration.Application.Extensions;
using DataIntegration.Application.Helper;
using DataIntegration.Application.Interfaces.Entities.TBIGSADB01.TBGSecureAccess;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties.TravelAgent.KIA;
using DataIntegration.Application.Models;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Domain.Enums.BUS.TravelDuties;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA;
using DataIntegration.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Reflection;

namespace DataIntegration.Application.Services.Modules.BUS.TravelDuties.TravelAgent.KIA
{
    public class KiaService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider, IOptions<Dictionary<string, string>> appSettings, ILogger<KiaService> logger)
        : IKiaService
    {
        private readonly Dictionary<string, string> _appSettings = appSettings.Value;
        public async Task<vmAccessToken> GetToken(string logPath, string userID)
        {
            try
            {
                var _dtNow = DateTime.Now;
                var env = _appSettings["kia-environment"];

                var epCode = Convert.ToString(KiaEndpointCode.GetAccessToken);

                var crdService = serviceProvider.GetRequiredService<ImstCredentialKiaService>();
                var _aCredential = await crdService.GetListAsync(filter: x => x.Environment == env);
                var _credential = _aCredential.FirstOrDefault();

                var reService = serviceProvider.GetRequiredService<IvwRootEndpointKiaService>();
                var _aRootEndpoint = await reService.GetListAsync(filter: x => x.Environment == env && x.EndpointCode == epCode);
                var _rootEndpoint = _aRootEndpoint.FirstOrDefault();

                Method method = (Method)Enum.Parse(typeof(Method), _rootEndpoint.Method, ignoreCase: true);
                RestRequest getRequest = new RestRequest();

                var dict = new Dictionary<string, string>();
                dict.Add("Cache-Control", "no-cache");
                dict.Add("Content-Type", "application/x-www-form-urlencoded");

                var grantType = Infrastructure.CryptoHelper.Decrypt(_credential?.Grant_type);
                var clientID = Infrastructure.CryptoHelper.Decrypt(_credential?.Client_id);
                var clientSecret = Infrastructure.CryptoHelper.Decrypt(_credential?.Client_secret);
                var clientScope = Infrastructure.CryptoHelper.Decrypt(_credential?.Scope);

                var stringParam = string.Format("grant_type={0}&client_id={1}&client_secret={2}&scope={3}", grantType, clientID, clientSecret, clientScope);
                var createParam = Parameter.CreateParameter("application/x-www-form-urlencoded", stringParam, ParameterType.QueryString);

                var parameter = new List<Parameter>();
                parameter.Add(createParam);

                RestSharpHelper helper = new RestSharpHelper(_rootEndpoint.Root);
                var result = await helper.PostAsync<object, vmAccessToken>(_rootEndpoint.Endpoint, customHeaders: dict, body: null, parameters: parameter);
                var data = result.Data;

                if (data != null)
                    data.ExpiredDate = _dtNow.AddSeconds(Convert.ToInt32(data.expires_in));

                var log = new trxAPIKiaHistory()
                {
                    Token = "",
                    SentDate = _dtNow,
                    Url = _rootEndpoint.URL,
                    Request = stringParam,
                    Response = JsonConvert.SerializeObject(data),
                    StatusID = (int)TravelokaAPIStatus.Success,
                    APIStatusCode = (int)HttpStatusCode.OK,
                    CreatedDate = _dtNow,
                    CreatedBy = userID
                };

                var logParam = new dtPostApiLog<trxAPIKiaHistory>()
                {
                    BookingCoreID = 0,
                    EndpointCode = _rootEndpoint.EndpointCode,
                    LogPath = logPath,
                    Log = log,
                };
                await pSaveLogHistory(logParam);

                pAddLogger("ENV :{env}", env);
                pAddLogger("Root :{root}", _rootEndpoint.Root);
                pAddLogger("Endpoint : {endpoint})", _rootEndpoint.Endpoint);
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<vmResponseHotelConfirmation> HotelConfirmation(IUnitOfWork uow, dtPostApi<vmRequestHotelConfirmation> param)
        {
            try
            {
                var submit = await pSubmitApiKia<vmRequestHotelConfirmation, vmResponseHotelConfirmation>(
                    KiaEndpointCode.HotelConfirmation,
                    param);

                return submit;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmResponseHotelConfirmation((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID));
            }
        }

        public async Task<vmResponseHotelIssued> HotelIssued(IUnitOfWork uow, dtPostApi<vmRequestHotelIssued> param)
        {
            try
            {
                var submit = await pSubmitApiKia<vmRequestHotelIssued, vmResponseHotelIssued>(
                    KiaEndpointCode.HotelIssued,
                    param);

                return submit;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmResponseHotelIssued((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID));
            }
        }

        public async Task<vmResponseGetHotelReservation> GetHotelReservation(IUnitOfWork uow, dtPostApi<string> param)
        {
            try
            {
                var paramID = Parameter.CreateParameter("id", param.Model, ParameterType.QueryString);
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(paramID);

                var submit = await pSubmitApiKia<string, vmResponseGetHotelReservation>(
                    KiaEndpointCode.GetHotelReservation,
                    param,
                    parameters: parameters);

                return submit;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmResponseGetHotelReservation((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID));
            }
        }

        public async Task<vmResponseFlightReservation> FlightReservation(IUnitOfWork uow, dtPostApi<vmRequestFlightReservation> param)
        {
            try
            {
                var submit = await pSubmitApiKia<vmRequestFlightReservation, vmResponseFlightReservation>(
                    KiaEndpointCode.FlightReservation,
                    param);

                return submit;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmResponseFlightReservation((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID));
            }
        }

        public async Task<vmResponseFlightIssued> FlightIssued(IUnitOfWork uow, dtPostApi<vmRequestFlightIssued> param)
        {
            try
            {
                var submit = await pSubmitApiKia<vmRequestFlightIssued, vmResponseFlightIssued>(
                    KiaEndpointCode.FlightIssued,
                    param);

                return submit;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmResponseFlightIssued((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID));
            }
        }

        public async Task<vmResponseGetFlightReservation> GetFlightReservation(IUnitOfWork uow, dtPostApi<string> param)
        {
            try
            {
                var paramID = Parameter.CreateParameter("id", param.Model, ParameterType.QueryString);
                List<Parameter> parameters = new List<Parameter>();
                parameters.Add(paramID);

                var submit = await pSubmitApiKia<string, vmResponseGetFlightReservation>(
                    KiaEndpointCode.GetFlightReservation,
                    param,
                    parameters: parameters);

                return submit;
            }
            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                return new vmResponseGetFlightReservation((int)Helper.Helper.ErrorType.Error, await logger.LogException(serviceProvider, ex, param.SchedullerID));
            }
        }

        #region private
        private async Task<TResponse?> pSubmitApiKia<TRequest, TResponse>(
                                    KiaEndpointCode epCode,
                                    dtPostApi<TRequest> data,
                                    List<Parameter>? parameters = null)
        {
            try
            {
                var getToken = await GetToken(data.LogPath, data.UserID);
                var token = getToken.access_token;

                var _dtNow = DateTime.Now;
                var endPointCode = Convert.ToString(epCode);
                var env = _appSettings["kia-environment"];

                var crdService = serviceProvider.GetRequiredService<ImstCredentialKiaService>();
                var _aCredential = await crdService.GetListAsync(filter: x => x.Environment == env);
                var _credential = _aCredential.FirstOrDefault();

                var reService = serviceProvider.GetRequiredService<IvwRootEndpointKiaService>();
                var _aRootEndpoint = await reService.GetListAsync(filter: x => x.Environment == env && x.EndpointCode == endPointCode);
                var _rootEndpoint = _aRootEndpoint.FirstOrDefault();

                var dict = new Dictionary<string, string>
                {
                    { "Content-Type", "application/json" },
                    { "Host", data.Host },
                    { "Authorization", "Bearer " + token }
                };

                var request = "";
                if (parameters != null)
                {
                    var allParam = new Dictionary<string, string>();
                    //List<string> allValues = new List<string>();
                    for (var i = 0; i < parameters.Count; i++)
                    {
                        allParam.Add(parameters[i].Name, Convert.ToString(parameters[i].Value));
                    }
                    request = JsonConvert.SerializeObject(allParam);
                }
                else
                {
                    request = JsonConvert.SerializeObject(data.Model);
                }

                var log = new trxAPIKiaHistory()
                {
                    Token = token,
                    SentDate = _dtNow,
                    Url = _rootEndpoint.URL,
                    Request = request,
                    //Request = parameters != null ? JsonConvert.SerializeObject(parameters) : JsonConvert.SerializeObject(data.Model),
                    StatusID = (int)KiaAPIStatus.Success,
                    APIStatusCode = (int)HttpStatusCode.OK,
                    CreatedDate = _dtNow,
                    CreatedBy = data.UserID,
                };

                var logParam = new dtPostApiLog<trxAPIKiaHistory>()
                {
                    BookingCoreID = data.BookingCoreID,
                    EndpointCode = _rootEndpoint.EndpointCode,
                    LogPath = data.LogPath,
                    Log = log,
                };

                pAddLogger("ENV :{env}", env);
                pAddLogger("Host :{host}", data.Host);
                pAddLogger("Root :{root}", _rootEndpoint.Root);
                pAddLogger("Endpoint : {endpoint})", _rootEndpoint.Endpoint);
                pAddLogger("Data : {data})", JsonConvert.SerializeObject(data.Model));

                Method method = (Method)Enum.Parse(typeof(Method), _rootEndpoint.Method, ignoreCase: true);
                RestSharpHelper helper = new RestSharpHelper(_rootEndpoint.Root);
                switch (method)
                {
                    case Method.Get:
                        var gResponse = await helper.GetAsync<TResponse>(_rootEndpoint.Endpoint, customHeaders: dict, parameters: parameters);
                        log.Response = gResponse.Content;
                        await pSaveLogHistory(logParam);
                        var gContent = pGetContent(gResponse);
                        return gContent;
                    case Method.Post:
                        var pResponse = await helper.PostAsync<TRequest, TResponse>(_rootEndpoint.Endpoint, customHeaders: dict, parameters: parameters, body: data.Model);
                        log.Response = pResponse.Content;
                        await pSaveLogHistory(logParam);
                        var pContent = pGetContent(pResponse);
                        return pContent;
                    case Method.Put:
                        var ptResponse = await helper.PutAsync<TRequest, TResponse>(_rootEndpoint.Endpoint, customHeaders: dict, body: data.Model);
                        log.Response = ptResponse.Content;
                        await pSaveLogHistory(logParam);
                        var ptContent = pGetContent(ptResponse);
                        return ptContent;
                    case Method.Delete:
                        var dResponse = await helper.DeleteAsync<TResponse>(_rootEndpoint.Endpoint, customHeaders: dict);
                        log.Response = dResponse.Content;
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
                //Jika Gagal Serialize
                throw;
            }
        }

        private async Task<trxAPIKiaHistory> pSaveLogHistory(dtPostApiLog<trxAPIKiaHistory> param)
        {
            try
            {
                pAddLogger("log : {log})", JsonConvert.SerializeObject(param.Log));
                var logService = serviceProvider.GetRequiredService<ItrxAPIKiaHistoryService>();
                await logService.AddAsync(param.Log);
                //pCreateLogFile(param);
                //logger.LogInformation("log : {log})", JsonConvert.SerializeObject(param.Log));
                return param.Log;
            }
            catch (Exception ex)
            {
                //Simpan dalam bentuk text. buatkan job untuk insert ke table. Hapus file
                pCreateLogFile(param);
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

        private void pCreateLogFile(dtPostApiLog<trxAPIKiaHistory> param)
        {
            if (!Directory.Exists(param.LogPath))
            {
                Directory.CreateDirectory(param.LogPath);
            }

            var filePath = string.Format("{0}\\{1:yyyyMMdd_hhmmss}.json", param.LogPath, param.Log.SentDate);
            string isi = JsonConvert.SerializeObject(param, Formatting.Indented);

            int counter = 1;
            while (File.Exists(filePath))
            {
                filePath = string.Format("{0}\\{1:yyyyMMdd_hhmmss}({2}).json", param.LogPath, param.Log.SentDate, counter);
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
