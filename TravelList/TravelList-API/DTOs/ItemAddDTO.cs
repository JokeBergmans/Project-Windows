using TravelList_API.Models.Domain;

namespace TravelList_API.DTOs
{
    public class ItemAddDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }

        public ItemAddDTO()
        {

        }

        public ItemAddDTO(Item item)
        {
            Name = item.Name;
            Category = item.Category;
        }
    }
}
