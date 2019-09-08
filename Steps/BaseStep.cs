using dummyapi.Constant;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace dummyapi.Steps
{
    public class BaseStep
    {
        protected RestClient client;
        public static IRestResponse RestResponse { get; set; }
        public BaseStep()
        {
            client = new RestClient(Constants.BaseUri);
        }
    }
}
