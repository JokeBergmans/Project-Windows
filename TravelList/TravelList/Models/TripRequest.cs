using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Name = "My new trip";
            Start = DateTime.Now;
            End = DateTime.Now.AddDays(7);
        }
    }
}
