using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Domain.Entities.TBGAPPHFIRE141.TBIGDataIntegration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataIntegration.Application.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogJson<T>(this Microsoft.Extensions.Logging.ILogger logger, LogLevel level, string message, T obj)
        {
            string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
            logger.Log(level, "{Message}: {Json}", message, json);
        }

        public static async Task<string> LogException(this Microsoft.Extensions.Logging.ILogger logger, 
                                                IServiceProvider serviceProvider, 
                                                Exception ex,
                                                string SchedullerID = "", 
                                                string userID = "System")
        {
            var err = new
            {
                ex.Message,
                ex.StackTrace,
                ex.Source,
                InnerException = ex.InnerException?.Message
            };

            var trace = new StackTrace(ex, true);
            var frame = trace.GetFrames()?.FirstOrDefault(f =>
                        f.GetMethod()?.DeclaringType?.Name?.Contains("<") == true);

            var declaringType = frame?.GetMethod()?.DeclaringType;
            string? fullTypeName = declaringType?.FullName;
            string? rawMethodName = frame?.GetMethod()?.Name;

            string? parsedMethodName = declaringType?.Name;

            if (!string.IsNullOrEmpty(parsedMethodName) && parsedMethodName.Contains("<") && parsedMethodName.Contains(">"))
            {
                int start = parsedMethodName.IndexOf('<') + 1;
                int end = parsedMethodName.IndexOf('>');
                parsedMethodName = parsedMethodName.Substring(start, end - start);
            }

            string? serviceFullName = declaringType?.FullName;

            string? serviceName = null;

            if (!string.IsNullOrEmpty(serviceFullName))
            {
                var parts = serviceFullName.Split('+');
                if (parts.Length > 0)
                {
                    var fullClassName = parts[0];
                    var prefix = "DataIntegration.Application.Services.";
                    if (fullClassName.StartsWith(prefix))
                    {
                        serviceName = fullClassName.Substring(prefix.Length);
                    }
                    else
                    {
                        serviceName = fullClassName;
                    }
                }
            }

            var logData = new logError
            {
                SchedullerID = SchedullerID,
                Message = ex.Message,
                InnerException = ex.InnerException?.Message.ToString(),
                Project = ex.Source,
                Service = serviceName,
                Method = parsedMethodName,
                StackTrace = ex.StackTrace?.ToString(),
                CreatedBy = userID,
                CreatedDate = DateTime.Now,
            };

            string errorMessage = "";
            var logErrorService = serviceProvider.GetRequiredService<ILogService>();
            if (logErrorService != null)
            {
                try
                {
                    await logErrorService.SaveLogError(logData);
                    errorMessage = "Error on System (Error Log: " + logData.ID + "). Please Call IT Help Desk!";
                    logger.LogWarning(errorMessage);
                }
                catch (Exception logEx)
                {
                    errorMessage = "Failed to log error to database";
                    logger.LogError(logEx, errorMessage);
                }
            }
            return errorMessage;

        }
    }
}
