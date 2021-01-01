using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace TravelList.Models.Domain
{
    public class Item : ObservableObject
    {
        #region Fields
        private string _name;
        private string _category;
        #endregion

        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get { return _name; } set { Set("Name", ref _name, value); } }
        [JsonProperty("category")]
        public string Category { get { return _category; } set { Set("Category", ref _category, value); } }
        #endregion

        #region Methods
        override public string ToString()
        {
            return Name;
        }

        public void Clear()
        {
            Name = "";
        }
        #endregion
    }
}
