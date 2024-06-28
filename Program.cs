using ez_park_platform.EzPark.Application.Internal.CommandServices;
using ez_park_platform.EzPark.Application.Internal.QueryServices;
using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories;
using ez_park_platform.Authentication.Domain.Repositories;
using ez_park_platform.Authentication.Domain.Services;
using ez_park_platform.Authentication.Infraestructure.Persistance.EFC.Repositories;
using ez_park_platform.ParkingManagement.Domain.Repositories;
using ez_park_platform.ParkingManagement.Domain.Services;
using ez_park_platform.ParkingManagement.Infraestructure.Persistance.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ez_park_platform.Reservations.Domain.Repositories;
using ez_park_platform.Reservations.Infraestructure.EFC.Repositories;
using ez_park_platform.Reservations.Domain.Services;
using ez_park_platform.Reservations.Application.Internal.CommandServices;
using ez_park_platform.Reservations.Application.Internal.QueryServices;

var builder = WebApplication.CreateBuilder(args);

// Add CORS Policy
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", b =>
{
    b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Connection String
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

// Authentication Bounded Context Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();

// Parkings Bounded Context Configuration
builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
builder.Services.AddScoped<IParkingCommandService, ParkingCommandService>();
builder.Services.AddScoped<IParkingQueryService, ParkingQueryService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewCommandService, ReviewCommandService>();
builder.Services.AddScoped<IReviewQueryService, ReviewQueryService>();

// Reservations Bounded Context Configuration
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingCommandService, BookingComandService>();
builder.Services.AddScoped<IBookingQueryService, BookingQueryService>();


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
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("MyPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
