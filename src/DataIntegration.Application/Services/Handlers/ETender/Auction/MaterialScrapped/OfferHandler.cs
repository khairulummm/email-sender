using DataIntegration.Application.DTOs.ETender.Auction.MaterialScrapped;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DataIntegration.Application.Services.Handlers.ETender.Auction.MaterialScrapped
{
    public class OfferHandler : IMessageHandler
	{
        private readonly IMessagePublisher _publisher;
        private readonly IServiceScopeFactory _scopeFactory;
        public OfferHandler(IMessagePublisher publisher, IServiceScopeFactory scopeFactory)
        {
            _publisher = publisher;
            _scopeFactory = scopeFactory;
        }

        public async Task HandleAsync(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            var data = JsonConvert.DeserializeObject<List<MaterialScrappedSubmitOffer>>(message);
            //Loop semua ID -> Set Sync Information(status,date)
            var service = scope.ServiceProvider.GetRequiredService<ItrxPRCAuctionSystemAssignVendorOfferingPriceService>();
            var logservice = scope.ServiceProvider.GetRequiredService<IlogPRCAuctionSystemAssignVendorOfferingPriceService>();
            var assignvendorservice = scope.ServiceProvider.GetRequiredService<ItrxPRCAuctionSystemAssignVendorService>();
            var logassignvendorservice = scope.ServiceProvider.GetRequiredService<IlogPRCAuctionSystemAssignVendorService>();
            foreach (var item in data)
            {
                try
                {
                    var recordCount = await service.GetCountAsync(filter: f => f.trxPRCAuctionSystemAssignVendorID == item.OfferID).ConfigureAwait(false);
                    /*
                    if (recordCount > 0)
                    {
                        var record = (await service.GetListAsync(filter: f => f.trxPRCAuctionSystemAssignVendorID == item.OfferID).ConfigureAwait(false)).FirstOrDefault();
                        record.OfferPrice = item.OfferPrice;
                        record.SubmitDate = item.CreatedDate;
                        record.SubmitBy = "ETender";
                        record.UpdatedBy = "ETender";
                        record.UpdatedDate = DateTime.Now;

                        logPRCAuctionSystemAssignVendorOfferingPrice logOffer = new logPRCAuctionSystemAssignVendorOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorOfferingPriceID = record.ID,
                            trxPRCAuctionSystemAssignVendorID = record.trxPRCAuctionSystemAssignVendorID,
                            OfferPrice = record.OfferPrice,
                            SubmitDate = record.SubmitDate,
                            SubmitBy = record.SubmitBy,
                            CreatedBy = record.CreatedBy,
                            CreatedDate = record.CreatedDate,
                            UpdatedBy = record.UpdatedBy,
                            UpdatedDate = record.UpdatedDate,
                        };
                        await service.UpdateAsync(record).ConfigureAwait(false);
                        await logservice.AddAsync(logOffer).ConfigureAwait(false);

                        var recordAssign = (await assignvendorservice.GetByPKAsync(long.Parse(item.OfferID.ToString())).ConfigureAwait(false));
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
                    else
                    {
                        var newRecord = new trxPRCAuctionSystemAssignVendorOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorID = item.OfferID,
                            OfferPrice = item.OfferPrice,
                            SubmitDate = item.OfferDate,
                            SubmitBy = "ETender",
                            CreatedBy = "ETender",
                            CreatedDate = DateTime.Now
                        };
                        await service.AddAsync(newRecord).ConfigureAwait(false);
                        var datarecord = await service.GetListAsync(filter: x => x.trxPRCAuctionSystemAssignVendorID == item.OfferID).ConfigureAwait(false);
                        var record = datarecord.FirstOrDefault();
                        logPRCAuctionSystemAssignVendorOfferingPrice logOffer = new logPRCAuctionSystemAssignVendorOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorOfferingPriceID = record.ID,
                            trxPRCAuctionSystemAssignVendorID = record.trxPRCAuctionSystemAssignVendorID,
                            OfferPrice = record.OfferPrice,
                            SubmitDate = record.SubmitDate,
                            SubmitBy = record.SubmitBy,
                            CreatedBy = record.CreatedBy,
                            CreatedDate = record.CreatedDate,
                            UpdatedBy = record.UpdatedBy,
                            UpdatedDate = record.UpdatedDate,
                        };
                        await logservice.AddAsync(logOffer).ConfigureAwait(false);

                        var recordAssign = (await assignvendorservice.GetByPKAsync(long.Parse(item.OfferID.ToString())).ConfigureAwait(false));
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
                        var newRecord = new trxPRCAuctionSystemAssignVendorOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorID = item.OfferID,
                            OfferPrice = item.OfferPrice,
                            SubmitDate = item.OfferDate,
                            SubmitBy = "ETender",
                            CreatedBy = "ETender",
                            CreatedDate = DateTime.Now
                        };
                        await service.AddAsync(newRecord).ConfigureAwait(false);
                        var datarecord = await service.GetListAsync(filter: x => x.trxPRCAuctionSystemAssignVendorID == item.OfferID).ConfigureAwait(false);
                        var record = datarecord.FirstOrDefault();
                        logPRCAuctionSystemAssignVendorOfferingPrice logOffer = new logPRCAuctionSystemAssignVendorOfferingPrice()
                        {
                            trxPRCAuctionSystemAssignVendorOfferingPriceID = record.ID,
                            trxPRCAuctionSystemAssignVendorID = record.trxPRCAuctionSystemAssignVendorID,
                            OfferPrice = record.OfferPrice,
                            SubmitDate = record.SubmitDate,
                            SubmitBy = record.SubmitBy,
                            CreatedBy = record.CreatedBy,
                            CreatedDate = record.CreatedDate,
                            UpdatedBy = record.UpdatedBy,
                            UpdatedDate = record.UpdatedDate,
                        };
                        await logservice.AddAsync(logOffer).ConfigureAwait(false);

                        var recordAssign = (await assignvendorservice.GetByPKAsync(long.Parse(item.OfferID.ToString())).ConfigureAwait(false));
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
                    item.IsSync = true;
                    item.SyncDate = DateTime.Now;
                }
                catch
                {

                }
            }
            Console.WriteLine($"[Offer] Processing: {message}");
            var update = JsonConvert.SerializeObject(data);
            await Task.Run(() => _publisher.Publish("materialscrapped.offer.status", update));
            await Task.CompletedTask;
        }
    }
}
