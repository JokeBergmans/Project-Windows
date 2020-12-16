using GalaSoft.MvvmLight;
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
        public string Name { get { return _name; } set { Set("Name", ref _name, value); } }
        public string Description { get { return _description; } set { Set("Description", ref _description, value); } }
        public string Location { get { return _location; } set { Set("Location", ref _location, value); } }
        public DateTime Start { get { return _start; } set { Set("Start", ref _start, value); } }
        #endregion
    }
}
