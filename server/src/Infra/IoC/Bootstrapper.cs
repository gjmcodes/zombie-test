using System;
using Application.Resources.Services;
using Domain.Core.Operations;
using Domain.Zombie.Resources.Commands;
using Domain.Zombie.Resources.Commands.Operations;
using Domain.Zombie.Resources.Repositories;
using Infra.Data.Core.Contexts;
using Infra.Data.Core.Repositories.Resources;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterDatabases(services);
            RegisterCommands(services);
            RegisterAppServices(services);
            
            return services;
        }

        static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            //Persistent
            services.AddScoped<IResourcePersistentRepository, ResourcePersistentRepository>();

            //Readonly
            services.AddScoped<IResourceReadOnlyRepository, ResourceReadOnlyRepository>();

            return services;
        }

        static IServiceCollection RegisterDatabases(IServiceCollection services)
        {
            services.AddDbContext<ZombieDbContext>(opt =>
             opt.UseInMemoryDatabase(nameof(ZombieDbContext)));

            return services;
        }

        static IServiceCollection RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddResourceCommand, CommandResult>, ResourceCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateResourceCommand, CommandResult>, ResourceCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteResourceCommand, CommandResult>, ResourceCommandHandler>();


            return services;
        }

        static IServiceCollection RegisterAppServices(IServiceCollection services)
        {
            services.AddScoped<IResourceAppService, ResourceAppService>();
            
            return services;
        }
    }
}