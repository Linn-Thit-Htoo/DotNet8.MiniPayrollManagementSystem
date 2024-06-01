using DotNet8.MiniPayrollManagementSystem.Api.Features.Employee;
using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Employee;
using DotNet8.MiniPayrollManagementSystem.DbService.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.MiniPayrollManagementSystem.Api.Services;

public static class ModularService
{
    public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContextServices(builder);
        services.AddMediatRService();
        services.AddDataAccessServices();
        services.AddBusinessLogicServices();
        services.AddRepositoryServices();
        services.AddJsonServices();
        return services;
    }

    #region Add Business Logic Services

    private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<BL_Employee>();
        return services;
    }

    #endregion

    #region Add Data Access Services

    private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<DA_Employee>();
        return services;
    }

    #endregion

    #region MyRegion

    #endregion
    private static IServiceCollection AddDbContextServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        }, ServiceLifetime.Transient);

        return services;
    }

    private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;
    }

    private static IServiceCollection AddJsonServices(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
        return services;
    }

    private static IServiceCollection AddMediatRService(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));
        return services;
    }
}