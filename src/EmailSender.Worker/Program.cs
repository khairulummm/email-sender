using DataIntegration.Application.DependencyInjection;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules.CompanyProfile;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using DataIntegration.Application.Models;
using DataIntegration.Application.Services.Handlers.ETender.Auction.FIT;
using DataIntegration.Application.Services.Handlers.ETender.Auction.MaterialScrapped;
using DataIntegration.Application.Services.Handlers.VendorRegistration;
using DataIntegration.Application.Services.Modules.CompanyProfile;
using DataIntegration.Application.Services.Handlers.ETender.SPH.NonNetwork;
using DataIntegration.Application.Services.Modules.MessageBroker;
using DataIntegration.Infrastructure.Data;
using DataIntegration.Infrastructure.Interfaces;
using DataIntegration.Infrastructure.Repositories;
using DataIntegration.Worker;
using System.Reflection;
using DataIntegration.Application.Services.Handlers.ETender.Tender.Aanwijzing;
using DataIntegration.Application.Interfaces.Modules;
using DataIntegration.Application.Services.Modules;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<ICoreDbContextFactory, CoreDbContextFactory>();
builder.Services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IFormProgressService, FormProgressService>();

builder.Services.Configure<RabbitMQSettings>(
    builder.Configuration.GetSection("RabbitMQ"));
builder.Services.Configure<WorkflowSettings>(
    builder.Configuration.GetSection("Workflow"));

var appAssembly = Assembly.Load("DataIntegration.Application");
builder.Services.AddServicesWorkerByConvention(appAssembly, "DataIntegration.Application.Services");

//RabbitMQ
builder.Services.AddSingleton<IMessagePublisher, RabbitMqPublisher>();
builder.Services.AddHostedService<RabbitMqConsumer>();
builder.Services.AddScoped<IEmailService, EmailService>();

// RabbitMQ
//builder.Services.AddSingleton<OfferHandler>();
//builder.Services.AddSingleton<FinalHandler>();
//builder.Services.AddSingleton<TransferHandler>();
//builder.Services.AddSingleton<FITPlanHandler>();
//builder.Services.AddSingleton<FITActualHandler>();
//builder.Services.AddSingleton<VendorRegistrationHandler>();
//builder.Services.AddSingleton<NegotiationHandler>();
builder.Services.AddSingleton<ConfirmationHandler>();

builder.Services.AddSingleton<IDictionary<string, IMessageHandler>>(sp => new Dictionary<string, IMessageHandler>
{
    //{ "materialscrapped.offer.push", sp.GetRequiredService<OfferHandler>() },
    //{ "materialscrapped.final.push", sp.GetRequiredService<FinalHandler>() },
    //{ "materialscrapped.transfer.push", sp.GetRequiredService<TransferHandler>() },
    //{ "fit.schedule.push", sp.GetRequiredService<FITPlanHandler>() },
    //{ "fit.actual.push", sp.GetRequiredService<FITActualHandler>() },
    //{ "vendorregistration.data.push", sp.GetRequiredService<VendorRegistrationHandler>() },
    //{ "sphnonnetwork.negotiation.push", sp.GetRequiredService<NegotiationHandler>() },
    { "tenderaanwijzing.confirmation.push", sp.GetRequiredService<ConfirmationHandler>() }
});

var host = builder.Build();
host.Run();
