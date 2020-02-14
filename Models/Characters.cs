// using System;
// using System.Collections.Generic;
// using System.Globalization;
// using System.Text.Json.Serialization;

namespace WebApiMarvel.Models
{
    public class Characters
    {
        ////[JsonPropertyName("id")]
        public int id { get; set; }

        ////[JsonPropertyName("name")]
        public string name { get; set; }

        //[JsonPropertyName("description")]
        public string description { get; set; }

        //[JsonPropertyName("modified")]
        public string modified { get; set; }

        //[JsonPropertyName("resourceURI")]
        public string resourceURI { get; set; }

        //[JsonPropertyName("urls")]
        public int urls { get; set; }

        //[JsonPropertyName("thumbnail")]
        public int thumbnail { get; set; }

        //[JsonPropertyName("comics")]
        public int comics { get; set; }

        //[JsonPropertyName("stories")]
        public int stories { get; set; }

        //[JsonPropertyName("events")]
        public int events { get; set; }

        //[JsonPropertyName("series")]
        public int series { get; set; }

        //[JsonPropertyName("returned")]
        public int returned { get; set; }

    }
}