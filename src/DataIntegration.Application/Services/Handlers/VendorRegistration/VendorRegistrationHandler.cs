using DataIntegration.Application.DTOs.VendorRegistration;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules.CompanyProfile;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataIntegration.Application.Services.Handlers.VendorRegistration
{
    public class VendorRegistrationHandler : IMessageHandler
    {
        private readonly IMessagePublisher _publisher;
        private readonly IServiceScopeFactory _scopeFactory;
        public VendorRegistrationHandler(IMessagePublisher publisher, IServiceScopeFactory scopeFactory)
        {
            _publisher = publisher;
            _scopeFactory = scopeFactory;
        }

        public async Task HandleAsync(string message)
        {
            using var scope = _scopeFactory.CreateScope();
            //var formProgressService = scope.ServiceProvider.GetRequiredService<IFormProgressService>();

            var stgVendorRegistrationDataService = scope.ServiceProvider.GetRequiredService<IstgVendorRegistrationDataService>();

            try
            {
                // Deserialisasi JSON ke List<FormProgress>
                var data = JsonConvert.DeserializeObject<List<CompanyProfileWrapperDto>>(message);
                if (data == null || !data.Any())
                {
                    Console.WriteLine("[VendorRegistration] Warning: Received empty or invalid JSON data.");
                    return;
                }

                var returnData = new List<FormProgress>();

                foreach (var item in data)
                {
                    try
                    {
                        var existingData = (await stgVendorRegistrationDataService.GetListAsync(filter : f=> f.ID == item.CompanyProfile.Company.ID).ConfigureAwait(false)).FirstOrDefault();
                        if (existingData == null)
                        {
                            //INSERT
                            await stgVendorRegistrationDataService.AddAsync
                                (
                                    new stgVendorRegistrationData()
                                    {
                                        ID = item.CompanyProfile.Company.ID,
                                        JsonString = JsonConvert.SerializeObject(item),
                                        IsProcessed = false,
                                        CreatedBy = "DataIntegration",
                                        CreatedDate = DateTime.Now,
                                        IsActive = true
                                    }
                                ).ConfigureAwait(false);
                        }

                        else
                        {
                            existingData.JsonString = JsonConvert.SerializeObject(item);
                            existingData.IsProcessed = false;
                            existingData.UpdatedBy = "DataIntegration";
                            existingData.UpdatedDate = DateTime.Now;
                            await stgVendorRegistrationDataService.UpdateAsync(existingData).ConfigureAwait(false);
                        }

                        returnData.Add(
                            new FormProgress(){
                                CompanyID = item.CompanyProfile.Company.ID,
                                CurrentModule = 0,
                                IsActive = false,
                                IsSync = true,
                                DateTimeSync = DateTime.Now,
                                CreatedBy = "",
                                CreatedDate = DateTime.Now,
                                UpdatedBy = null,
                                UpdatedDate = null
                            }
                        );
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[VendorRegistration] Error processing CompanyID={item.CompanyProfile.Company.ID}: {ex.Message}");
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"[VendorRegistration] Inner Exception: {ex.InnerException.Message}");
                        }
                    }
                }
                var updatedJson = JsonConvert.SerializeObject(returnData, Formatting.Indented);
                Console.WriteLine($"[VendorRegistration] Updated FormProgress JSON: {updatedJson}");

                await Task.Run(() => _publisher.Publish("vendorregistration.data.status", updatedJson));
                await Task.CompletedTask;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
