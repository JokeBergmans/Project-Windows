﻿using Newtonsoft.Json;
using System;

namespace TravelList.Models
{
    public class TripRequest
    {
        [JsonProperty("start")]
        public DateTime Start { get; set; }
        [JsonProperty("end")]
        public DateTime End { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public TripRequest()
        {
            Name = "";
            Start = DateTime.Now;
            End = DateTime.Now.AddDays(7);
        }
    }
}
