using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DotNetDemo.API;
using Swagger.Net.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace DotNetDemo.API.App_Start
{
    public static class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
            .EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "DotNetDemo.API");
                c.AccessControlAllowOrigin("*");                
                c.IgnoreIsSpecifiedMembers();
                c.DescribeAllEnumsAsStrings();
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            })
            .EnableSwaggerUi(c =>
            {
                c.ShowExtensions(true);
                c.UImaxDisplayedTags(100);
                c.SetValidatorUrl("https://online.swagger.io/validator");
                c.UIfilter("''");
                c.DocumentTitle("DotNetDemo");
                c.DefaultModelsExpandDepth(-1);
            });
        }
    }
}