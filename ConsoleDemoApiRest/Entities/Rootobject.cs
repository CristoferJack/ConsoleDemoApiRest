using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsoleDemoApiRest.Entities
{
    public class Rootobject
    {
        [JsonPropertyName("status")]
        public string status { get; set; }
        [JsonPropertyName("data")]
        public List<Datum> data { get; set; }
        [JsonPropertyName("message")]
        public string message { get; set; }
    }
}
