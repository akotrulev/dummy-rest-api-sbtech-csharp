using System;
using TechTalk.SpecFlow;

namespace dummyapi
{
    [Binding]
    public class PostEmployeeSteps
    {
        [Given(@"I create an employee with name '(.*)'")]
        public void WhenICreateAnEmployeeWithName(string p0)
        {
            
        }
        
        [Then(@"Server returns (.*)")]
        public void ThenServerReturns(int p0)
        {
            
        }
        
        [Then(@"Name in response is '(.*)'")]
        public void ThenNameInResponseIs(string p0)
        {
            
        }
    }
}
