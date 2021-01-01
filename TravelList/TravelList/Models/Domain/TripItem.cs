using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace TravelList.Models.Domain
{
    public class TripItem : ObservableObject
    {
        #region Fields
        private int _amount;
        private bool _packed;
        #endregion

        #region Properties
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("item")]
        public Item Item { get; set; }
        [JsonProperty("amount")]
        public int Amount { get { return _amount; } set { Set("Amount", ref _amount, value); } }
        [JsonProperty("packed")]
        public bool Packed { get { return _packed; } set { Set("Packed", ref _packed, value); } }
        #endregion

        #region Constructors
        public TripItem()
        {
            Amount = 0;
            Packed = false;
            Item = null;
        }
        #endregion

        #region Methods
        public void Clear()
        {
            Amount = 0;
            Item = null;
            Packed = false;
        }
        #endregion
    }
}
