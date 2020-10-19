using System.Collections.Generic;
using TravelList_API.Models.Domain;

namespace TravelList_API.Models
{
    public interface ITripRepository
    {
        IEnumerable<Trip> GetAll(string userId);
        Trip GetBy(int id, string userId);
        void Add(Trip trip);
        void Update(Trip trip);
        void Delete(Trip trip);
        void SaveChanges();
    }
}
