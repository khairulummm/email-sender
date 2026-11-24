using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DataIntegration.Infrastructure;
using DataIntegration.Infrastructure.Data;
using DataIntegration.Infrastructure.Interfaces;
using DataIntegration.Infrastructure.Repositories;
using DataIntegration.Application.DependencyInjection;
using DataIntegration.API.Middleware;
using TickerQ.DependencyInjection;
using TickerQ.Dashboard.DependencyInjection;
using DataIntegration.Application.Services.Job;
using DataIntegration.Application.Models;
using DataIntegration.Application.Model;
using DataIntegration.Application.Services.Job.BUS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.ClearProviders(); // Opsional: clear provider default
builder.Logging.AddConsole();     // Ini wajib agar tampil di console Docker

builder.Services.AddDbContextFactory<CoreDbContext>(options =>
    options.UseSqlServer(CryptoHelper.Decrypt(builder.Configuration.GetConnectionString("TBIGSYSDB01_TBiGSys"))));

builder.Services.Configure<RabbitMQSettings>(
    builder.Configuration.GetSection("RabbitMQ"));

builder.Services.Configure<Dictionary<string, string>>(
    builder.Configuration.GetSection("appSettings"));

builder.Services.AddSingleton<ICoreDbContextFactory, CoreDbContextFactory>();
builder.Services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Registrasi service menggunakan auto-registration dari assembly System.Application
// Pastikan reference ke project System.Application sudah ada
builder.Services.AddTickerQ(options =>
{
    options.SetMaxConcurrency(4);
    options.UpdateMissedJobCheckDelay(TimeSpan.FromSeconds(2));
    // Define the DbContext to use for storing Tickers.
    //options.AddOperationalStore<CoreDbContext>(efOpt =>
    //{
    //    efOpt.UseModelCustomizerForMigrations(); // Applies custom model customization only during EF Core migrations
    //    efOpt.CancelMissedTickersOnApplicationRestart(); // Useful in distributed mode
    //}); // Enables EF-backed storage
    options.SetInstanceIdentifier("TickerQ");
    options.AddDashboard(basePath: "/TickerQ");
});

var appAssembly = Assembly.Load("DataIntegration.Application");
builder.Services.AddServicesByConvention(appAssembly, "DataIntegration.Application.Services");
builder.Services.AddScoped<TravelDutiesJob>();



//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<StandardResponseFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Registrasi Middleware

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() ||
    app.Environment.IsEnvironment("SIT") ||
    app.Environment.IsEnvironment("UAT"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ApiExceptionMiddleware>();
app.UseAuthorization();
app.UseTickerQ(); // Activates job processor

app.MapControllers();

app.Run();