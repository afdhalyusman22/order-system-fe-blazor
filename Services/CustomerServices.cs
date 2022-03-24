using System.Text;
using System.Text.Json;
using order_system_fe_blazor.Models.Customers;

namespace order_system_fe_blazor.Services;

public class CustomerServices : ICustomerServices
{
    private readonly HttpClient _httpClient;

    public CustomerServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Customers> GetAllItems()
    {
        var apiResponse = await _httpClient.GetStreamAsync($"/api/customers?sort[0]=id%3Adesc");
        return await JsonSerializer.DeserializeAsync<Customers>
                 (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }


    public async Task<bool> DeleteItem(int id)
    {
        try
        {
            var apiResponse = await _httpClient.DeleteAsync($"/api/customers/{id}");
            if (apiResponse.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<CustomerDetail> GetItemDetails(int id)
    {
        var apiResponse = await _httpClient.GetStreamAsync($"/api/customers/{id}");
        return await JsonSerializer.DeserializeAsync<CustomerDetail>
                (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<bool> UpdateItem(CustomerDetail item, int id)
    {
        try
        {
            var items = new
            {
                data = item
            };
         
            var itemJson = new StringContent(JsonSerializer.Serialize(items), Encoding.UTF8, "application/json");

            Console.WriteLine(itemJson);
            var url = $"/api/customers/{id}";

            Console.WriteLine("edit");
            var response = await _httpClient.PutAsync(url, itemJson);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
                return true;
            }else
                return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> AddItem(CustomerDetail item)
    {
        try
        {
            var items = new
            {
                data = item
            };

            var itemJson = new StringContent(JsonSerializer.Serialize(items), Encoding.UTF8, "application/json");

            var url = $"/api/customers";

            Console.WriteLine(itemJson);
            var response = await _httpClient.PostAsync(url, itemJson);
            Console.WriteLine(response.ToString());
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }


}