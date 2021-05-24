using FurnitureStoreAPI.Models;
using FurnitureStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FurnitureStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureStoreController : ControllerBase
    {
        public IFurnitureStoreDataService _db;
        public FurnitureStoreController(IFurnitureStoreDataService db)
        {
            _db = db;
        }
        // GET: api/<FurnitureStoreController>
        [HttpGet("Customers")]
        public IActionResult GetAllCustomers()
        {
            return Ok(_db.GetAllCustomers());
        }

        [HttpGet("Furnitures")]
        public IActionResult GetAllFurnitures()
        {
            return Ok(_db.GetAllFurnitures());
        }

        // GET api/<FurnitureStoreController>/5
        [HttpGet("Purchases")]
        public IActionResult GetAllCustomersWithFurnitures()
        {
            List<CustomerOutputViewModel> result = new List<CustomerOutputViewModel>();
            List<Customer> customers = _db.GetAllCustomers();
            foreach (var customer in customers)
            {
                CustomerOutputViewModel outCustomer = new CustomerOutputViewModel
                {
                    Name = customer.Name,
                    CustomerId = customer.CustomerId,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Furnitures = new List<FurnitureViewModel>()
                };
                foreach (Furniture furniture in _db.GetAllFurnituresForACustomer(customer.CustomerId))
                {
                    outCustomer.Furnitures.Add(
                        new FurnitureViewModel
                        {
                            FurnitureId = furniture.FurnitureId,
                            Title = furniture.Title,
                            Price = furniture.Price
                        }); 
                }
                result.Add(outCustomer);
            }
            return Ok(result);
        }

        // POST api/<FurnitureStoreController>
        [HttpPost("Customers")]
        public IActionResult Post(CustomerViewModel customer)
        {
            int count = 0;
            try
            {
                int id = _db.AddCustomer(new Customer { Name = customer.Name, Address = customer.Address, Phone = customer.Phone });
                foreach (string name in customer.Furnitures)
                {
                    Furniture found = _db.GetFurnitureByName(name);
                    if (found != null)
                    {
                        count++;
                        _db.AddPurchase(id, found.FurnitureId);
                    }
                }
            }
            catch (DuplicatePhoneNumberException e)
            {

                return BadRequest(e.Message);
            }
            
            return Ok($"Customer-{customer.Name} was added with {count} furnitures");
        }

        // PUT api/<FurnitureStoreController>/5
        [HttpPut("Furnitures/{title}")]
        public IActionResult Put(string title,Furniture furniture)
        {
            _db.UpdateFurniturePrice(title, furniture.Price);
            return Ok($"Price of {title} updated to {furniture.Price}");
        }

        [HttpGet("Furnitures/{title}")]
        public IActionResult GetFurniture(string title)
        {
            return Ok(_db.GetFurnitureByName(title));
           
        }

        // DELETE api/<FurnitureStoreController>/5
        [HttpDelete("Customers/{id}")]
        public IActionResult Delete(int id)
        {
            _db.DeleteFurnitureForACustomer(id);
            return Ok($"Deleted All Furnitures for Customer with ID = {id}");
        }
    }
}
