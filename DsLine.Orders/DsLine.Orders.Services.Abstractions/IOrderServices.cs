using DsLine.Orders.Models.EntitiesDto;
using System.Threading.Tasks;

namespace DsLine.Orders.Services.Abstractions
{
    public interface IOrderServices
    {
         Task<object> CreateOrderAsync(OrderDto order);
    }
}
