using Microsoft.EntityFrameworkCore;
using System;
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
            return _trips.Include(t => t.Items).Include(t => t.Tasks).Where(t => t.Owner.Email == email).OrderBy(t => t.Start).ToList();
        }

        public Trip GetBy(int id, string email)
        {
            return GetAll(email).FirstOrDefault(t => t.Id == id);
        }

        public void Add(Trip trip)
        {
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
