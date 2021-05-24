using FurnitureStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreAPI.Services
{
    public interface IFurnitureStoreDataService
    {
        List<Furniture> GetAllFurnitures();
        int AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Furniture GetFurnitureByName(string name);
        Furniture GetFurnitureById(int id);
        void DeleteFurnitureForACustomer(int customerId);

        List<Furniture> GetAllFurnituresForACustomer(int customerId);

        void UpdateFurniturePrice(string name, double price);

        void AddPurchase(int customerId, int furnitureId);


        //void RemovePurchase(int customerId, int furnitureId);

    }
}
