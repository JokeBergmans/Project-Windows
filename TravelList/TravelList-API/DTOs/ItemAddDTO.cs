using TravelList_API.Models.Domain;

namespace TravelList_API.DTOs
{
    public class ItemAddDTO
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Category { get; set; }

        public ItemAddDTO()
        {

        }

        public ItemAddDTO(Item item)
        {
            Name = item.Name;
            Amount = item.Amount;
            Category = item.Category;
        }
    }
}
