using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelList.Models.Domain
{
    public class Preference : ObservableObject
    {
        #region Fields
        private bool _darkMode;
        #endregion

        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("darkMode")]
        public bool DarkMode { get { return _darkMode; } set { Set("DarkMode", ref _darkMode, value); } }
        #endregion

        #region Constructors
        public Preference()
        {
            
        }
        #endregion
    }
}
