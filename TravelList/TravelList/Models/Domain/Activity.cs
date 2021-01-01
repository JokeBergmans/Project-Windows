using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;

namespace TravelList.Models.Domain
{
    public class Activity : ObservableObject
    {
        #region Fields
        private string _name;
        private string _description;
        private string _location;
        private DateTime _start;
        #endregion

        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get { return _name; } set { Set("Name", ref _name, value); } }
        [JsonProperty("description")]
        public string Description { get { return _description; } set { Set("Description", ref _description, value); } }
        [JsonProperty("location")]
        public string Location { get { return _location; } set { Set("Location", ref _location, value); } }
        [JsonProperty("start")]
        public DateTime Start { get { return _start; } set { Set("Start", ref _start, value); } }
        #endregion

        #region Constructors
        public Activity()
        {
            Name = "";
            Description = "";
            Location = "";
            Start = DateTime.Now;
        }
        #endregion

        public void Clear()
        {
            Name = "";
            Description = "";
            Location = "";
            Start = DateTime.Now;
        }
    }
}
