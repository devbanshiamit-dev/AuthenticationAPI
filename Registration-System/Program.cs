using Microsoft.EntityFrameworkCore;
using Registration_System.Data;
using Registration_System.Middleware;
using Registration_System.Repo;
using Registration_System.Services;
//using Microsoft.IdentityModel.Logging;

//IdentityModelEventSource.ShowPII = true;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Console.WriteLine($"JWT Key: {builder.Configuration["Jwt:Key"]}");
Console.WriteLine($"Length: {builder.Configuration["Jwt:Key"]?.Length}");

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IJwtMethods, JwtMethods>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddProblemDetails();
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("ReactPolicy", policy =>
//    {
//        policy.WithOrigins("http://localhost:5173")
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")); // Now Empty
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("ReactPolicy");

app.UseExceptionHandler();

app.UseMiddleware<AuthenticationMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
