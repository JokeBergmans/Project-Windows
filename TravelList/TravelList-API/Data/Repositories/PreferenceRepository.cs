using Microsoft.EntityFrameworkCore;
using System.Linq;
using TravelList_API.Models;
using TravelList_API.Models.Domain;

namespace TravelList_API.Data.Repositories
{
    public class PreferenceRepository : IPreferenceRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Preference> _preferences;
        #endregion

        #region Constructors
        public PreferenceRepository(ApplicationDbContext context)
        {
            _context = context;
            _preferences = context.Preferences;
        }
        #endregion

        #region Methods
        public Preference GetBy(string email)
        {
            return _preferences.Include(p => p.Owner).FirstOrDefault(p => p.Owner.Email == email);
        }

        public void Add(Preference preference)
        {
            _preferences.Add(preference);
        }

        public void Update(Preference preference)
        {
            _preferences.Update(preference);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
