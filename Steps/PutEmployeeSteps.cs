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
    public class EmployeeSteps : BaseStep
    {
        private string employeeId;

        public IRestResponse PutEmployeeById(string id, PutEmployeePoco body)
        {
            RestRequest rest = new RestRequest(Constants.PutEmployee, Method.PUT);
            rest.AddParameter("id", id, ParameterType.UrlSegment);
            rest.AddJsonBody(body);

            RestResponse = client.Execute(rest);

            return RestResponse;
        }
        [Given(@"I have valid employee with salary '(.*)'")]
        public void GivenIHaveValidEmployeeWithSalary(string salary)
        {
            PostEmployeePoco employeePoco = new PostEmployeePoco();
            employeePoco.SetDefaultValues();
            employeePoco.salary = salary;

            employeeId = new PostEmployeeSteps().CreateEmployeeAndGetId(employeePoco);
        }

        [When(@"I update that employee's salary to '(.*)'")]
        public void WhenIUpdateThatEmployee(string salary)
        {
            PutEmployeePoco putEmployeePoco = new PutEmployeePoco();
            putEmployeePoco.salary = salary;

            RestResponse = PutEmployeeById(employeeId, putEmployeePoco);
        }

        [Then(@"Salary is changed to '(.*)'")]
        public void ThenSalaryIsChangedTo(String salary)
        {
            Assert.AreEqual(salary, JsonConvert.DeserializeObject<PutEmployeePoco>(RestResponse.Content).salary);
        }
    }
}
