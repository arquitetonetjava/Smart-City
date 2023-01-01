using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;
using SmartTeste.Application.Interfaces;
using SmartTeste.Application.Services;
using SmartTeste.Domain.Commands;
using SmartTeste.Domain.Core.Events;
using SmartTeste.Domain.Events;
using SmartTeste.Domain.Interfaces;
using SmartTeste.Infra.CrossCutting.Bus;
using SmartTeste.Infra.Data.Context;
using SmartTeste.Infra.Data.EventSourcing;
using SmartTeste.Infra.Data.Repository;
using SmartTeste.Infra.Data.Repository.EventSourcing;

namespace SmartTeste.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IPeopleAppService, PeopleAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<PeopleRegisteredEvent>, PeopleEventHandler>();
            services.AddScoped<INotificationHandler<PeopleUpdatedEvent>, PeopleEventHandler>();
            services.AddScoped<INotificationHandler<PeopleRemovedEvent>, PeopleEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewPeopleCommand, ValidationResult>, PeopleCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePeopleCommand, ValidationResult>, PeopleCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePeopleCommand, ValidationResult>, PeopleCommandHandler>();

            // Infra - Data
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<SmartContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}
