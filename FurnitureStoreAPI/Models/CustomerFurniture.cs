using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreAPI.Models
{
    public class CustomerFurniture
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int FurnitureId { get; set; }
        public Furniture Furniture { get; set; }
    }
}
