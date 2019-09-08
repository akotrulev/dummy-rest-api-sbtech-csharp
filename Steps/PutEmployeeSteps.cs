using System;
using TechTalk.SpecFlow;

namespace dummyapi
{
    [Binding]
    public class EmployeeSteps
    {
        [Given(@"I have valid employee with salary '(.*)'")]
        public void GivenIHaveValidEmployeeWithSalary(int p0)
        {
            
        }
        
        [When(@"I update that employee'(.*)'(.*)'")]
        public void WhenIUpdateThatEmployee(string p0, int p1)
        {
            
        }
        
        [Then(@"Salary is changed to '(.*)'")]
        public void ThenSalaryIsChangedTo(int p0)
        { 

        }
    }
}
