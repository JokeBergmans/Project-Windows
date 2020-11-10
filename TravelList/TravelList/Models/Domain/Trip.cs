using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelList.Models.Domain;

namespace TravelList.Models
{
    public class Trip
    {
        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("start")]
        public DateTime Start { get; set; }
        [JsonProperty("end")]
        public DateTime End { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("tasks")]
        public IEnumerable<Task> Tasks { get; set; }
        [JsonProperty("items")]
        public IEnumerable<Item> Items { get; set; }
        public double TaskProgress { get
            {
                if (Tasks.Count() == 0)
                    return 0;
                else
                {
                    return (double) Tasks.Where(t => t.Completed).Count() / (double) Tasks.Count() *100;

                }
            } 
        }

        public double ItemProgress { get
            {
                if (Items.Count() == 0)
                    return 0;
                else
                    return (double) Items.Where(i => i.Packed).Count() / (double) Items.Count() *100;
            }
        }

        public string DaysUntil { get
            {
                return Start.Subtract(DateTime.Now).Days + " more days";
            } 
        }
        #endregion
    }
}
