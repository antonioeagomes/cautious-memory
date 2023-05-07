using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Bus;
using Transfer.Domain.EventHandlers;
using Transfer.Domain.Events;

namespace Api.Extensions
{
    public static class EventBusExtensions
    {
        public static IServiceCollection RegisterEventBus(this IServiceCollection services)
        {
            var eventBus = services.BuildServiceProvider().GetRequiredService<IEventBus>();

            eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();

            return services;
        }
        
    }
}