using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreAPI.Models
{
    public class Furniture
    {
        [Key]
        public int FurnitureId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public IList<CustomerFurniture> CustomerFurnitures { get; set; }

    }
}
