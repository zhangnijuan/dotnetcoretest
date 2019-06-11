using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;

using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCoreTestDemo.Mis.Filter
{
    public class HttpGlobalExceptionFilter:IExceptionFilter
    {
        private ILog log = LogManager.GetLogger(Startup.Repository.Name, typeof(HttpGlobalExceptionFilter));
        public void OnException(ExceptionContext context)
        {
          
            log.Error("<br/><strong>客户机IP</strong>：" + context.HttpContext.Connection.RemoteIpAddress.ToString() + "<br /><strong>错误地址</strong>：" + context.HttpContext.Request.Path, context.Exception);
        }
    }
}
