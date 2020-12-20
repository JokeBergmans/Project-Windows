using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelList.Models.Domain
{
    public class TripItem : ObservableObject
    {
        #region Fields
        private int _amount;
        private bool _packed;
        #endregion

        #region Properties
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Amount { get { return _amount; } set { Set("Amount", ref _amount, value); } }
        public bool Packed { get { return _packed; } set { Set("Packed", ref _packed, value); } }
        #endregion
    }
}
