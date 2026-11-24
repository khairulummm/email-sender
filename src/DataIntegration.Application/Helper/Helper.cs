//using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
//using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Domain.Entities.TBGAPPHFIRE141.TBIGDataIntegration;
using DataIntegration.Domain.Models.ViewModels;
using DataIntegration.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DataIntegration.Application.Helper
{
    public static class Helper
    {
        #region Enum
        public enum ErrorType : int
        {
            None = 0,
            Validation = 1,
            Error = 2
        }
        #endregion

        //public static async Task<string> LogErrorAsync(IUnitOfWork uow, 
        //    IServiceProvider serviceProvider, 
        //    Exception exc,
        //    string schedullerID, 
        //    string userID = "DataIntegration",
        //    [CallerMemberName] string methodName = "", 
        //    [CallerFilePath] string filePath = "")
        //{
        //    try
        //    {
        //        var callerInfo = GetCallerInfo(methodName, filePath);
        //        var error = new logError
        //        {
        //            SchedullerID = schedullerID,
        //            Message = exc.Message,
        //            InnerException = exc.InnerException?.Message,
        //            Project = exc.Source,
        //            Service = callerInfo.ServiceName,
        //            Method = callerInfo.MethodName,
        //            StackTrace = exc.StackTrace,
        //            CreatedBy = userID,
        //            CreatedDate = DateTime.Now
        //        };

        //        var service = serviceProvider.GetRequiredService<ILogService>();
        //        await service.SaveLogError(uow, error);

        //        return "Error on System (Error Log: " + error.ID + "). Please Call IT Help Desk!";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static DateTime GetDateTimeNow()
        {
            string strDtNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff");
            return DateTime.Parse(strDtNow);
        }

        public static string GetCurrentMethod()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);

            return stackFrame.GetMethod().Name;
        }

        public static CallerInfo GetCallerInfo([CallerMemberName] string methodName = "", [CallerFilePath] string filePath = "")
        {
            var serviceName = Path.GetFileNameWithoutExtension(filePath);

            // optional: ambil namespace dari path
            var directory = Path.GetDirectoryName(filePath);
            var parts = directory?.Split(Path.DirectorySeparatorChar);
            var index = Array.FindIndex(parts, p => p.Contains("DataIntegration"));
            string namespaceName = "";
            if (index >= 0)
            {
                var selectedParts = parts.Skip(index);
                namespaceName = string.Join(".", selectedParts);
            }


            return new CallerInfo
            {
                Namespace = namespaceName,
                ServiceName = serviceName,
                MethodName = methodName,
            };
        }
    }
}
