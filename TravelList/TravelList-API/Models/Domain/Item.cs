using Microsoft.AspNetCore.Identity;
using TravelList_API.DTOs;

namespace TravelList_API.Models.Domain
{
    public class Item
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public IdentityUser Owner { get; set; }
        #endregion

        #region Constructors
        public Item()
        {

        }
        #endregion

        #region Methods
        public Item(ItemAddDTO itemDTO, IdentityUser owner)
        {
            Name = itemDTO.Name;
            Category = itemDTO.Category;
            Owner = owner;
        }

        public void UpdateFrom(Item item)
        {
            Name = item.Name;
            Category = item.Category;
        }
        #endregion
    }
}
