using dummyapi.Constant;
using dummyapi.Steps;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using dummyapi.Poco;
using Newtonsoft.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dummyapi
{
    [Binding]
    public class DeleteEmployeeSteps : BaseStep
    {
        public IRestResponse DeleteEmployeeById(string id)
        {
            RestRequest rest = new RestRequest(Constants.DeleteEmployee, Method.DELETE);
            rest.AddParameter("id", id, ParameterType.UrlSegment);
            Console.WriteLine(rest.Resource);
            RestResponse = client.Execute(rest);
            Console.WriteLine(RestResponse.Content);
            return RestResponse;
        }
        [Given(@"There are no employees in the database")]
        public void GivenThereAreNoEmployeesInTheDatabase()
        {
            IRestResponse allEmployeesResponse = new GetEmployeeSteps().GetAllEmployees();
            GetEmployeePoco[] employees = JsonConvert.DeserializeObject<GetEmployeePoco[]>(allEmployeesResponse.Content);

            foreach (GetEmployeePoco employee in employees)
            {
                DeleteEmployeeById(employee.id);
            }
            Console.WriteLine(JsonConvert.DeserializeObject<GetEmployeePoco[]>(new GetEmployeeSteps().GetAllEmployees().Content));
        }
        [When(@"I delete the employee with that id")]
        public void WhenIDeleteTheEmployeeWithThatId()
        {
            RestResponse = DeleteEmployeeById(PostEmployeeSteps.EmployeeId);
        }

        [Then(@"Employee is deleted")]
        public void ThenEmployeeIsDeleted()
        {
            Assert.AreEqual("{\"success\":{\"text\":\"successfully! deleted Records\"}}", RestResponse.Content);
        }
    }
}
