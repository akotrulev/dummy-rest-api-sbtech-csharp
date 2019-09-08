using dummyapi.Constant;
using dummyapi.Poco;
using dummyapi.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace dummyapi
{
    [Binding]
    public class GetEmployeeSteps : BaseStep
    {
        private string employeeId;
        public IRestResponse GetAllEmployees()
        {
            RestRequest rest = new RestRequest(Constants.GetAllEmployees, Method.GET);

            RestResponse = client.Execute(rest);
            Console.WriteLine(RestResponse.Content);
            return RestResponse;
        }

        public IRestResponse GetEmployeeById(string id)
        {
            RestRequest rest = new RestRequest(Constants.GetSingleEmployee, Method.GET);
            rest.AddParameter("id", id, ParameterType.UrlSegment);
            RestResponse = client.Execute(rest);

            Console.WriteLine(RestResponse.Content);
            return RestResponse;
        }
        [Given(@"I have valid employee id")]
        public void GivenIHaveValidEmployeeId()
        {
            new PostEmployeeSteps().WhenICreateAnEmployeeWithName("Valid employee");
            employeeId = PostEmployeeSteps.EmployeeId;
        }

        [When(@"I get the employee by that id")]
        public void WhenIGetTheEmployeeByThatId()
        {
            RestResponse = GetEmployeeById(employeeId);
        }

        [When(@"I get all employees")]
        public void WhenIGetAllEmployees()
        {
            RestResponse = GetAllEmployees();
        }

        [Then(@"Correct employee is returned")]
        public void ThenCorrectEmployeeIsReturned()
        {
            Assert.AreEqual(employeeId, JsonConvert.DeserializeObject<PostEmployeePoco>(RestResponse.Content).id);
        }

        [Then(@"Two results are returned with names '(.*)' and '(.*)'")]
        public void ThenTwoResultsAreReturnedWithNamesAnd(string nameOfFirstEmployee, string nameOfSecondEmployee)
        {
            GetEmployeePoco[] getEmployeePocos = JsonConvert.DeserializeObject<GetEmployeePoco[]>(RestResponse.Content);
            Assert.AreEqual(nameOfFirstEmployee, getEmployeePocos[0].employee_name);
            Assert.AreEqual(nameOfSecondEmployee, getEmployeePocos[1].employee_name);
        }
    }
}
