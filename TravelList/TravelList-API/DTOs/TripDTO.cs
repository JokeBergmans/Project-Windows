using System;
using System.Collections.Generic;
using TravelList_API.Models.Domain;

namespace TravelList_API.DTOs
{
    public class TripDTO
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public IList<Task> Tasks { get; set; }
        public IList<TripItem> Items { get; set; }
        public IList<Activity> Activities { get; set; }

        public TripDTO()
        {

        }

        public TripDTO(Trip trip)
        {
            Id = trip.Id;
            Start = trip.Start;
            End = trip.End;
            Name = trip.Name;
            Tasks = trip.Tasks;
            Items = trip.Items;
            Activities = trip.Activities;
        }
    }
}
