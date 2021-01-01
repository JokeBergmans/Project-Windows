using GalaSoft.MvvmLight;

namespace TravelList.Models
{
    public class Error : ObservableObject
    {
        private string _message;
        public string Message { get { return _message; } set { Set("Message", ref _message, value); } }

        public Error()
        {
            _message = "";
        }

    }
}
