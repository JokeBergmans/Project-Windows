using GalaSoft.MvvmLight;

namespace TravelList.Models.Domain
{
    public class Item : ObservableObject
    {
        #region Fields
        private string _name;
        private string _category;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get { return _name; } set { Set("Name", ref _name, value); } }
        public string Category { get { return _category; } set { Set("Category", ref _category, value); } }
        #endregion
    }
}
