using Newtonsoft.Json;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace dummyapi.Poco
{
    public class GetEmployeePoco
    {
        [JsonProperty("id")]
        public String id { get; set; }

        [JsonProperty("employee_name")]
        public String employee_name { get; set; }

        [JsonProperty("employee_salary")]
        public String employee_salary { get; set; }

        [JsonProperty("employee_age")]
        public String employee_age { get; set; }

        [JsonProperty("profile_image")]
        public String profile_image { get; set; }
    }
}
