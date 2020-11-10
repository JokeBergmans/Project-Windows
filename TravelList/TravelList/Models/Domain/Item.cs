using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelList.Models.Domain
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public Category Category { get; set; }
        public bool Packed { get; set; }
    }
}
