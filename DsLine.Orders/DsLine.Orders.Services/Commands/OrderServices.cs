using DsLine.Core.RabbitMQ;
using DsLine.Orders.Models.EntitiesDto;
using DsLine.Orders.Services.Abstractions;
using DsLine.Orders.Services.IntegrationsMessages.Events;
using System;
using System.Threading.Tasks;

namespace DsLine.Orders.Services.Commands
{
    public class OrderServices : IOrderServices
    {
        private readonly IBusPublisher _busPublisher;


        public OrderServices(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        public async Task<object> CreateOrderAsync(OrderDto order)
        {
            var @event = new CreateOrderEvent(new System.Guid(), order.ProductId, order.Quantity);


            //var gui = Guid.NewGuid();
            //_ = _busPublisher.PublishAsync(@event, CorrelationContext.Create<CreateOrderEvent>(gui, gui, gui, "origen", gui.ToString(), "", "", ""));

            await _busPublisher.PublishAsync(new CreateOrderEvent(new System.Guid(), order.ProductId, order.Quantity), null);
            return null;
        }
    }
}
