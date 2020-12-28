using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TravelList_API.Models;
using TravelList_API.Models.Domain;

namespace TravelList_API.Data.Repositories
{
    public class TripRepository : ITripRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Trip> _trips;
        private readonly DbSet<TripItem> _tripItems;
        private readonly DbSet<Item> _items;
        private readonly DbSet<Task> _tasks;
        private readonly DbSet<Activity> _activities;
        #endregion

        #region Constructors
        public TripRepository(ApplicationDbContext context)
        {
            _context = context;
            _trips = context.Trips;
        }
        #endregion

        #region Methods
        public IEnumerable<Trip> GetAll(string email)
        {
            return _trips.Include(t => t.Items).ThenInclude(i => i.Item).Include(t => t.Tasks).Include(t => t.Activities).Include(t => t.Owner).Where(t => t.Owner.Email == email).OrderBy(t => t.Start).ToList();
        }

        public Trip GetBy(int id, string email)
        {
            return GetAll(email).FirstOrDefault(t => t.Id == id);
        }

        public void Add(Trip trip)
        {
            _context.Entry(trip.Owner).State = EntityState.Unchanged;
            _trips.Add(trip);
        }

        public void Update(Trip trip)
        {
            _trips.Update(trip);
        }

        public void Delete(Trip trip)
        {
            _trips.Remove(trip);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
