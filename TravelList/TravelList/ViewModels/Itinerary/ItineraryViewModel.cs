using System.Collections.ObjectModel;
using TravelList.Models;
using TravelList.Models.Domain;

namespace TravelList.ViewModels.Itinerary
{
    public class ItineraryViewModel
    {
        public ObservableCollection<Trip> trips = new ObservableCollection<Trip>();
    }
}
