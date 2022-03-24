using System.Text;
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

    public async Task<Orders> GetItemDetails(int id)
    {
        Console.WriteLine("id :" + id.ToString());
        var apiResponse = await _httpClient.GetStreamAsync($"/custom/v1/order/{id}");
        return await JsonSerializer.DeserializeAsync<Orders>
                (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<bool> UpdateItem(ModerateOrders item, int id)
    {
        try
        {
            var items = new
            {
                data = item
            };

            var itemJson = new StringContent(JsonSerializer.Serialize(items), Encoding.UTF8, "application/json");

            Console.WriteLine(itemJson);
            var url = $"/api/orders/{id}";
            var response = await _httpClient.PutAsync(url, itemJson);

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