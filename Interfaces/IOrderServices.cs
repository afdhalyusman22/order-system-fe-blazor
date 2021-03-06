using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using order_system_fe_blazor.Models.Orders;
namespace order_system_fe_blazor.Interfaces;

public interface IOrderServices
{
    Task<Orders[]> GetAllItems();
    Task<bool> DeleteItem(int id);
    Task<Orders> GetItemDetails(int id);
    Task<bool> UpdateItem(ModerateOrders item, int id);

}
