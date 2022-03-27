using System.Text;
using System.Text.Json;
using order_system_fe_blazor.Models.Statuses;
using order_system_fe_blazor.Interfaces;
namespace order_system_fe_blazor.Services;

public class StatusServices : IStatusServices
{
    private readonly HttpClient _httpClient;

    public StatusServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Statuses[]> GetAllItems()
    {
        var apiResponse = await _httpClient.GetStreamAsync($"/api/statuses");
        return await JsonSerializer.DeserializeAsync<Statuses[]>
                 (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
    }
}