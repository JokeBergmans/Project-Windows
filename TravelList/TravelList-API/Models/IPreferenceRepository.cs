using TravelList_API.Models.Domain;

namespace TravelList_API.Models
{
    public interface IPreferenceRepository
    {
        Preference GetBy(string userId);
        void Add(Preference preference);
        void Update(Preference preference);

        void SaveChanges();
    }
}
