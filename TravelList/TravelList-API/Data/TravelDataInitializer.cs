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
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                IdentityUser user = new IdentityUser { UserName = "jokebergmans@mail.com", Email = "jokebergmans@mail.com" };
                await CreateUser(user, "P@ssword1111!");

                Preference preference = new Preference() { Owner = user, DarkMode = false };

                Trip trip1 = new Trip() { Name = "Barcelona", Start = DateTime.Now.AddDays(60), End = DateTime.Now.AddDays(70), Owner = user, Tasks = new List<Task>(), Items = new List<TripItem>(), Activities = new List<Activity>() };
                Trip trip2 = new Trip() { Name = "Berlin", Start = DateTime.Now.AddDays(100), End = DateTime.Now.AddDays(107), Owner = user, Tasks = new List<Task>(), Items = new List<TripItem>(), Activities = new List<Activity>() };
                Trip trip3 = new Trip() { Name = "Moscou", Start = DateTime.Now.AddDays(-50), End = DateTime.Now.AddDays(-40), Owner = user, Tasks = new List<Task>(), Items = new List<TripItem>(), Activities = new List<Activity>() };
                Trip trip4 = new Trip() { Name = "New York", Start = DateTime.Now.AddDays(-2), End = DateTime.Now.AddDays(12), Owner = user, Tasks = new List<Task>(), Items = new List<TripItem>(), Activities = new List<Activity>() };

                Task task1 = new Task() { Name = "Load batteries", Completed = false };
                Task task2 = new Task() { Name = "Fill up car", Completed = false };

                Item item1 = new Item() { Name = "Toothbrush", Category = "Hygiene", Owner = user };
                Item item2 = new Item() { Name = "Underwear", Category = "Clothes", Owner = user };
                Item item3 = new Item() { Name = "Painkillers", Category = "Health", Owner = user };

                Activity activity1 = new Activity() { Name = "Check-in", Description = "Check-in at the airport", Location = "Zaventem", Start = DateTime.Now.AddDays(60).Date + new TimeSpan(10, 0, 0) };
                Activity activity2 = new Activity() { Name = "Departure", Description = "Departure of our flight! :D", Location = "Zaventem", Start = DateTime.Now.AddDays(60).Date + new TimeSpan(12, 0, 0) };

                Activity activity3 = new Activity() { Name = "Check-in", Description = "Check-in at the airport", Location = "Charleroi", Start = trip3.Start.Date + new TimeSpan(10, 0, 0) };
                Activity activity4 = new Activity() { Name = "Arrival", Description = "Arrival in Moscou", Location = "Moscou", Start = trip3.Start.Date + new TimeSpan(23, 0, 0) };
                Activity activity5 = new Activity() { Name = "Depature", Description = "Departure of our flight back home", Location = "Moscou", Start = trip3.End.Date.AddDays(-1) + new TimeSpan(13, 0, 0) };

                Activity activity6 = new Activity() { Name = "Check-in", Description = "Check-in at the airport", Location = "Zaventem", Start = trip4.Start.Date + new TimeSpan(6, 0, 0) };
                Activity activity7 = new Activity() { Name = "Depature", Description = "Departure of our flight", Location = "Zaventem", Start = trip4.Start.Date + new TimeSpan(8, 0, 0) };
                Activity activity8 = new Activity() { Name = "Dinner", Description = "Dinner reservation at Delmonico's", Location = "New York", Start = trip4.Start.Date.AddDays(4) + new TimeSpan(18, 0, 0) };

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
                trip3.AddActivity(activity3);
                trip3.AddActivity(activity4);
                trip3.AddActivity(activity5);

                trip4.AddTask(task1);
                trip4.AddTask(task2);
                trip4.AddItem(item1, 2, false);
                trip4.AddItem(item2, 14, false);
                trip4.AddItem(item3, 1, true);
                trip4.AddActivity(activity6);
                trip4.AddActivity(activity7);
                trip4.AddActivity(activity8);

                _dbContext.Trips.Add(trip1);
                _dbContext.Trips.Add(trip2);
                _dbContext.Trips.Add(trip3);
                _dbContext.Trips.Add(trip4);

                _dbContext.SaveChanges();

            }
        }

        private async System.Threading.Tasks.Task CreateUser(IdentityUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
        }
    }
}
