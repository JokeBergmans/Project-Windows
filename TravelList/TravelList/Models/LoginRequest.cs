using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelList.Models
{
    public class LoginRequest : INotifyPropertyChanged
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
