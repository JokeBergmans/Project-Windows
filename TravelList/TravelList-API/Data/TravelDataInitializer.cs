using Microsoft.AspNetCore.Identity;
using System;
using TravelList_API.Models.Domain;

namespace TravelList_API.Data
{
    public class TravelDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public TravelDataInitializer(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        
        public void InitializeDataAsync()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {


                    /*Trip trip1 = new Trip() { Name = "Barcelona", Start = DateTime.Now.AddDays(60), End = DateTime.Now.AddDays(70) };
                    Trip trip2 = new Trip() { Name = "Berlin", Start = DateTime.Now.AddDays(100), End = DateTime.Now.AddDays(107) };
                    Trip trip3 = new Trip() { Name = "Moscou", Start = DateTime.Now.AddDays(-50), End = DateTime.Now.AddDays(-40) };

                    Task task1 = new Task() { Name = "Load batteries", Completed = false };
                    Task task2 = new Task() { Name = "Fill up car", Completed = false };

                    Category category1 = new Category() { Name = "Hygiene" };
                    Category category2 = new Category() { Name = "Clothes" };
                    Category category3 = new Category() { Name = "Health" };

                    Item item1 = new Item() { Name = "Toothbrush", Packed = false, Category = category1 };
                    Item item2 = new Item() { Name = "Underwear", Packed = false, Category = category2 };
                    Item item3 = new Item() { Name = "Painkillers", Packed = false, Category = category3 };

                    trip1.AddTask(task1);
                    trip1.AddTask(task2);
                    trip1.AddItem(item1);
                    trip1.AddItem(item2);
                    trip1.AddItem(item3);

                    trip2.AddTask(task1);
                    trip2.AddItem(item1);
                    trip2.AddItem(item2);
                    trip2.AddItem(item3);

                    trip3.AddTask(task1);
                    trip3.AddTask(task2);
                    trip3.AddItem(item1);
                    trip3.AddItem(item2);

                    _dbContext.Trips.Add(trip1);
                    _dbContext.Trips.Add(trip2);
                    _dbContext.Trips.Add(trip3);

                    _dbContext.SaveChanges();*/
                
            }
        }
    }
}
