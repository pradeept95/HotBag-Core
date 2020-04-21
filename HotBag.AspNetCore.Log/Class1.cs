using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.AspNetCore.Log
{
    class Class1
    {
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public partial class LogErrorAttribute : Attribute, IExceptionFilter
    {
        private ILogger _logger;
        public LogErrorAttribute()
        {

        }
        public void OnException(ExceptionContext filterContext)
        {
            _logger = filterContext.HttpContext.RequestServices.GetService<ILogger>();
            _logger.Log(LogType.Error, () => filterContext.Exception.Message.ToString(), filterContext.Exception);

        }
    }
}

