using DataIntegration.Application.Extensions;
using DataIntegration.Application.Helper;
using DataIntegration.Application.Interfaces.Modules.Workflow;
using DataIntegration.Application.Models;
using DataIntegration.Domain.Enums.Workflow;
using DataIntegration.Domain.Models.ViewModels.Workflow;
using DataIntegration.Domain.Models.ViewModels.Workflow.parameter;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace DataIntegration.Application.Services.Modules.General
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<WorkflowService> _logger;
        private readonly WorkflowSettings _wfSettings;

        public WorkflowService(IServiceProvider serviceProvider, ILogger<WorkflowService> logger, IOptions<WorkflowSettings> wfOptions)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _wfSettings = wfOptions.Value;
        }

        public async Task<vmWorkflowApiResponse<vmWorkflowAssignmentProcess>> GetAssignmentProcessAsync(string moduleTransactionID)
        {
            try
            {
                var param = new Dictionary<string, string>
                {
                    ["transactionModuleID"] = moduleTransactionID
                };

                var result = await pSubmitAsync<vmWorkflowAssignmentProcess>(
                    jsonBody: "", 
                    parameters: param, 
                    httpMethod: Method.Get, 
                    endpoint: TBGWorkflowEndpoint.AssignmentProcess
                ).ConfigureAwait(false);

                return result;
            }
            catch (ApiException exc)
            {
                await _logger.LogException(_serviceProvider, exc);
                return new vmWorkflowApiResponse<vmWorkflowAssignmentProcess>((int)exc.StatusCode, exc.JsonError)
                {
                    IsError = true
                };
            }
            catch (Exception ex)
            {
                await _logger.LogException(_serviceProvider, ex);
                return new vmWorkflowApiResponse<vmWorkflowAssignmentProcess>
                {
                    IsError = true,
                    StatusCode = 500,
                    Message = ex.Message,
                    Errors = new List<string> { ex.ToString() }
                };
            }
        }

        public async Task<vmWorkflowApiResponse<vmWorkflow>> SubmitApprovalAsync<T>(vmWorkflowData<T> data, string userID = null)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };

                string jsonData = JsonConvert.SerializeObject(
                    data,
                    Newtonsoft.Json.Formatting.None,
                    settings
                );

                IDictionary<string, string> headers = new Dictionary<string, string>
                {
                    { "custom-header1", "value1" },
                    { "custom-header2", "value2" }
                };

                var workflow = new vmWorkflow
                {
                    MessageId = Guid.NewGuid().ToString(),
                    AppId = "my-application",
                    ContentType = "application/json",
                    ContentEncoding = "utf-8",
                    Headers = headers,
                    DeliveryMode = 2,
                    Priority = 5,
                    CorrelationId = Guid.NewGuid().ToString(),
                    Timestamp = DateTime.UtcNow.ToString("o"),
                    Type = "my.message.type",
                    UserId = "DataIntegration",
                    Body = new vmWorkflowBody
                    {
                        data = jsonData
                    },
                    DeliveryTag = 12345678,
                    ConsumerTag = "consumer-abc-01",
                    Redelivered = false,
                    Exchange = "my-exchange",
                    RoutingKey = "my.routing.key",
                    WorkerCode = "worker-001"
                };

                string json = JsonConvert.SerializeObject(workflow);

                string endpoint = TBGWorkflowEndpoint.SubmitApproval;
                var result = await pSubmitAsync<vmWorkflow>(
                    jsonBody: json,
                    httpMethod: Method.Post,
                    endpoint: endpoint
                ).ConfigureAwait(false);

                return result;
            }
            catch (ApiException exc)
            {
                await _logger.LogException(_serviceProvider, exc);
                return new vmWorkflowApiResponse<vmWorkflow>((int)exc.StatusCode, exc.JsonError)
                {
                    IsError = true
                };
            }
            catch (Exception ex)
            {
                await _logger.LogException(_serviceProvider, ex);
                return new vmWorkflowApiResponse<vmWorkflow>
                {
                    IsError = true,
                    StatusCode = 500,
                    Message = ex.Message,
                    Errors = new List<string> { ex.ToString() }
                };
            }
        }

        #region Private
        private async Task<vmWorkflowApiResponse<T>> pSubmitAsync<T>(string jsonBody, Dictionary<string, string> parameters, Method httpMethod, string endpoint)
        {
            var resultVm = new vmWorkflowApiResponse<T>();
            string host = _wfSettings.url;

            try
            {
                using var httpClient = new HttpClient
                {
                    Timeout = TimeSpan.FromMinutes(120)
                };

                var client = new RestClient(
                    httpClient,
                    new RestClientOptions(host)
                );

                var request = new RestRequest(endpoint, httpMethod).AddHeader("Content-Type", "application/json");

                // Query parameters
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        request.AddQueryParameter(item.Key, item.Value);
                    }
                }

                // JSON body
                if (!string.IsNullOrWhiteSpace(jsonBody))
                {
                    request.AddStringBody(jsonBody, DataFormat.Json);
                }

                RestResponse response = await client.ExecuteAsync(request).ConfigureAwait(false);

                resultVm.StatusCode = (int)response.StatusCode;
                resultVm.Message = response.StatusDescription;

                if (!response.IsSuccessful)
                {
                    resultVm.IsError = true;
                    resultVm.Message = response.Content ?? response.ErrorMessage;
                    resultVm.Errors = new List<string> { response.ErrorMessage };

                    throw new Exception($"API call failed: {resultVm.Message}");
                }

                // SUCCESS
                resultVm.IsError = false;
                resultVm.Data = JsonConvert.DeserializeObject<T>(response.Content);

                return resultVm;
            }
            catch (Exception ex)
            {
                resultVm.IsError = true;
                resultVm.StatusCode = 500;
                resultVm.Message = ex.Message;
                resultVm.Errors = new List<string> { ex.ToString() };

                await _logger.LogException(_serviceProvider, ex);

                return resultVm;
            }
        }

        private async Task<vmWorkflowApiResponse<T>> pSubmitAsync<T>(string jsonBody, Method httpMethod, string endpoint)
        {
            var responseVm = new vmWorkflowApiResponse<T>();
            var host = _wfSettings.url;

            try
            {
                using var httpClient = new HttpClient
                {
                    Timeout = TimeSpan.FromMinutes(120)
                };

                var client = new RestClient(httpClient, new RestClientOptions(host));

                var request = new RestRequest(endpoint, httpMethod).AddHeader("Content-Type", "application/json");

                if (!string.IsNullOrWhiteSpace(jsonBody))
                {
                    request.AddStringBody(jsonBody, DataFormat.Json);
                }

                RestResponse response = await client.ExecuteAsync(request).ConfigureAwait(false);

                responseVm.StatusCode = (int)response.StatusCode;
                responseVm.Message = response.StatusDescription;

                if (!response.IsSuccessful)
                {
                    responseVm.IsError = true;
                    responseVm.Message = response.Content ?? response.ErrorMessage;
                    responseVm.Errors = new List<string> { response.ErrorMessage };

                    throw new Exception($"API call failed: {responseVm.Message}");
                }

                // Success
                responseVm.IsError = false;
                responseVm.Data = JsonConvert.DeserializeObject<T>(response.Content);

                return responseVm;
            }
            catch (Exception ex)
            {
                responseVm.IsError = true;
                responseVm.StatusCode = 500;
                responseVm.Message = ex.Message;
                responseVm.Errors = new List<string> { ex.ToString() };

                await _logger.LogException(_serviceProvider, ex);

                return responseVm;
            }
        }
        #endregion
    }
}
