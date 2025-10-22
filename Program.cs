using ApiEscala.Database;
using ApiEscala.Exceptions;
using ApiEscala.Middlewares;
using ApiEscala.Modules.Auth;
using ApiEscala.Modules.Guard;
using ApiEscala.Modules.Member;
using ApiEscala.Modules.Ministry;
using ApiEscala.Modules.Schedule;
using ApiEscala.Modules.Users;
using ApiEscala.Utils;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder
    .Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAndHandleErrorsFilter>();
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("*") // ou "*", se quiser liberar geral (não recomendado)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//Setup da api
builder.Services.AddHttpContextAccessor();

//Modulos Genéricos
builder.Services.AddUserModule();
builder.Services.AddMemberModule();
builder.Services.AddScheduleModule();
builder.Services.AddMinistryModule();
builder.Services.AddUserModule();

//Auth
builder.Services.AddAuthModule();
builder.Services.AddGuardModule();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseGuardModule();

app.UseMiddleware<JsonExceptionHandlingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
