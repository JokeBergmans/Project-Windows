﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
        public IList<Task> Tasks { get; set; }
        public IList<TripItem> Items { get; set; }
        public IList<Activity> Activities { get; set; }
        public IdentityUser Owner { get; set; }
        #endregion


        #region Constructors
        public Trip()
        {

        }

        public Trip(TripAddDTO tripDTO, IdentityUser user)
        {
            Start = tripDTO.Start;
            End = tripDTO.End;
            Name = tripDTO.Name;
            Owner = user;
            Tasks = new List<Task>();
            Items = new List<TripItem>();
            Activities = new List<Activity>();
        }
        #endregion

        #region Methods
        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }

        public void AddItem(Item item, int amount, bool packed)
        {
            Items.Add(new TripItem(item, amount, packed));
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void UpdateFromDTO(TripDTO tripDTO)
        {
            Start = tripDTO.Start;
            End = tripDTO.End;
            Name = tripDTO.Name;
            Items = tripDTO.Items;
            Tasks = tripDTO.Tasks;
            Activities = tripDTO.Activities;
        }
        #endregion
    }
}
