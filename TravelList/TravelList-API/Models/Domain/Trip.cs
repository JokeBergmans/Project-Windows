using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelList_API.DTOs;

namespace TravelList_API.Models.Domain
{
    public class Trip
    {
        #region Properties
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IdentityUser Owner { get; set; }
        #endregion


        #region Constructors
        public Trip()
        {

        }

        public Trip(TripDTO tripDTO, IdentityUser user)
        {
            Start = tripDTO.Start;
            End = tripDTO.End;
            Name = tripDTO.Name;
            Owner = user;
            Tasks = new List<Task>();
            Items = new List<Item>();
        }
        #endregion
    }
}
