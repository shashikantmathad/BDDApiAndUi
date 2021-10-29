using Newtonsoft.Json;
using RestApi.Model;
using RestSharp;
using System.IO;
using System.Net.Http;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestApi.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private RestClient client;
        private RestRequest request;
        private string baseURl= "https://reqres.in/";
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
            IRestResponse response = client.Execute(request);
        }

        [When(@"i create the request")]
        public void WhenICreateTheRequest(Table table)
        {
            Users userrequest = new Users();
            userrequest = table.CreateInstance<Users>();
            string requestbody = JsonConvert.SerializeObject(userrequest);
            request = commonobj.CreateRequest(Method.POST, requestbody);
        }




    }
}
