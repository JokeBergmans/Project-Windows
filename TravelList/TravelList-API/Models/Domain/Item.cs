namespace TravelList_API.Models.Domain
{
    public class Item
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Category { get; set; }
        public bool Packed { get; set; }
        #endregion

        #region Constructors
        public Item()
        {

        }
        #endregion
    }
}
