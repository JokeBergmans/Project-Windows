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
            IList<Trip> trips = _trips.Include(t => t.Items).ThenInclude(i => i.Item).Include(t => t.Tasks).Include(t => t.Activities).Include(t => t.Owner).Where(t => t.Owner.Email == email).OrderBy(t => t.Start).ToList();
            trips.ToList().ForEach(t => t.Activities.OrderBy(a => a.Start.Date).ThenBy(a => a.Start.TimeOfDay));
            return trips;
        }

        public Trip GetBy(int id, string email)
        {
            return GetAll(email).FirstOrDefault(t => t.Id == id);
        }

        public void Add(Trip trip)
        {
            _context.Entry(trip.Owner).State = EntityState.Unchanged;
            _context.Entry(trip).State = EntityState.Added;
            _trips.Add(trip);
        }

        public void Update(Trip trip)
        {
            _context.Entry(trip.Owner).State = EntityState.Unchanged;
            Trip dbTrip = GetBy(trip.Id, trip.Owner.Email);
            if (dbTrip != null)
            {
                dbTrip.Items.ToList().ForEach(i =>
                {
                    if (!trip.Items.Contains(i))
                        _context.Entry(i).State = EntityState.Deleted;
                });
                dbTrip.Tasks.ToList().ForEach(t =>
                {
                    if (!trip.Tasks.Contains(t))
                        _context.Entry(t).State = EntityState.Deleted;
                });
                dbTrip.Activities.ToList().ForEach(a =>
                {
                    if (!trip.Activities.Contains(a))
                        _context.Entry(a).State = EntityState.Deleted;
                });
            }
            _trips.Update(trip);

        }

        public void Delete(Trip trip)
        {
            _context.Entry(trip).State = EntityState.Deleted;
            _trips.Remove(trip);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
