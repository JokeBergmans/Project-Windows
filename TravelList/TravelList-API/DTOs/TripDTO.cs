using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelList_API.DTOs
{
    public class TripDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
    }
}
