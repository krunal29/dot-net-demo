using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using NLog;
using DotNetDemo.Business.Models.General;

namespace DotNetDemo.API.Filters
{
    public class MethodAttributeExceptionHandling : ExceptionFilterAttribute
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public override void OnException(HttpActionExecutedContext context)
        {
            Logger.Error($"An error has occured. Action: {context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName}, {context.ActionContext.ActionDescriptor.ActionName}. {context.Exception}");

            var errorMessagError = new ResponseDetail
            {
                Message = "Oops some internal Exception. ",
                Success = false
            };

            context.Response =
                context.Request.CreateResponse
                    (HttpStatusCode.InternalServerError, errorMessagError);

        }
    }
}