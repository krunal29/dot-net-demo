using System;
using System.Web.Http;
using DotNetDemo.API.Filters;
using DotNetDemo.Business.Models.General;
using DotNetDemo.Business.Helpers;
using Newtonsoft.Json;
using System.Net.Http;

namespace DotNetDemo.API.Controllers
{
    [MethodAttributeExceptionHandling]
    public class BaseApiController : ApiController
    {
        protected ResponseDetail GetDataWithMessage(Func<Tuple<object, string, bool>> getDataFunc)
        {
            var result = getDataFunc();
            return new ResponseDetail
            {
                Data = result.Item1,
                Message = result.Item2,
                Success = result.Item3
            };
        }

        protected T DoActionForGet<T>(string data, string url)
        {
            var response = ApiHelper.SendApiRequest(data, url, HttpMethod.Get);
            if (response?.Data != null)
            {
                return JsonConvert.DeserializeObject<T>(response.Data.ToString());
            }
            return default(T);
        }
    }
}
