using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ARK.CORE.ApiClient
{
    public enum RequestType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class OldApiCall
    {

        //public static string GetToken(string UserName, string Password)
        //{
        //    var pairs = new List<KeyValuePair<string, string>>
        //    {
        //        new KeyValuePair<string, string>("grant_type", "Password"),
        //        new KeyValuePair<string, string>("username", UserName),
        //        new KeyValuePair<string, string>("Password", Password)
        //    };
        //    var content = new FormUrlEncodedContent(pairs);
        //    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        //    using (var client = new HttpClient())
        //    {
        //        client.Timeout = TimeSpan.FromMinutes(15);
        //        var response = client.PostAsync(WebConfigurationManager.AppSettings["ApiRoot"] + "Token", content).Result;
        //        return response.Content.ReadAsStringAsync().Result;
        //    }
        //}

        //private static string OldCallApi(string route, string jsonRequestModel, int requestType)
        //{
        //    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionContext.Current.ActiveUser.TokenObj.Token);
        //        client.DefaultRequestHeaders.Add("Accept-Language", "en-US");
        //        var stringContent = new StringContent(jsonRequestModel, Encoding.UTF8, "application/json");
        //        client.Timeout = TimeSpan.FromMinutes(15);
        //        HttpResponseMessage response = new HttpResponseMessage();
        //        switch (requestType)
        //        {
        //            case (int)RequestType.GET:
        //                response = client.GetAsync(WebConfigurationManager.AppSettings["ApiRoot"] + route).Result;
        //                break;
        //            case (int)RequestType.POST:
        //                response = client.PostAsync(WebConfigurationManager.AppSettings["ApiRoot"] + route, stringContent).Result;
        //                break;
        //            case (int)RequestType.PUT:
        //                response = client.PutAsync(WebConfigurationManager.AppSettings["ApiRoot"] + route, stringContent).Result;
        //                break;
        //            case (int)RequestType.DELETE:
        //                response = client.DeleteAsync(WebConfigurationManager.AppSettings["ApiRoot"] + route).Result;
        //                break;
        //        }
        //        return response.Content.ReadAsStringAsync().Result;
        //    }
        //}

        //private static async Task<string> OldCallApiAsync(string route, string jsonRequestModel)
        //{
        //    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + SessionContext.Current.ActiveUser.TokenObj.Token);
        //        client.DefaultRequestHeaders.Add("Accept-Language", "en-Us");
        //        var stringContent = new StringContent(jsonRequestModel, Encoding.UTF8, "application/json");
        //        client.Timeout = TimeSpan.FromMinutes(15);
        //        HttpResponseMessage response = await client.PostAsync(WebConfigurationManager.AppSettings["ApiRoot"] + route, stringContent);
        //        var content = await response.Content.ReadAsStringAsync();
        //        return await Task.Run(() => content);
        //    }
        //}

        public static string OldCallApiNoToken(string route, string jsonRequestModel)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept-Language", "en-Us");
                client.Timeout = TimeSpan.FromMinutes(15);
                var stringContent = new StringContent(jsonRequestModel, Encoding.UTF8, "application/json");
                var response = client.PostAsync(route, stringContent).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }


        //////////////////**********////////////////////////

        //public static TResponse OldCallApi<TRequest, TResponse>(string route, TRequest requestModel, TResponse responseModel)
        //{
        //    responseModel = CallApi<TRequest, TResponse>(route, requestModel);
        //    return responseModel;
        //}

        //public static TResponse CallApi<TRequest, TResponse>(string route, TRequest requestModel, int requestType = (int)Enums.RequestType.POST)
        //{
        //    var js = new JsonSerializer();
        //    js.MaxJsonLength = int.MaxValue;
        //    var responseJson = CallApi(route, js.Serialize(requestModel), requestType);
        //    return js.Deserialize<TResponse>(responseJson);
        //}

        //public static async Task<TResponse> OldCallApiAsync<TRequest, TResponse>(string route, TRequest requestModel)
        //{
        //    var js = new JsonSerializer();
        //    js. = int.MaxValue;
        //    var responseJson = await OldCallApiAsync(route, js.Serialize(requestModel));
        //    return js.Deserialize<TResponse>(responseJson);
        //}

        //public static string OldCallApiRawData<TRequest, TResponse>(string route, TRequest requestModel, int requestType = (int)Enums.RequestType.POST)
        //{
        //    var js = new JavaScriptSerializer();
        //    js.MaxJsonLength = int.MaxValue;
        //    var responseJson = OldCallApi(route, js.Serialize(requestModel), requestType);
        //    return responseJson;
        //}

        public static TResponse OldCallApiNoToken<TRequest, TResponse>(string route, TRequest requestModel)
        {

            string output = JsonConvert.SerializeObject(requestModel);
            var responseJson = OldCallApiNoToken(route,output);
            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }

    }
}
