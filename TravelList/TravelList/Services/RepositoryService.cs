using TravelList.Repositories;

namespace TravelList.Services
{
    public static class RepositoryService
    {
        public static TripRepository TripRepository { get; set; } = new TripRepository();

        public static ItemRepository ItemRepository { get; set; } = new ItemRepository();

        public static PreferenceRepository PreferenceRepository { get; set; } = new PreferenceRepository();

        public static void Login()
        {
            TripRepository = new TripRepository();
            ItemRepository = new ItemRepository();
            PreferenceRepository = new PreferenceRepository();
        }
    }
}
