using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsoleDemoApiRest.Entities
{
    public class Datum
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("employee_name")]
        public string employee_name { get; set; }
        [JsonPropertyName("employee_salary")]
        public int employee_salary { get; set; }
        [JsonPropertyName("employee_age")]
        public int employee_age { get; set; }
        [JsonPropertyName("profile_image")]
        public string profile_image { get; set; }
    }
}
