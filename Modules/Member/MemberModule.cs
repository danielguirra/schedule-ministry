namespace ApiEscala.Modules.Member;

public static class MemberModule
{
    public static IServiceCollection AddMemberModule(this IServiceCollection services)
    {
        services.AddScoped<MemberService>();
        services.AddControllers().AddApplicationPart(typeof(MemberController).Assembly);
        return services;
    }
}
