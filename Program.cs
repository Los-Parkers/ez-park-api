using ez_park_platform.EzPark.Application.Internal.CommandServices;
using ez_park_platform.EzPark.Application.Internal.QueryServices;
using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using ez_park_platform.Users.Domain.Repositories;
using ez_park_platform.Users.Domain.Services;
using ez_park_platform.Users.Infraestructure.Persistance.EFC.Repositories;
using ez_park_platform.Parkings.Domain.Repositories;
using ez_park_platform.Parkings.Domain.Services;
using ez_park_platform.Parkings.Infraestructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
        {
            if (builder.Environment.IsDevelopment())
            {
                options
                    .UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
            else if (builder.Environment.IsProduction())
            {
                options
                    .UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
        }
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(
    option =>
    {
        option.Conventions.Add(new KebabCaseRouteNamingConvention());
    });

// Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();

// Parkings Bounded Context Configuration
builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
builder.Services.AddScoped<IParkingCommandService, ParkingCommandService>();
builder.Services.AddScoped<IParkingQueryService, ParkingQueryService>();

//Configure database Context and Logging Levels
var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
