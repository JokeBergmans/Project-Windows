﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelList_API.Models.Domain;

namespace TravelList_API.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TripItem> TripItems { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Preference> Preferences { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Trip>().HasMany(t => t.Tasks).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Trip>().HasMany(t => t.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Trip>().HasMany(t => t.Activities).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<TripItem>().HasOne(ti => ti.Item).WithMany().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
