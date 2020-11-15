using System.Collections.Generic;
using TravelList_API.Models.Domain;

namespace TravelList_API.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll(string email);
        Item GetBy(int id, string email);
        void Add(Item item);
        void Update(Item item);
        void Delete(Item item);
        void SaveChanges();
    }
}
