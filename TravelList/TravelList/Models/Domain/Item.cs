using GalaSoft.MvvmLight;

namespace TravelList.Models.Domain
{
    public class Item : ObservableObject
    {
        #region Fields
        private string _name;
        private int _amount;
        private string _category;
        private bool _packed;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get { return _name; } set { Set("Name", ref _name, value); } }
        public int Amount { get { return _amount; } set { Set("Amount", ref _amount, value); } }
        public string Category { get { return _category; } set { Set("Category", ref _category, value); } }
        public bool Packed { get { return _packed; } set { Set("Packed", ref _packed, value); } }
        #endregion
    }
}
