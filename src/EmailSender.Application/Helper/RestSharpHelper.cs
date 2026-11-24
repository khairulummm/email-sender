using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text.Json; // Or Newtonsoft.Json if you prefer

namespace DataIntegration.Application.Helper
{
    public class RestSharpHelper
    {
        private readonly RestClient _client;
        private readonly JsonSerializerOptions? _jsonSerializerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestSharpHelper"/> class with a base URL.
        /// All requests will have no-cache headers and an infinite timeout.
        /// </summary>
        /// <param name="baseUrl">The base URL for the API.</param>
        /// <param name="jsonSerializerOptions">Optional JSON serializer options for System.Text.Json.</param>
        public RestSharpHelper(string baseUrl, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentException("Base URL cannot be null or empty.", nameof(baseUrl));
            }

            var options = new RestClientOptions(baseUrl)
            {
                // Set infinite timeout
                MaxTimeout = Timeout.Infinite, // -1 milliseconds
                // Anda juga bisa menggunakan:
                // MaxTimeout = -1,
            };

            _client = new RestClient(options);
            _jsonSerializerOptions = jsonSerializerOptions ?? new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Anda juga bisa mengkonfigurasi _client untuk menggunakan System.Text.Json secara eksplisit jika perlu
            // _client.UseSystemTextJson(_jsonSerializerOptions); // Hanya jika Anda tidak mau bergantung pada default RestSharp
        }

