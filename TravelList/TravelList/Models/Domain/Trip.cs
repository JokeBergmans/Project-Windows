using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelList.Models.Domain;

namespace TravelList.Models
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
        public double TaskProgress { get
            {
                if (Tasks.Count() == 0)
                    return 0;
                else
                    return Tasks.Where(t => t.Completed).Count() / Tasks.Count();
            } 
        }

        public double ItemProgress { get
            {
                if (Items.Count() == 0)
                    return 0;
                else
                    return Items.Where(i => i.Packed).Count() / Items.Count();
            }
        }
        #endregion
    }
}
