using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DMSClassLibrary
{
    public static class WebApiLibrary
    {
        public static string GetMethodRetrieveData(WebApiParameter param) 
        {
            string stringData;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(param.url);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add(param.ApiHeader, param.ApiKey);
                HttpResponseMessage response = client.GetAsync(param.url).Result;
                stringData = response.Content.ReadAsStringAsync().Result;
            }
            return stringData;
        }

        public static string PostMethodRetrieveData(WebApiParameter param)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var post_url = new Uri(param.url);
                    var content = new StringContent(param.ObjectString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Add(param.ApiHeader, param.ApiKey);
                    //HTTP POST
                    var postTask = client.PostAsync(post_url, content);
                    postTask.Wait();

                    var result = postTask.Result;
                    return result.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception xc)
            {
                return "Exception Error: " + xc;
            }
        }

        public static string PostMethodWithReturnData(WebApiParameter param)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var post_url = new Uri(param.url);
                    var content = new StringContent(param.ObjectString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Add(param.ApiHeader, param.ApiKey);
                    //HTTP POST
                    var postTask = client.PostAsync(post_url, content);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return result.Content.ReadAsStringAsync().Result;
                    }
                    //return "CommitPostActionWithReturn failed.";
                    return null;
                }
            }
            catch (Exception xc)
            {
                return "Exception Error: " + xc;
            }
        }

        public static string PostMethod(WebApiParameter param)
        {
            if (string.IsNullOrEmpty(param.ObjectString)) return "data string is empty";
            try
            {
                using (var client = new HttpClient())
                {
                    var post_url = new Uri(param.url);
                    var content = new StringContent(param.ObjectString);
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.DefaultRequestHeaders.Add(param.ApiHeader, param.ApiKey);
                    //HTTP POST
                    var postTask = client.PostAsync(post_url, content);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return "success";
                    }
                    return "CommitPostAction failed.";
                }
            }
            catch (Exception xc)
            {
                return "Exception Error: " + xc;
            }
        }
    }
}
