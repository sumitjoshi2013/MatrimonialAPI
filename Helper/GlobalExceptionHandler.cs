using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace WebApplication1.Utility
{
    public class GlobalExceptionHandler : System.Web.Http.ExceptionHandling.ExceptionHandler
    {
        ILog _logger = null;
        public GlobalExceptionHandler()
        {
            // Gets directory path of the calling application  
            // RelativeSearchPath is null if the executing assembly i.e. calling assembly is a  
            // stand alone exe file (Console, WinForm, etc).   
            // RelativeSearchPath is not null if the calling assembly is a web hosted application i.e. a web site  
            var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

            //var log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, "log4net.config");  
            var log4NetConfigFilePath = "c:\\users\\user\\documents\\visual studio 2012\\Projects\\ErrorLogingDummy\\ErrorLogingDummy\\ExLogger\\log4net.config";
            log4net.Config.XmlConfigurator.ConfigureAndWatch(null,new FileInfo(log4NetConfigFilePath));
        }

        public override void Handle(ExceptionHandlerContext context)
        {
          
            var exception = context.Exception;

            var httpException = exception as HttpException;
            if (httpException != null)
            {
                _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                context.Result = new CustomErrorResult(context.Request, (HttpStatusCode)httpException.GetHttpCode(), httpException.Message);
                _logger.Error("context.Request ==> " + context.Request + "InternalServerError ==> " + HttpStatusCode.InternalServerError.ToString() + "Exception Message ==> " + exception.Message + Environment.NewLine);
                return;
            }

            // Return HttpStatusCode for other types of exception.

            context.Result = new CustomErrorResult(context.Request,HttpStatusCode.InternalServerError, exception.Message);
        }
    }

}