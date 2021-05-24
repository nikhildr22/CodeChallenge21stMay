using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreAPI.Models
{
    public class CustomerOutputViewModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<FurnitureViewModel> Furnitures { get; set; }
    }
}
