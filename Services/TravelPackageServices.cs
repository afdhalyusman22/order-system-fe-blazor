using System.Text.Json;
using System.Text;
using order_system_fe_blazor.Models.TravelPackages;
using order_system_fe_blazor.Interfaces;
namespace order_system_fe_blazor.Services;

public class TravelPackageServices : ITravelPackageServices
{
    private readonly HttpClient _httpClient;

    public TravelPackageServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TravelPackages[]> GetAllItems()
    {
        var apiResponse = await _httpClient.GetStreamAsync($"/custom/v1/travel-package");
        return await JsonSerializer.DeserializeAsync<TravelPackages[]>
                 (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<bool> DeleteItem(int id)
    {
        try
        {
            var apiResponse = await _httpClient.DeleteAsync($"api/travel-packages/{id}");
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

    public async Task<TravelPackages> GetItemDetails(int id)
    {
        var apiResponse = await _httpClient.GetStreamAsync($"/custom/v1/travel-package/{id}");
        return await JsonSerializer.DeserializeAsync<TravelPackages>
                (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }

    public async Task<bool> UpdateItem(TravelPackages item, int id)
    {
        try
        {
            var items = new
            {
                data = new
                {
                    name = item.name,
                    description = item.description
                }
            };

            var itemJson = new StringContent(JsonSerializer.Serialize(items), Encoding.UTF8, "application/json");

            Console.WriteLine(itemJson);
            var url = $"/api/travel-packages/{id}";

            Console.WriteLine("edit");
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

    public async Task<bool> AddItem(TravelPackages item)
    {
        try
        {
            var items = new
            {
                data = new
                {
                    name = item.name,
                    description = item.description
                }
            };

            var itemJson = new StringContent(JsonSerializer.Serialize(items), Encoding.UTF8, "application/json");

            var url = $"/api/travel-packages";

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