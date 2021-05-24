using FurnitureStoreAPI.Models;
using FurnitureStoreAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreAPI.Services
{
    public class FurnitureStoreDataService : IFurnitureStoreDataService
    {
        private FurnitureStoreDbContext _context;
        public FurnitureStoreDataService(FurnitureStoreDbContext context)
        {
            _context = context;
        }
        public int AddCustomer(Customer customer)
        {
            bool phoneNumberExistsInDb = GetAllCustomers().Any(x => x.Phone == customer.Phone);
            if (phoneNumberExistsInDb)
            {
                throw new DuplicatePhoneNumberException(customer.Phone);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            int id = _context.Customers.FirstOrDefault(x => x.Name == customer.Name).CustomerId;
            return id;

        }

        public void AddPurchase(int customerId, int furnitureId)
        {
            _context.CustomerFurnitures.Add(new CustomerFurniture { CustomerId = customerId, FurnitureId = furnitureId });
            _context.SaveChanges();
        }

        public void DeleteFurnitureForACustomer(int customerId)
        {
           List<CustomerFurniture> purchases =  _context.CustomerFurnitures.Where(x => x.CustomerId == customerId).ToList();
            foreach (CustomerFurniture purchase in purchases)
            {
                _context.CustomerFurnitures.Remove(purchase);
                _context.SaveChanges();
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public List<Furniture> GetAllFurnitures()
        {
            return _context.Furnitures.ToList();
        }

        public List<Furniture> GetAllFurnituresForACustomer(int customerId)
        {
            List<CustomerFurniture> purchases = _context.CustomerFurnitures.Where(x => x.CustomerId == customerId).ToList();
            IEnumerable<Furniture> furnitures =  from i in purchases select GetFurnitureById(i.FurnitureId);
            return furnitures.ToList();
        }

        public Furniture GetFurnitureById(int id)
        {
           return _context.Furnitures.Find(id);
        }

        public Furniture GetFurnitureByName(string name)
        {
            return _context.Furnitures.FirstOrDefault(x=>x.Title==name);
        }

        

        public void UpdateFurniturePrice(string name, double price)
        {
            Furniture found = GetFurnitureByName(name);
            if (found!=null)
            {
                found.Price = price;
                _context.Furnitures.Update(found);
                _context.SaveChanges();
            }
        }
    }
}
