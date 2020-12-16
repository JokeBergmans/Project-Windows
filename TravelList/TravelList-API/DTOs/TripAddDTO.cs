using System;

namespace TravelList_API.DTOs
{
    public class TripAddDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
    }
}
