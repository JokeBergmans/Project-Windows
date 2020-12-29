using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
