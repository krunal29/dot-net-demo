using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DotNetDemo.Business.Common;
using DotNetDemo.Business.Models.General;

namespace DotNetDemo.Business.Helpers
{
    public static class ApiHelper
    {
        #region Api Request

        public static ResponseDetail SendApiRequest<T>(T data, string url, HttpMethod httpMethod, string apiToken = "")
        {
            return SendApiRequestAsync(data, url, httpMethod, apiToken).Result;
        }

        public static async Task<ResponseDetail> SendApiRequestAsync<T>(T data, string url, HttpMethod httpMethod, string apiToken = "")
        {
            var responseModel = new ResponseDetail();
            try
            {
                var baseUrl = url;
                if (httpMethod == HttpMethod.Get || httpMethod == HttpMethod.Delete)
                {
                    baseUrl = baseUrl + Convert.ToString(data);
                }
                var client = new HttpClient { BaseAddress = new Uri(baseUrl) };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
                client.Timeout = TimeSpan.FromMinutes(Constant.TimeoutLimitInMinutes);

                HttpResponseMessage response;

                if (httpMethod == HttpMethod.Get)
                {
                    response = await client.GetAsync(baseUrl).ConfigureAwait(false);
                }
                else if (httpMethod == HttpMethod.Post)
                {
                    response = await client.PostAsJsonAsync(baseUrl, data).ConfigureAwait(false);
                }
                else if (httpMethod == HttpMethod.Delete)
                {
                    response = await client.DeleteAsync(baseUrl).ConfigureAwait(false);
                }
                else if (httpMethod == HttpMethod.Put)
                {
                    response = await client.PutAsJsonAsync(baseUrl, data).ConfigureAwait(false);
                }
                else
                {
                    throw new NotSupportedException($"Method {httpMethod} is not supported.");
                }
                if (response.IsSuccessStatusCode)
                {
                    await SuccessStatusCodeTrueAsync(response, responseModel);
                }
                else
                {
                    await SuccessStatusCodeFalseAsync(responseModel, response);
                }
            }
            catch (Exception ex)
            {
                responseModel.Success = false;
                responseModel.Message = ex.Message;
                return responseModel;
            }
            return responseModel;
        }

        private static async Task SuccessStatusCodeTrueAsync(HttpResponseMessage response, ResponseDetail responseModel)
        {
            var content = response.Content;
            var result = await content.ReadAsStringAsync().ConfigureAwait(false);
            responseModel.Success = true;
            dynamic returnObj = JObject.Parse(result);
            if (returnObj != null)
            {
                if (returnObj["result"] != null)
                {
                    responseModel.Data = returnObj["result"];
                }
                if (returnObj["success"] != null)
                {
                    responseModel.Success = returnObj["success"];
                }
                if (returnObj["MessageType"] != null)
                {
                    responseModel.MessageType = returnObj["MessageType"];
                }
                responseModel.Message = returnObj["Message"] != null ? returnObj["Message"].ToString() : string.Empty;
            }
        }
        private static async Task SuccessStatusCodeFalseAsync(ResponseDetail responseModel, HttpResponseMessage response)
        {
            responseModel.Success = false;
            var content = response.Content;
            var result = await content.ReadAsStringAsync().ConfigureAwait(false);
            if (!string.IsNullOrEmpty(result))
            {
                dynamic returnObj = JObject.Parse(result);
                responseModel.Message = returnObj != null && returnObj["Message"] != null
                    ? returnObj["Message"].ToString()
                    : response.ReasonPhrase;
                if (returnObj != null && returnObj["MessageType"] != null)
                {
                    responseModel.MessageType = returnObj["MessageType"].ToString();
                }
            }
            else
            {
                responseModel.Message = response.ReasonPhrase;
            }
        }
        #endregion
    }
}