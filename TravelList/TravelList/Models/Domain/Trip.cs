using GalaSoft.MvvmLight;
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
                return Start.Subtract(DateTime.Now).Days + " more days";
            }
        }

        public string NextActivity
        {
            get
            {
                if (Activities.Count == 0)
                    return "No upcoming activities";
                DateTime today = DateTime.Now;
                long ticks = Activities.Select(a => a.Start.Subtract(today).Ticks).Min();
                if (ticks < 0)
                    return "No upcoming activities";
                else
                {
                    TimeSpan span = new TimeSpan(ticks);
                    return string.Format("Next activity in {0} days, {1} hours, {2} minutes", span.Days, span.Hours, span.Minutes);

                }
            }
        }
        #endregion
    }
}
