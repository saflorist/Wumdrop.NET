using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Wumdrop.NET.Domain;

namespace Wumdrop.NET.Clients
{
    public abstract class BaseClient
    {
        public string ApiUrl { get; protected set; }
        public string ApiKey { get; protected set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="apiUrl">Uri of the web service method</param>
        /// <param name="apiKey">The key assigned by Wumdrop</param>
        protected BaseClient(string apiUrl, string apiKey)
        {
            ApiUrl = apiUrl;
            ApiKey = apiKey;
        }

        /// <summary>
        /// Call JSON/REST web service with basic authentication
        /// </summary>
        /// <typeparam name="T">The type to seserialize response to and return</typeparam>
        /// <param name="uri">Uri of the web service method</param>
        /// <param name="requestBodyObject">Object to serialize and pass to web service method</param>
        /// <param name="method">HTTP method/verb, "POST" or "GET"</param>
        /// <param name="username">Optional username if basic authentication is to be used</param>
        /// <param name="password">Optional password if basic authentication password is used</param>
        /// <returns></returns>
        protected T CallRestJsonService<T>(string uri, object requestBodyObject, string method = "POST", string username = "", string password = "") where T : BaseResponse, new()
        {
            var javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = 104857600; //200 MB unicode
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.Accept = "application/json";
            request.ContentType = "application/json; charset=utf-8";
            
            //Add basic authentication header if username is supplied
            if (!string.IsNullOrEmpty(username))
            {
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password)); ;
            }
            
            //Serialize request object as JSON and write to request body
            if (requestBodyObject != null)
            {
                var stringBuilder = new StringBuilder();
                javaScriptSerializer.Serialize(requestBodyObject, stringBuilder);
                var requestBody = stringBuilder.ToString();
                request.ContentLength = requestBody.Length;
                var streamWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
                streamWriter.Write(requestBody);
                streamWriter.Close();
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                //return a default object with the failed status code
                if (response == null || response.StatusCode != HttpStatusCode.OK)
                {
                    return BasicResponse<T>(response);
                }

                //Read JSON response stream and deserialize
                var streamReader = new System.IO.StreamReader(response.GetResponseStream());
                var responseContent = streamReader.ReadToEnd().Trim();
                var jsonObject = javaScriptSerializer.Deserialize<T>(responseContent);

                //set the status code as to let the UI know what happened
                jsonObject.HttpStatusCode = response.StatusCode;

                return jsonObject;

            }
            catch (WebException e)
            {
                
                HttpWebResponse response = (HttpWebResponse)e.Response;
                return BasicResponse<T>(response);
            }
            
        }

        /// <summary>
        /// let the UI know the outcome of the request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        private T BasicResponse<T>(HttpWebResponse response) where T : BaseResponse, new()
        {
            var objectResponse = new T();
            objectResponse.HttpStatusCode = response.StatusCode;
            objectResponse.StatusDescription = response.StatusDescription;

            return objectResponse;
        }
    }
}
