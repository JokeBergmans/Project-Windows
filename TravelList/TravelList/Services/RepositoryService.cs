using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelList.Repositories;

namespace TravelList.Services
{
    public static class RepositoryService
    {
        public static TripRepository TripRepository { get; set; } = new TripRepository();

        public static ItemRepository ItemRepository { get; set; } = new ItemRepository();
    }
}
