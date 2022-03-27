
using order_system_fe_blazor.Models.Statuses;
namespace order_system_fe_blazor.Interfaces;

public interface IStatusServices
{
    Task<Statuses[]> GetAllItems();

}
