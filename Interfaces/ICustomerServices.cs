using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using order_system_fe_blazor.Models.Customers;

namespace order_system_fe_blazor.Interfaces;

public interface ICustomerServices
{
    Task<Customers> GetAllItems();
    Task<bool> DeleteItem(int id);
    Task<CustomerDetail> GetItemDetails(int id);
    Task<bool> UpdateItem(CustomerDetail item, int id);
    Task<bool> AddItem(CustomerDetail item);

}
