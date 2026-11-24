using DataIntegration.Application.DTOs.ETender.Auction.MaterialScrapped;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Handlers;
using DataIntegration.Application.Interfaces.Modules.MessageBroker;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DataIntegration.Application.Services.Handlers.ETender.Auction.MaterialScrapped
{
    public class TransferHandler : IMessageHandler
    {
        private readonly IMessagePublisher _publisher;
        private readonly IServiceScopeFactory _scopeFactory;
        public TransferHandler(IMessagePublisher publisher, IServiceScopeFactory scopeFactory)
        {
            _publisher = publisher;
            _scopeFactory = scopeFactory;
        }

        public async Task HandleAsync(string message)
        {
            using var scope = _scopeFactory.CreateScope();

            var data = JsonConvert.DeserializeObject<List<MaterialScrappedSubmitTransfer>>(message);
            //Loop semua ID -> Set Sync Information(status,date)
            var service = scope.ServiceProvider.GetRequiredService<ItrxPRCAuctionSystemAssignVendorTransferPriceService>();
            var logService = scope.ServiceProvider.GetRequiredService<IlogPRCAuctionSystemAssignVendorTransferPriceService>();           
            foreach (var item in data)
            {
                try
                {

                    var recordCount = await service.GetCountAsync(filter: f => f.trxPRCAuctionSystemAssignVendorID == item.TransferID).ConfigureAwait(false);
                    if (recordCount > 0)
                    {
                        var record = (await service.GetListAsync(filter: f => f.trxPRCAuctionSystemAssignVendorID == item.TransferID).ConfigureAwait(false)).FirstOrDefault();
                        record.mstFINRefundTransactionTypeID = item.TransactionTypeID;
                        record.mstFINRefundTransactionCategory = item.TransactionCategory;
                        record.mstCompanyIDAX = item.CompanyIDAX;
                        record.AccountNumber = item.AccountNumberBank;
                        record.TransferPrice = item.Amount;
                        record.TransferDate = item.TransferDate;
                        record.AdditionalInformation = item.AdditionalInformation;
                        record.SenderName = item.AccountName;
                        record.VendorAccount = item.AccountNumber;
                        record.SubmitDate = item.CreatedDate;
                        record.SubmitBy = "ETender";
                        record.UpdatedBy = "ETender";
                        record.UpdatedDate = DateTime.Now;

                        await service.UpdateAsync(record).ConfigureAwait(false);

                        var dataResult = (await service.GetListAsync(filter: f => f.trxPRCAuctionSystemAssignVendorID == item.TransferID).ConfigureAwait(false)).FirstOrDefault();
                        var log = new logPRCAuctionSystemAssignVendorTransferPrice()
                        {
                            trxPRCAuctionSystemAssignVendorTransferPriceID = dataResult.ID,
                            trxPRCAuctionSystemAssignVendorID = dataResult.trxPRCAuctionSystemAssignVendorID,
                            mstFINRefundTransactionTypeID = dataResult.mstFINRefundTransactionTypeID,
                            mstFINRefundTransactionCategory = dataResult.mstFINRefundTransactionCategory,
                            mstCompanyIDAX = dataResult.mstCompanyIDAX,
                            AccountNumber = dataResult.AccountNumber,
                            TransferPrice = dataResult.TransferPrice,
                            TransferDate = dataResult.TransferDate,
                            AdditionalInformation = dataResult.AdditionalInformation,
                            SenderName = dataResult.SenderName,
                            VendorAccount = dataResult.VendorAccount,
                            SubmitDate = dataResult.CreatedDate,
                            SubmitBy = dataResult.SubmitBy,
                            CreatedDate = dataResult.CreatedDate,
                            CreatedBy = dataResult.CreatedBy,
                            UpdatedDate = dataResult.UpdatedDate,
                            UpdatedBy = dataResult.UpdatedBy
                        };
                        await logService.AddAsync(log);
                        
                    }
                    else
                    {
                        var newRecord = new trxPRCAuctionSystemAssignVendorTransferPrice()
                        {
                            trxPRCAuctionSystemAssignVendorID = item.TransferID,
                            mstFINRefundTransactionTypeID = item.TransactionTypeID,
                            mstFINRefundTransactionCategory = item.TransactionCategory,
                            mstCompanyIDAX = item.CompanyIDAX,
                            AccountNumber = item.AccountNumberBank,
                            TransferPrice = item.Amount,
                            TransferDate = item.TransferDate,
                            AdditionalInformation = item.AdditionalInformation,
                            SenderName = item.AccountName,
                            VendorAccount = item.AccountNumber,
                            SubmitDate = item.CreatedDate,
                            SubmitBy = "ETender",
                            CreatedBy = "ETender",
                            CreatedDate = DateTime.Now
                        };
                        await service.AddAsync(newRecord).ConfigureAwait(false);

                        var dataResult = (await service.GetListAsync(filter: f => f.trxPRCAuctionSystemAssignVendorID == item.TransferID).ConfigureAwait(false)).FirstOrDefault();
                        var log = new logPRCAuctionSystemAssignVendorTransferPrice()
                        {
                            trxPRCAuctionSystemAssignVendorTransferPriceID = dataResult.ID,
                            trxPRCAuctionSystemAssignVendorID = dataResult.trxPRCAuctionSystemAssignVendorID,
                            mstFINRefundTransactionTypeID = dataResult.mstFINRefundTransactionTypeID,
                            mstFINRefundTransactionCategory = dataResult.mstFINRefundTransactionCategory,
                            mstCompanyIDAX = dataResult.mstCompanyIDAX,
                            AccountNumber = dataResult.AccountNumber,
                            TransferPrice = dataResult.TransferPrice,
                            TransferDate = dataResult.TransferDate,
                            AdditionalInformation = dataResult.AdditionalInformation,
                            SenderName = dataResult.SenderName,
                            VendorAccount = dataResult.VendorAccount,
                            SubmitDate = dataResult.CreatedDate,
                            SubmitBy = dataResult.SubmitBy,
                            CreatedDate = dataResult.CreatedDate,
                            CreatedBy = dataResult.CreatedBy,
                            UpdatedDate = dataResult.UpdatedDate,
                            UpdatedBy = dataResult.UpdatedBy
                        };
                        await logService.AddAsync(log);
                    }
                    item.IsSync = true;
                    item.SyncDate = DateTime.Now;
                }
                catch
                {

                }
            }
            Console.WriteLine($"[Transfer] Processing: {message}");
            var update = JsonConvert.SerializeObject(data);
            await Task.Run(() => _publisher.Publish("materialscrapped.transfer.status", update));
            await Task.CompletedTask;
        }
    }
}
