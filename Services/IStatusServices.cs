
using order_system_fe_blazor.Models.Statuses;
namespace order_system_fe_blazor.Services;

public interface IStatusServices
{
    Task<Statuses[]> GetAllItems();

}
