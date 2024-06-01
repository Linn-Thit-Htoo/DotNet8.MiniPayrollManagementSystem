using DotNet8.MiniPayrollManagementSystem.Api.Features.Employee;
using DotNet8.MiniPayrollManagementSystem.Api.Features.Payroll;
using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Employee;
using DotNet8.MiniPayrollManagementSystem.Api.Repositories.Payroll;
using DotNet8.MiniPayrollManagementSystem.Api.Services.Employee;
using DotNet8.MiniPayrollManagementSystem.Api.Validators.Employee;
using DotNet8.MiniPayrollManagementSystem.Api.Validators.Payroll;
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
        services.AddCustomServices();
        services.AddValidatorService();
        return services;
    }

    #region Add Business Logic Services

    private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<BL_Employee>();
        services.AddScoped<BL_Payroll>();
        return services;
    }

    #endregion

    #region Add Data Access Services

    private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<DA_Employee>();
        services.AddScoped<DA_Payroll>();
        return services;
    }

    #endregion

    #region Add Db Context Services

    private static IServiceCollection AddDbContextServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
        }, ServiceLifetime.Transient);

        return services;
    }

    #endregion

    #region Add Repository Services

    private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPayrollRepository, PayrollRepository>();
        return services;
    }

    #endregion

    #region Add Json Services

    private static IServiceCollection AddJsonServices(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
        return services;
    }

    #endregion

    #region Add MediatR Service

    private static IServiceCollection AddMediatRService(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));
        return services;
    }

    #endregion

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<GenerateEmployeeCodeService>();
        services.AddScoped<DapperService>();
        return services;
    }

    private static IServiceCollection AddValidatorService(this IServiceCollection services)
    {
        services.AddScoped<EmployeeValidator>();
        services.AddScoped<PayrollValidator>();
        return services;
    }
}