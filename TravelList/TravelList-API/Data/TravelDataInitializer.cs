using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

        public async System.Threading.Tasks.Task InitializeDataAsync()
        {
            /*_dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                IdentityUser user = new IdentityUser { UserName = "jokebergmans@mail.com", Email = "jokebergmans@mail.com" };
                await CreateUser(user, "P@ssword1111!");

                Preference preference = new Preference() { Owner = user, DarkMode = false };

                Trip trip1 = new Trip() { Name = "Barcelona", Start = DateTime.Now.AddDays(60), End = DateTime.Now.AddDays(70), Owner = user, Tasks = new List<Task>(), Items = new List<TripItem>(), Activities = new List<Activity>() };
                Trip trip2 = new Trip() { Name = "Berlin", Start = DateTime.Now.AddDays(100), End = DateTime.Now.AddDays(107), Owner = user, Tasks = new List<Task>(), Items = new List<TripItem>(), Activities = new List<Activity>() };
                Trip trip3 = new Trip() { Name = "Moscou", Start = DateTime.Now.AddDays(-50), End = DateTime.Now.AddDays(-40), Owner = user, Tasks = new List<Task>(), Items = new List<TripItem>(), Activities = new List<Activity>() };

                Task task1 = new Task() { Name = "Load batteries", Completed = false };
                Task task2 = new Task() { Name = "Fill up car", Completed = false };

                Item item1 = new Item() { Name = "Toothbrush", Category = "Hygiene", Owner = user };
                Item item2 = new Item() { Name = "Underwear", Category = "Clothes", Owner = user };
                Item item3 = new Item() { Name = "Painkillers", Category = "Health", Owner = user };

                Activity activity1 = new Activity() { Name = "Check-in", Description = "Check-in at the airport", Location = "Zaventem", Start = DateTime.Now.AddDays(60).Date + new TimeSpan(10, 0, 0) };
                Activity activity2 = new Activity() { Name = "Departure", Description = "Departure of our flight! :D", Location = "Zaventem", Start = DateTime.Now.AddDays(60).Date + new TimeSpan(12, 0, 0) };

                _dbContext.Preferences.Add(preference);
                _dbContext.SaveChanges();

                _dbContext.Items.Add(item1);
                _dbContext.Items.Add(item2);
                _dbContext.Items.Add(item3);
                _dbContext.SaveChanges();

                trip1.AddTask(task1);
                trip1.AddTask(task2);
                trip1.AddItem(item1, 6, false);
                trip1.AddItem(item2, 2, false);
                trip1.AddItem(item3, 1, true);
                trip1.AddActivity(activity1);
                trip1.AddActivity(activity2);

                trip2.AddTask(task1);
                trip2.AddItem(item1, 4, true);
                trip2.AddItem(item2, 8, false);
                trip2.AddItem(item3, 6, true);

                trip3.AddTask(task1);
                trip3.AddTask(task2);
                trip3.AddItem(item1, 10, false);
                trip3.AddItem(item2, 20, false);


                _dbContext.Trips.Add(trip1);
                _dbContext.Trips.Add(trip2);
                _dbContext.Trips.Add(trip3);


                _dbContext.SaveChanges();

            }*/
        }

        private async System.Threading.Tasks.Task CreateUser(IdentityUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
        }
    }
}
