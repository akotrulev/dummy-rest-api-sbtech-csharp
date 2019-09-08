using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace dummyapi.Poco
{
    public class PutEmployeePoco
    {
        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("salary")]
        public String salary { get; set; }

        [JsonProperty("age")]
        public String age { get; set; }
    }
}
