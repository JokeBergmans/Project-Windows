using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelList_API.Models.Domain
{
    public class TripItem
    {
        #region Properties
        public int Id { get; set; }
        public Item Item { get; set; }

        public int Amount { get; set; }

        public bool Packed { get; set; }
        #endregion

        #region Constructors
        public TripItem()
        {

        }

        public TripItem(Item item, int amount, bool packed)
        {
            Item = item;
            Amount = amount;
            Packed = packed;
        }
        #endregion
    }
}
