using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace dummyapi.Poco
{
    class PostEmployeePoco
    {
        [JsonProperty("id")]
        private String Id { get; set; }

        [JsonProperty("name")]
        private String Name { get; set; }

        [JsonProperty("salary")]
        private String Salary { get; set; }

        [JsonProperty("age")]
        private String Age { get; set; }
    }
}
