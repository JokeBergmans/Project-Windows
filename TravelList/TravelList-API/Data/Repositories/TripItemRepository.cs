using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelList_API.Models.Domain;

namespace TravelList_API.Data.Repositories
{
    public class TripItemRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TripItem> _tripItems;
        #endregion

        #region Constructors
        public TripItemRepository(ApplicationDbContext context)
        {
            _context = context;
            _tripItems = context.TripItems;
        }
        #endregion

        #region Methods
        #endregion
    }
}
