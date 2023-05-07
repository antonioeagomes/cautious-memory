using Banking.Application.Interfaces;
using Banking.Application.Services;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.CommandHandlers;
using Banking.Domain.Commands;
using Domain.Core.Bus;
using Banking.Domain.Interfaces;
using Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Transfer.Data.Context;
using Transfer.Domain.Interfaces;
using Transfer.Application.Services;
using TransferApplication.Interfaces;
using Transfer.Data.Repository;
using Transfer.Domain.Events;
using Transfer.Domain.EventHandlers;

namespace Infra.IoC;

public static class DependencyContainer
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Data
        services.AddDbContext<BankingDbContext>();
        services.AddDbContext<TransferDbContext>();

        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<ITransferRepository, TransferRepository>();

        // Events
        services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

        // Domain
        services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

        // Application
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<ITransferService, TransferService>();

         // Domain Bus
        services.AddTransient<IEventBus, EventBus>();

    }
}
