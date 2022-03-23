using System.Text.Json;
using order_system_fe_blazor.Models.TravelPackages;
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


}