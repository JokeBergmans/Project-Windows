using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TravelList_API.Models;
using TravelList_API.Models.Domain;

namespace TravelList_API.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Item> _items;
        #endregion

        #region Constructors
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
            _items = context.Items;
        }
        #endregion

        #region Methods
        public IEnumerable<Item> GetAll(string email)
        {
            return _items.Include(i => i.Owner).Where(i => i.Owner.Email == email).OrderBy(i => i.Category).ThenBy(i => i.Name).ToList();
        }

        public Item GetBy(int id, string email)
        {
            return GetAll(email).FirstOrDefault(i => i.Id == id);
        }

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Update(Item item)
        {
            _items.Update(item);
        }

        public void Delete(Item item)
        {
            _items.Remove(item);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
