using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreAPI.Models
{
    public class Customer
    {

        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public IList<CustomerFurniture> CustomerFurnitures { get; set; }

    }
}
