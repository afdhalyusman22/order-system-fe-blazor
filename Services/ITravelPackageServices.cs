using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using order_system_fe_blazor.Models.TravelPackages;
namespace order_system_fe_blazor.Services;

public interface ITravelPackageServices
{
    Task<TravelPackages[]> GetAllItems();
    Task<bool> DeleteItem(int id);
}
