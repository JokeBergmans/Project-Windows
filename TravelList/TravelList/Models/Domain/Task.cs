using GalaSoft.MvvmLight;

namespace TravelList.Models.Domain
{
    public class Task : ObservableObject
    {
        #region Fields
        private string _name;
        private bool _completed;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get { return _name; } set { Set("Name", ref _name, value); } }
        public bool Completed { get { return _completed; } set { Set("Completed", ref _completed, value); } }
        #endregion

        #region Constructors
        public Task()
        {
            Name = "";
            Completed = false;
        }
        #endregion
    }
}
