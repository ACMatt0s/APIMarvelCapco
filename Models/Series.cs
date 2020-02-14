using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace webapimarvel.Models
{
    public class Series
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("description")]
        public string description { get; set; }

        [JsonPropertyName("resourceURI")]
        public string resourceURI { get; set; }

        [JsonPropertyName("urls")]
        public string urls { get; set; }

        [JsonPropertyName("startYear")]
        public int startYear { get; set; }

        [JsonPropertyName("endYear")]
        public int endYear { get; set; }

        [JsonPropertyName("rating")]
        public string rating { get; set; }

        [JsonPropertyName("modified")]
        public DateTime modified { get; set; }

        [JsonPropertyName("thumbnail")]
        public string thumbnail { get; set; }

        [JsonPropertyName("comics")]
        public List<string> comics { get; set; }

        [JsonPropertyName("stories")]
        public List<string> stories { get; set; }

        [JsonPropertyName("events")]
        public List<string> events { get; set; }

        [JsonPropertyName("characters")]
        public List<string> characters { get; set; }

        [JsonPropertyName("creators")]
        public List<string> creators { get; set; }

        [JsonPropertyName("next")]
        public string next { get; set; }

        [JsonPropertyName("previous")]
        public string previous  { get; set; }
    }
}