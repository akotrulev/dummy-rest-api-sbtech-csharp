using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace dummyapi.Poco
{
    class GetEmployeePoco
    {
        [JsonProperty("id")]
        private String Id { get; set; }

        [JsonProperty("employee_name")]
        private String Name { get; set; }

        [JsonProperty("employee_salary")]
        private String Salary { get; set; }

        [JsonProperty("employee_age")]
        private String Age { get; set; }

        [JsonProperty("profile_image")]
        private String profileImage { get; set; }
    }
}
