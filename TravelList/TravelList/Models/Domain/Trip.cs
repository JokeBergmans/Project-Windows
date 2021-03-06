﻿using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TravelList.Models.Domain
{
    public class Trip : ObservableObject
    {
        #region Fields
        private DateTime _start;
        private DateTime _end;
        private string _name;
        #endregion

        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("start")]
        public DateTime Start { get { return _start; } set { Set("Start", ref _start, value); } }
        [JsonProperty("end")]
        public DateTime End { get { return _end; } set { Set("End", ref _end, value); } }
        [JsonProperty("name")]
        public string Name { get { return _name; } set { Set("Name", ref _name, value); } }
        [JsonProperty("tasks")]
        public ObservableCollection<Task> Tasks { get; set; }
        [JsonProperty("items")]
        public ObservableCollection<TripItem> Items { get; set; }
        [JsonProperty("activities")]
        public ObservableCollection<Activity> Activities { get; set; }
        public double TaskProgress
        {
            get
            {
                if (Tasks.Count() == 0)
                    return 0;
                else
                {
                    return (double)Tasks.Where(t => t.Completed).Count() / (double)Tasks.Count() * 100;

                }
            }
        }

        public double ItemProgress
        {
            get
            {
                if (Items.Count() == 0)
                    return 0;
                else
                    return (double)Items.Where(i => i.Packed).Count() / (double)Items.Count() * 100;
            }
        }

        public string DaysUntil
        {
            get
            {
                int days = Start.Subtract(DateTime.Now).Days;
                if (days > 0)
                    return days + " more days";
                else
                    return End.Subtract(DateTime.Now).Days + " days left";
            }
        }

        public string NextActivity
        {
            get
            {
                if (Activities.Count == 0)
                    return "No upcoming activities";
                DateTime today = DateTime.Now;
                List<Activity> upcoming = Activities.Where(a => a.Start.Subtract(today).Ticks > 0).ToList();
                if (upcoming.Count < 0)
                    return "No upcoming activities";
                else
                {
                    long ticks = upcoming.Select(a => a.Start.Subtract(today).Ticks).Min();
                    TimeSpan span = new TimeSpan(ticks);
                    if (span.Days > 0)
                        return string.Format("Next activity in {0} days, {1} hours", span.Days, span.Hours);
                    else
                        return string.Format("Next activity in {0} hours, {1} minutes", span.Hours, span.Minutes);

                }
            }
        }
        #endregion
    }
}
