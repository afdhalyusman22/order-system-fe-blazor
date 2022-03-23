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
            var apiResponse = await _httpClient.DeleteAsync($"api/customers/{id}");
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
        var apiResponse = await _httpClient.GetStreamAsync($"api/customers/{id}");
        return await JsonSerializer.DeserializeAsync<CustomerDetail>
                (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    // public async Task UpdateItem(ItemData item)
    // {
    //     try
    //     {
    //         var itemJson = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");

    //         var url = $"api/todo/{item.Id}";

    //         var response = await _httpClient.PutAsync(url, itemJson);

    //         if (response.IsSuccessStatusCode)
    //         {
    //             Console.WriteLine("Success");
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine(ex.Message);
    //     }
    // }


}