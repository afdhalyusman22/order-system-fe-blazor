using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using order_system_fe_blazor.Models.TravelPackages;
namespace order_system_fe_blazor.Interfaces;

public interface ITravelPackageServices
{
    Task<TravelPackages[]> GetAllItems();
    Task<bool> DeleteItem(int id);
    Task<TravelPackages> GetItemDetails(int id);
    Task<bool> UpdateItem(TravelPackages item, int id);
    Task<bool> AddItem(TravelPackages item);
}
