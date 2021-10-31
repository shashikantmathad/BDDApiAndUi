using Newtonsoft.Json;
using NUnit.Framework;
using RestApi.Model;
using RestSharp;
using RestSharp.Serialization.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestApi.Steps
{
    [Binding]
    public sealed class ApiTestsSteps
    {
        private RestClient client;
        private RestRequest request;
        private string baseURl = "https://reqres.in/";
        private CommonMethods commonobj = new CommonMethods();

        [Given(@"i use the endpoint (.*)")]
        public void GivenIUseTheEndpoint_(string  endpoint)
        {
            client = commonobj.GetRestClient(baseURl,endpoint);
           
        }

        [When(@"i create the (.*) method using (.*)")]
        public void WhenICreateThe_MethodUsing_(Method method, string requestBody)
        {
            request = commonobj.CreateRequest(method, requestBody);
        }

        [When(@"i send the request")]
        public void WhenISendTheRequest()
        {
           client.Execute(request);

        }

        [When(@"i create the request")]
        public void WhenICreateTheRequest(Table table)
        {
            Users userrequest = new Users();
            userrequest = table.CreateInstance<Users>();
            string requestbody = JsonConvert.SerializeObject(userrequest);
            request = commonobj.CreateRequest(Method.POST, requestbody);
        }

        [Then(@"the respose is successful")]
        public void ThenTheResposeIsSuccessful()
        {
            //statuscode = response.StatusCode;
            //var code = (int)statuscode;
            //Assert.AreEqual(201, code);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            //Assert.That(response.ContentType, Is.EqualTo("application/json"));
 
            Users users = new JsonDeserializer().Deserialize<Users>(response);
            // assert
            Assert.That(users.name, Is.EqualTo("morpheus"));
            Assert.That(users.job, Is.EqualTo("leader"));
            // var usercontent = Handlecontent.Getcontent<Createuserres>(response);

        }



    }
}
