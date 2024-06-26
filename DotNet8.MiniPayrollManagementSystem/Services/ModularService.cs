namespace DotNet8.MiniPayrollManagementSystem.Api.Services;

public static class ModularService
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        services
            .AddDbContextServices(builder)
            .AddMediatRService()
            .AddDataAccessServices()
            .AddBusinessLogicServices()
            .AddRepositoryServices()
            .AddJsonServices()
            .AddCustomServices()
            .AddValidatorService();

        return services;
    }

    #region Add Business Logic Services

    private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<BL_Employee>().AddScoped<BL_Payroll>();

        return services;
    }

    #endregion

    #region Add Data Access Services

    private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<DA_Employee>().AddScoped<DA_Payroll>();

        return services;
    }

    #endregion

    #region Add Db Context Services

    private static IServiceCollection AddDbContextServices(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        builder.Services.AddDbContext<AppDbContext>(
            opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            },
            ServiceLifetime.Transient
        );

        return services;
    }

    #endregion

    #region Add Repository Services

    private static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services
            .AddScoped<IEmployeeRepository, EmployeeRepository>()
            .AddScoped<IPayrollRepository, PayrollRepository>();

        return services;
    }

    #endregion

    #region Add Json Services

    private static IServiceCollection AddJsonServices(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(opt =>
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
        services.AddScoped<GenerateEmployeeCodeService>().AddScoped<DapperService>();

        return services;
    }

    private static IServiceCollection AddValidatorService(this IServiceCollection services)
    {
        services.AddScoped<EmployeeValidator>().AddScoped<PayrollValidator>();

        return services;
    }
}
