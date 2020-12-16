using Microsoft.AspNetCore.Identity;
using TravelList_API.DTOs;

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
        public IdentityUser Owner { get; set; }
        #endregion

        #region Constructors
        public Item()
        {

        }

        public Item(ItemAddDTO itemDTO, IdentityUser owner)
        {
            Name = itemDTO.Name;
            Amount = itemDTO.Amount;
            Category = itemDTO.Category;
            Packed = false;
            Owner = owner;
        }

        public void UpdateFrom(Item item)
        {
            Name = item.Name;
            Amount = item.Amount;
            Category = item.Category;
            Packed = item.Packed;
        }
        #endregion
    }
}
