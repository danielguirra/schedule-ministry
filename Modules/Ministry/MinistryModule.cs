namespace ApiEscala.Modules.Ministry;

public static class MinistryModule
{
    public static IServiceCollection AddMinistryModule(this IServiceCollection services)
    {
        services.AddScoped<MinistryService>();
        services.AddControllers().AddApplicationPart(typeof(MinistryController).Assembly);
        return services;
    }
}
