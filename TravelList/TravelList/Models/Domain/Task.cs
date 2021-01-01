using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace TravelList.Models.Domain
{
    public class Task : ObservableObject
    {
        #region Fields
        private string _name;
        private bool _completed;
        #endregion

        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get { return _name; } set { Set("Name", ref _name, value); } }
        [JsonProperty("completed")]
        public bool Completed { get { return _completed; } set { Set("Completed", ref _completed, value); } }
        #endregion

        #region Constructors
        public Task()
        {
            Name = "";
            Completed = false;
        }
        #endregion

        #region Methods
        public void Clear()
        {
            Name = "";
            Completed = false;
        } 
        #endregion
    }
}
