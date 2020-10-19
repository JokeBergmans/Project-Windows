using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelList_API.Models.Domain
{
    public class Trip
    {
        #region Properties
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IdentityUser Owner { get; set; }
        #endregion

        #region Methods
        public double GetTaskProgress() => Tasks.Where(t => t.Completed).Count() / Tasks.Count();
        public double GetItemProgress() => Items.Where(i => i.Packed).Count() / Items.Count();
        #endregion

        #region Constructors
        public Trip()
        {

        }
        #endregion
    }
}
