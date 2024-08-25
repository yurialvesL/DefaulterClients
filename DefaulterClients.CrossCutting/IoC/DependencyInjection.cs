using DefaulterClients.Application.Interfaces;
using DefaulterClients.Application.Mappings;
using DefaulterClients.Application.Services;
using DefaulterClients.Domain.Interfaces;
using DefaulterClients.Infraestructure.Context;
using DefaulterClients.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DefaulterClients.CrossCutting.IoC;
public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
       
        //DB
        string connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString));

        //services
        services.AddScoped<ITokenService,TokenService>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<IClientService,ClientService>();
        services.AddScoped<IBillingService,BillingService>();

        //repositories
        services.AddScoped<IUserRepository,UserRepository>();
        services.AddScoped<IBillingRepository,BillingRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();


        //AutoMapper
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
