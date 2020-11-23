using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelList_API.Models.Domain
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
    }
}
