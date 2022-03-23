using System.Text.Json;
using order_system_fe_blazor.Models.Orders;
namespace order_system_fe_blazor.Services;

public class OrderServices : IOrderServices
{
    private readonly HttpClient _httpClient;

    public OrderServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Orders[]> GetAllItems()
    {
        var apiResponse = await _httpClient.GetStreamAsync($"/custom/v1/order");
        return await JsonSerializer.DeserializeAsync<Orders[]>
                 (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<bool> DeleteItem(int id)
    {
        try
        {
            var apiResponse = await _httpClient.DeleteAsync($"api/orders/{id}");
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


}