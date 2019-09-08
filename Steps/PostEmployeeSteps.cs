using System;
using TechTalk.SpecFlow;
using RestSharp;
using dummyapi.Constant;
using dummyapi.Poco;
using dummyapi.Steps;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dummyapi
{
    [Binding]
    public class PostEmployeeSteps : BaseStep
    {
        public static string EmployeeId { get; set; }
        public IRestResponse CreateEmployee(PostEmployeePoco postEmployeePoco)
        {
            RestRequest rest = new RestRequest(Constants.PostEmployee, Method.POST);
            rest.AddJsonBody(postEmployeePoco);

            RestResponse = client.Execute(rest);
            Console.WriteLine(rest.Parameters.Find(param => param.Type == ParameterType.RequestBody).Value.ToString());
            Console.WriteLine(RestResponse.Content);
            return RestResponse;
        }

        public string CreateEmployeeAndGetId(PostEmployeePoco postEmployeePoco)
        {
            IRestResponse response = CreateEmployee(postEmployeePoco);
            return JsonConvert.DeserializeObject<PostEmployeePoco>(response.Content).id;
        }

        [Given(@"I create an employee with name '(.*)'")]
        public void WhenICreateAnEmployeeWithName(string name)
        {
            PostEmployeePoco body = new PostEmployeePoco();
            body.SetDefaultValues();
            body.name = name;
            RestResponse = this.CreateEmployee(body);
            EmployeeId = JsonConvert.DeserializeObject<PostEmployeePoco>(RestResponse.Content).id;
        }

        [Then(@"Server returns '(.*)'")]
        public void ThenServerReturns(String statusCode)
        {
            Assert.AreEqual(statusCode, RestResponse.StatusCode.ToString(), RestResponse.StatusCode.ToString());
        }

        [Then(@"Name in response is '(.*)'")]
        public void ThenNameInResponseIs(string name)
        {
            Assert.IsTrue(RestResponse.Content.Contains(name));
        }
    }
}
