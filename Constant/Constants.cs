using System;
using System.Collections.Generic;
using System.Text;

namespace dummyapi.Constant
{
    class Constants
    {
        public const String BaseUri = "http://dummy.restapiexample.com";

        public const String GetAllEmployees = "/api/v1/employees";
        public const String GetSingleEmployee = "/api/v1/employee/{id}";
        public const String PostEmployee = "/api/v1/create";
        public const String PutEmployee = "/api/v1/update/{id}";
        public const String DeleteEmployee = "/api/v1/delete/{id}";
    }
}
