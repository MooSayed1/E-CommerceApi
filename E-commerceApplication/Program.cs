using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistance.Data.Contexts;
using Persistance.Data.DataSeeding;
using Persistance.Repositories;
using Presintation;
using Services;
using Services.Abstraction.Interfaces;
using Services.MappingProfiles;

namespace E_commerceApplication;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );

        builder.Services.AddScoped<IDbInitializer, DbInitializer>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IServiceManager, ServiceManager>();
        builder.Services.AddAutoMapper(cfg => { }, typeof(ProductProfile).Assembly);
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        // Initialize the database
        await InitializeDatabaseAsync();

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

        // Initialize the database
        async Task InitializeDatabaseAsync()
        {
            using var scope = app.Services.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbInitializer.InitializeDbAsync();
        }
    }
}