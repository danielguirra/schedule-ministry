namespace ApiEscala.Modules.Schedule;

public static class ScheduleModule
{
    public static IServiceCollection AddScheduleModule(this IServiceCollection services)
    {
        services.AddScoped<ScheduleService>();
        services.AddControllers().AddApplicationPart(typeof(ScheduleController).Assembly);
        return services;
    }
}