        private void PrepareRequest(RestRequest request, Dictionary<string, string>? customHeaders)
        {
            // Add No-Cache Headers
            request.AddHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            request.AddHeader("Pragma", "no-cache"); // HTTP/1.0 backward compatibility
            request.AddHeader("Expires", "0"); // Proxies

            // Add custom headers
            if (customHeaders != null)
            {
                foreach (var header in customHeaders)
                {
                    // Hindari penambahan ulang header Cache-Control, Pragma, Expires jika sudah ada di customHeaders
                    // dengan key yang sama (meskipun case-insensitive check lebih baik di sini)
                    if (!string.Equals(header.Key, "Cache-Control", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(header.Key, "Pragma", StringComparison.OrdinalIgnoreCase) &&
                        !string.Equals(header.Key, "Expires", StringComparison.OrdinalIgnoreCase))
                    {
                        request.AddHeader(header.Key, header.Value);
                    }
                }
            }
        }

        private void AddParameters(RestRequest request, List<Parameter>? parameters)
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.Name == "application/x-www-form-urlencoded")
                    {
                        request.AddParameter(parameter.Name, parameter.Value, ParameterType.RequestBody);
                    }
                    else
                    {
                        request.AddParameter(parameter);
                    }
                }
            }
        }

        /// <summary>
        /// Executes a GET request asynchronously with no-cache headers and infinite timeout.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the response content to.</typeparam>
        /// <param name="resource">The resource URI.</param>
        /// <param name="customHeaders">Optional dictionary of custom headers to add to the request.</param>
        /// <param name="parameters">Optional list of parameters to add to the request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>A RestResponse object containing the deserialized data or error information.</returns>
        public async Task<RestResponse<T?>> GetAsync<T>(
            string resource,
            Dictionary<string, string>? customHeaders = null,
            List<Parameter>? parameters = null,
            CancellationToken cancellationToken = default)
        {
            var request = new RestRequest(resource, Method.Get);
            PrepareRequest(request, customHeaders);
            AddParameters(request, parameters);

            try
            {
                // RestSharp 112+ uses System.Text.Json by default and respects JsonSerializerOptions passed to RestClient
                var response = await _client.ExecuteAsync<T>(request, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                return new RestResponse<T?>(request)
                {
                    Content = null,
                    ErrorException = ex,
                    ErrorMessage = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError, // Or infer from exception if possible
                    IsSuccessStatusCode = false,
                    ResponseStatus = ResponseStatus.Error
                };
            }
        }

        /// <summary>
        /// Executes a POST request asynchronously with no-cache headers and infinite timeout.
        /// </summary>
        public async Task<RestResponse<TResponse?>> PostAsync<TRequest, TResponse>(
            string resource,
            TRequest body,
            Dictionary<string, string>? customHeaders = null,
            List<Parameter>? parameters = null,
            CancellationToken cancellationToken = default)
        {
            var request = new RestRequest(resource, Method.Post);
            PrepareRequest(request, customHeaders);
            AddParameters(request, parameters);

            if (body != null)
            {
                var jsonBody = JsonConvert.SerializeObject(body);
                request.AddBody(jsonBody, ContentType.Json);
            }

            try
            {
                var response = await _client.ExecuteAsync<TResponse>(request, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                return new RestResponse<TResponse?>(request)
                {
                    Content = null,
                    ErrorException = ex,
                    ErrorMessage = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccessStatusCode = false,
                    ResponseStatus = ResponseStatus.Error
                };
            }
        }

        /// <summary>
        /// Executes a PUT request asynchronously with no-cache headers and infinite timeout.
        /// </summary>
        public async Task<RestResponse<TResponse?>> PutAsync<TRequest, TResponse>(
            string resource,
            TRequest body,
            Dictionary<string, string>? customHeaders = null,
            CancellationToken cancellationToken = default)
        {
            var request = new RestRequest(resource, Method.Put);
            PrepareRequest(request, customHeaders);
            var jsonBody = JsonConvert.SerializeObject(body); // or
            request.AddBody(jsonBody, ContentType.Json);

            try
            {
                var response = await _client.ExecuteAsync<TResponse>(request, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                return new RestResponse<TResponse?>(request)
                {
                    Content = null,
                    ErrorException = ex,
                    ErrorMessage = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccessStatusCode = false,
                    ResponseStatus = ResponseStatus.Error
                };
            }
        }

        /// <summary>
        /// Executes a DELETE request asynchronously with no-cache headers and infinite timeout.
        /// </summary>
        public async Task<RestResponse<T?>> DeleteAsync<T>(
            string resource,
            Dictionary<string, string>? customHeaders = null,
            CancellationToken cancellationToken = default)
        {
            var request = new RestRequest(resource, Method.Delete);
            PrepareRequest(request, customHeaders);

            try
            {
                var response = await _client.ExecuteAsync<T>(request, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                return new RestResponse<T?>(request)
                {
                    Content = null,
                    ErrorException = ex,
                    ErrorMessage = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccessStatusCode = false,
                    ResponseStatus = ResponseStatus.Error
                };
            }
        }

        /// <summary>
        /// Executes a raw RestRequest asynchronously.
        /// No-cache headers will be added if not already present with those specific keys.
        /// The timeout will be governed by the RestClient's MaxTimeout.
        /// </summary>
        public async Task<RestResponse<T?>> ExecuteAsync<T>(RestRequest request, Dictionary<string, string>? additionalCustomHeaders = null, CancellationToken cancellationToken = default)
        {
            // Add no-cache headers and any additional custom headers not already on the request object.
            // This assumes request might come pre-configured, so we are more careful.
            PrepareRequest(request, additionalCustomHeaders); // This will add no-cache and then custom ones.

            try
            {
                var response = await _client.ExecuteAsync<T>(request, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                return new RestResponse<T?>(request)
                {
                    Content = null,
                    ErrorException = ex,
                    ErrorMessage = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccessStatusCode = false,
                    ResponseStatus = ResponseStatus.Error
                };
            }
        }

        /// <summary>
        /// Executes a raw RestRequest asynchronously without expecting a specific deserialized type.
        /// No-cache headers will be added if not already present with those specific keys.
        /// The timeout will be governed by the RestClient's MaxTimeout.
        /// </summary>
        public async Task<RestResponse> ExecuteAsync(RestRequest request, Dictionary<string, string>? additionalCustomHeaders = null, CancellationToken cancellationToken = default)
        {
            PrepareRequest(request, additionalCustomHeaders);

            try
            {
                var response = await _client.ExecuteAsync(request, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                return new RestResponse
                {
                    Content = null,
                    ErrorException = ex,
                    ErrorMessage = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccessStatusCode = false,
                    ResponseStatus = ResponseStatus.Error
                };
            }
        }
    }
}

