using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestApi
{
    class CommonMethods
    {
        private RestClient client;
        internal RestClient GetRestClient(string baseURl,string endpoint)
        {
            string URI = Path.Combine(baseURl, endpoint);
            client = new RestClient(URI);
            return client;
        }

        internal RestRequest CreateRequest(Method method, string requestBody)
        {
            RestRequest request = new RestRequest(method);
            request.AddJsonBody(requestBody);
            return request;
        }

        //public IRestResponse GetResponse()
        //{
        //    IRestResponse response = client.Execute(CreateRequest);
        //    statuscode = response.StatusCode;
        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        //    return response;
        //}


    }
}
