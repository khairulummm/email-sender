using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.API.Middleware
{
    public class StandardResponseFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            // Hanya proses ObjectResult (OkObjectResult, BadRequestObjectResult, NotFoundObjectResult, dll)
            // atau Controller yang mengembalikan objek langsung (meskipun kurang umum/disarankan)
            if (context.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                // Jika hasilnya SUDAH ApiResponse, jangan lakukan apa-apa
                if (objectResult.Value is ApiResponse<object> || objectResult.Value.GetType().IsGenericType && objectResult.Value.GetType().GetGenericTypeDefinition() == typeof(ApiResponse<>))
                {
                    // Pastikan StatusCode di ApiResponse sesuai dengan StatusCode hasil Action
                    dynamic existingApiResponse = objectResult.Value;
                    existingApiResponse.StatusCode = objectResult.StatusCode ?? existingApiResponse.StatusCode;
                    context.Result = new ObjectResult(existingApiResponse) { StatusCode = existingApiResponse.StatusCode };
                    return;
                }

                // Jika BUKAN ApiResponse, bungkus!
                int statusCode = objectResult.StatusCode ?? (int)HttpStatusCode.OK; // Ambil status code dari result

                if (statusCode >= 200 && statusCode < 300) // Kode sukses
                {
                    var response = ApiResponse<object>.Success(statusCode, objectResult.Value); // Bungkus data asli
                                                                                                // Set ulang StatusCode karena ApiResponse punya properti sendiri
                    context.Result = new ObjectResult(response) { StatusCode = statusCode };
                }
                else // Kode error (4xx, 5xx)
                {
                    string message = "An error occurred."; // Pesan default
                    List<string>? errors = null;

                    // Coba ekstrak detail error jika ada (misal dari BadRequestObjectResult dengan ValidationProblemDetails)
                    if (objectResult.Value is ValidationProblemDetails validationErrors)
                    {
                        message = validationErrors.Title ?? "Validation Failed";
                        errors = validationErrors.Errors.SelectMany(kvp => kvp.Value).ToList();
                    }
                    else if (objectResult.Value is ProblemDetails problemDetails)
                    {
                        message = problemDetails.Title ?? message;
                        if (problemDetails.Detail != null)
                            errors = new List<string> { problemDetails.Detail };
                    }
                    else if (objectResult.Value is string errorMessage) // Jika hanya string error
                    {
                        message = errorMessage;
                        errors = new List<string> { errorMessage };
                    }
                    else // Error lain, gunakan representasi string jika ada
                    {
                        message = objectResult.Value.ToString() ?? message;
                        errors = new List<string> { message };
                    }


                    var response = ApiResponse<object>.Fail(statusCode, message, errors);
                    // Set ulang StatusCode karena ApiResponse punya properti sendiri
                    context.Result = new ObjectResult(response) { StatusCode = statusCode };
                }
            }
            else if (context.Result is StatusCodeResult statusCodeResult) // Hasil tanpa body (NotFound(), NoContent())
            {
                int statusCode = statusCodeResult.StatusCode;
                if (statusCode >= 200 && statusCode < 300) // Sukses tanpa body (misal: NoContent 204)
                {
                    var response = ApiResponse<object>.Success(statusCode, statusCode == 204 ? "Operation successful, no content to return." : "Success");
                    context.Result = new ObjectResult(response) { StatusCode = statusCode };
                }
                else // Error tanpa body (misal: NotFound())
                {
                    var response = ApiResponse<object>.Fail(statusCode, $"Request failed with status code {statusCode}.");
                    context.Result = new ObjectResult(response) { StatusCode = statusCode };
                }
            }
            // Anda mungkin perlu menangani jenis Result lain jika diperlukan (ViewResult, FileResult, dll tidak relevan untuk API)
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Tidak perlu melakukan apa-apa setelah result dieksekusi
        }
    }
}
