using DataIntegration.Application.DTOs.ETender.Auction.MaterialScrapped;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using DataIntegration.Application.Interfaces.Modules.Workflow;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DataIntegration.Application.Services.Handlers.ETender.Auction.MaterialScrapped
{
    public class FinalHandler : IMessageHandler
    {
        private readonly IMessagePublisher _publisher;
        private readonly IServiceScopeFactory _scopeFactory;
        public FinalHandler(IMessagePublisher publisher, IServiceScopeFactory scopeFactory)
        {
            _publisher = publisher;
            _scopeFactory = scopeFactory;
        }

        public async Task HandleAsync(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            var data = JsonConvert.DeserializeObject<List<MaterialScrappedSubmitFinal>>(message);
            //Loop semua ID -> Set Sync Information(status,date)
            var service = scope.ServiceProvider.GetRequiredService<ItrxPRCAuctionSystemAssignVendorFinalOfferingPriceService>();
            var logservice = scope.ServiceProvider.GetRequiredService<IlogPRCAuctionSystemAssignVendorFinalOfferingPriceService>();
            var assignvendorservice = scope.ServiceProvider.GetRequiredService<ItrxPRCAuctionSystemAssignVendorService>();
            var logassignvendorservice = scope.ServiceProvider.GetRequiredService<IlogPRCAuctionSystemAssignVendorService>();
            //var workflowService = scope.ServiceProvider.GetRequiredService<IWorkflowService>();
            foreach (var item in data)
            {
                try
                {
                    var recordCount = await service.GetCountAsync(filter: f => f.trxPRCAuctionSystemAssignVendorID == item.FinalID).ConfigureAwait(false);
                    /*
                    if(recordCount > 0)
                    {
                        var record = (await service.GetListAsync(filter: f => f.trxPRCAuctionSystemAssignVendorID == item.FinalID).ConfigureAwait(false)).FirstOrDefault();
                        record.FinalOfferPrice = item.FinalPrice;
                        record.SubmitDate = item.FinalDate;
                        record.SubmitBy = "ETender";
                        record.CreatedBy = "ETender";
                        record.CreatedDate = DateTime.Now;

                        logPRCAuctionSystemAssignVendorFinalOfferingPrice logOffer = new logPRCAuctionSystemAssignVendorFinalOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorFinalOfferingPriceID = record.ID,
                            trxPRCAuctionSystemAssignVendorID = record.trxPRCAuctionSystemAssignVendorID,
                            FinalOfferPrice = record.FinalOfferPrice,
                            SubmitDate = record.SubmitDate,
                            SubmitBy = record.SubmitBy,
                            CreatedBy = record.CreatedBy,
                            CreatedDate = record.CreatedDate,
                            UpdatedBy = record.UpdatedBy,
                            UpdatedDate = record.UpdatedDate,
                        };

                        await service.UpdateAsync(record).ConfigureAwait(false);
                        await logservice.AddAsync(logOffer).ConfigureAwait(false);

                        var recordAssign = (await assignvendorservice.GetByPKAsync(long.Parse(item.FinalID.ToString())).ConfigureAwait(false));
                        recordAssign.mstPRCAuctionSystemStatusSubmitPriceID = 3;
                        recordAssign.UpdatedBy = record.SubmitBy;
                        recordAssign.UpdatedDate = record.SubmitDate;

                        logPRCAuctionSystemAssignVendor logAssign = new logPRCAuctionSystemAssignVendor()
                        {
                            trxPRCAuctionSystemAssignVendorID = recordAssign.ID,
                            trxPRCAuctionSystemHeaderID = recordAssign.trxPRCAuctionSystemHeaderID,
                            mstPRCAuctionSystemVendorTypeID = recordAssign.mstPRCAuctionSystemVendorTypeID,
                            mstPRCAuctionSystemVendorListingID = recordAssign.mstPRCAuctionSystemVendorListingID,
                            mstPRCAuctionSystemVendorNonListingID = recordAssign.mstPRCAuctionSystemVendorNonListingID,
                            mstPRCAuctionSystemStatusSubmitPriceID = recordAssign.mstPRCAuctionSystemStatusSubmitPriceID,
                            mstPRCAuctionSystemVendorRecommendationTypeID = recordAssign.mstPRCAuctionSystemVendorRecommendationTypeID,
                            IsDelete = recordAssign.IsDelete,
                            CreatedBy = recordAssign.CreatedBy,
                            CreatedDate = recordAssign.CreatedDate,
                            UpdatedBy = recordAssign.UpdatedBy,
                            UpdatedDate = recordAssign.UpdatedDate
                        };
                        await assignvendorservice.UpdateAsync(recordAssign).ConfigureAwait(false);
                        await logassignvendorservice.AddAsync(logAssign).ConfigureAwait(false);
                    }
                    else
                    {
                        var newRecord = new trxPRCAuctionSystemAssignVendorFinalOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorID = item.FinalID,
                            FinalOfferPrice = item.FinalPrice,
                            SubmitDate = item.FinalDate,
                            SubmitBy = "ETender",
                            CreatedBy = "ETender",
                            CreatedDate = DateTime.Now
                        };

                        await service.AddAsync(newRecord).ConfigureAwait(false);

                        var datarecord = await service.GetListAsync(filter: x => x.trxPRCAuctionSystemAssignVendorID == item.FinalID).ConfigureAwait(false);
                        var record = datarecord.FirstOrDefault();
                        logPRCAuctionSystemAssignVendorFinalOfferingPrice logOffer = new logPRCAuctionSystemAssignVendorFinalOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorFinalOfferingPriceID = record.ID,
                            trxPRCAuctionSystemAssignVendorID = record.trxPRCAuctionSystemAssignVendorID,
                            FinalOfferPrice = record.FinalOfferPrice,
                            SubmitDate = record.SubmitDate,
                            SubmitBy = record.SubmitBy,
                            CreatedBy = record.CreatedBy,
                            CreatedDate = record.CreatedDate,
                            UpdatedBy = record.UpdatedBy,
                            UpdatedDate = record.UpdatedDate,
                        };
                        await logservice.AddAsync(logOffer).ConfigureAwait(false);

                        var recordAssign = (await assignvendorservice.GetByPKAsync(long.Parse(item.FinalID.ToString())).ConfigureAwait(false));
                        recordAssign.mstPRCAuctionSystemStatusSubmitPriceID = 1;
                        recordAssign.UpdatedBy = record.SubmitBy;
                        recordAssign.UpdatedDate = record.SubmitDate;

                        logPRCAuctionSystemAssignVendor logAssign = new logPRCAuctionSystemAssignVendor()
                        {
                            trxPRCAuctionSystemAssignVendorID = recordAssign.ID,
                            trxPRCAuctionSystemHeaderID = recordAssign.trxPRCAuctionSystemHeaderID,
                            mstPRCAuctionSystemVendorTypeID = recordAssign.mstPRCAuctionSystemVendorTypeID,
                            mstPRCAuctionSystemVendorListingID = recordAssign.mstPRCAuctionSystemVendorListingID,
                            mstPRCAuctionSystemVendorNonListingID = recordAssign.mstPRCAuctionSystemVendorNonListingID,
                            mstPRCAuctionSystemStatusSubmitPriceID = recordAssign.mstPRCAuctionSystemStatusSubmitPriceID,
                            mstPRCAuctionSystemVendorRecommendationTypeID = recordAssign.mstPRCAuctionSystemVendorRecommendationTypeID,
                            IsDelete = recordAssign.IsDelete,
                            CreatedBy = recordAssign.CreatedBy,
                            CreatedDate = recordAssign.CreatedDate,
                            UpdatedBy = recordAssign.UpdatedBy,
                            UpdatedDate = recordAssign.UpdatedDate
                        };
                        await assignvendorservice.UpdateAsync(recordAssign).ConfigureAwait(false);
                        await logassignvendorservice.AddAsync(logAssign).ConfigureAwait(false);
                    }
                    */
                    if (recordCount == 0)
                    {
                        var newRecord = new trxPRCAuctionSystemAssignVendorFinalOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorID = item.FinalID,
                            FinalOfferPrice = item.FinalPrice,
                            SubmitDate = item.FinalDate,
                            SubmitBy = "ETender",
                            CreatedBy = "ETender",
                            CreatedDate = DateTime.Now
                        };

                        await service.AddAsync(newRecord).ConfigureAwait(false);

                        var datarecord = await service.GetListAsync(filter: x => x.trxPRCAuctionSystemAssignVendorID == item.FinalID).ConfigureAwait(false);
                        var record = datarecord.FirstOrDefault();
                        logPRCAuctionSystemAssignVendorFinalOfferingPrice logOffer = new logPRCAuctionSystemAssignVendorFinalOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorFinalOfferingPriceID = record.ID,
                            trxPRCAuctionSystemAssignVendorID = record.trxPRCAuctionSystemAssignVendorID,
                            FinalOfferPrice = record.FinalOfferPrice,
                            SubmitDate = record.SubmitDate,
                            SubmitBy = record.SubmitBy,
                            CreatedBy = record.CreatedBy,
                            CreatedDate = record.CreatedDate,
                            UpdatedBy = record.UpdatedBy,
                            UpdatedDate = record.UpdatedDate,
                        };
                        await logservice.AddAsync(logOffer).ConfigureAwait(false);

                        var recordAssign = (await assignvendorservice.GetByPKAsync(long.Parse(item.FinalID.ToString())).ConfigureAwait(false));
                        recordAssign.mstPRCAuctionSystemStatusSubmitPriceID = 3;
                        recordAssign.UpdatedBy = record.SubmitBy;
                        recordAssign.UpdatedDate = record.SubmitDate;

                        logPRCAuctionSystemAssignVendor logAssign = new logPRCAuctionSystemAssignVendor()
                        {
                            trxPRCAuctionSystemAssignVendorID = recordAssign.ID,
                            trxPRCAuctionSystemHeaderID = recordAssign.trxPRCAuctionSystemHeaderID,
                            mstPRCAuctionSystemVendorTypeID = recordAssign.mstPRCAuctionSystemVendorTypeID,
                            mstPRCAuctionSystemVendorListingID = recordAssign.mstPRCAuctionSystemVendorListingID,
                            mstPRCAuctionSystemVendorNonListingID = recordAssign.mstPRCAuctionSystemVendorNonListingID,
                            mstPRCAuctionSystemStatusSubmitPriceID = recordAssign.mstPRCAuctionSystemStatusSubmitPriceID,
                            mstPRCAuctionSystemVendorRecommendationTypeID = recordAssign.mstPRCAuctionSystemVendorRecommendationTypeID,
                            IsDelete = recordAssign.IsDelete,
                            CreatedBy = recordAssign.CreatedBy,
                            CreatedDate = recordAssign.CreatedDate,
                            UpdatedBy = recordAssign.UpdatedBy,
                            UpdatedDate = recordAssign.UpdatedDate
                        };
                        await assignvendorservice.UpdateAsync(recordAssign).ConfigureAwait(false);
                        await logassignvendorservice.AddAsync(logAssign).ConfigureAwait(false);
                    }
                    item.IsSync = true;
                    item.SyncDate = DateTime.Now;
                }
                catch
                {

                }
            }
            Console.WriteLine($"[Final] Processing: {message}");
            var update = JsonConvert.SerializeObject(data);
            await Task.Run(() => _publisher.Publish("materialscrapped.final.status", update));
            await Task.CompletedTask;
        }
    }
}
