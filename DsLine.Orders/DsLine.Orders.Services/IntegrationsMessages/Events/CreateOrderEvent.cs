using DsLine.Core.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DsLine.Orders.Services.IntegrationsMessages.Events
{
    public class CreateOrderEvent : IEvent
    {
        public Guid Id { get; }
        public int CustomerId { get; }
        public int Products { get; }

        [JsonConstructor]
        public CreateOrderEvent(Guid id, int customerId, int products)
        {
            Id = id;
            CustomerId = customerId;
            Products = products;
        }
    }
}
