using DataIntegration.Application.Extensions;
using DataIntegration.Application.Interfaces.Modules.BUS.IKR;
using DataIntegration.Application.Interfaces.Modules.BUS.PurchaseRequest.Legacy;
using DataIntegration.Application.Interfaces.Modules.General;
using DataIntegration.Domain.Entities.HTBGDBS03.HR_TBG;
using DataIntegration.Domain.Entities.HTBGDBS03.TBG_Sys;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBGFTTH;
using DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Domain.Enums.BUS.IKR;
using DataIntegration.Domain.Models.ViewModels.BUS.IKR;
using DataIntegration.Infrastructure.Data;
using EFCore.BulkExtensions.SqlAdapters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Nodes;

namespace DataIntegration.Application.Services.Modules.BUS.IKR
{
    public class IKRService(IUnitOfWorkFactory unitOfWorkFactory, IServiceProvider serviceProvider, ILogger<IKRService> logger)
        : IIKRService
    {
        private readonly IIKRGeneratePurchaseConfigurationService _ikrConfigService;
        private readonly IIKRGenerateService _ikrGenerateService;
        private readonly IIKRGeneratePurchaseService _ikrGeneratePurchaseService;
        private readonly IIKRGeneratePurchaseDetailService _ikrGeneratePurchaseDetailService;
        private readonly IIKRGeneratePurchaseDetailSummaryService _ikrGeneratePurchaseDetailSummaryService;
        private readonly IIKRDataGeneratePurchaseService _ikrDataGeneratePurchaseService;
        private readonly IIKRReleasePlanService _ikrReleasePlanService;

        private readonly IPurchaseRequestHeaderService _purchaseRequestHeaderService;
        private readonly IPurchaseRequestLineService _purchaseRequestLineService;
        private readonly IPurchaseRequestReleaseTempService _purchaseRequestReleaseTempService;

        private readonly IGeneratePurchaseRequestNumberService _numberService;
        private readonly ITeritoryService _teritoryService;
        private readonly ICompanyService _companyService;
        private readonly IEmployeeService _employeeService;


        public IKRService(IUnitOfWorkFactory unitOfWorkFactory,
                            IServiceProvider serviceProvider,
                            ILogger<IKRService> logger,
                            IIKRGenerateService ikrGenerateService,
                            IIKRGeneratePurchaseConfigurationService ikrConfigService,
                            IIKRGeneratePurchaseService ikrGeneratePurchaseService,
                            IIKRGeneratePurchaseDetailService ikrGeneratePurchaseDetailService,
                            IIKRGeneratePurchaseDetailSummaryService ikrGeneratePurchaseDetailSummaryService,
                            IIKRDataGeneratePurchaseService ikrDataGeneratePurchaseService,
                            IIKRReleasePlanService ikrReleasePlanService,

                            IPurchaseRequestHeaderService purchaseRequestHeaderService,
                            IPurchaseRequestLineService purchaseRequestLineService,
                            IPurchaseRequestReleaseTempService purchaseRequestReleaseTempService,

                            IGeneratePurchaseRequestNumberService numberService,
                            ITeritoryService teritoryService,
                            ICompanyService companyService,
                            IEmployeeService employeeService
            ) : this(unitOfWorkFactory, serviceProvider, logger)
        {
            _ikrConfigService = ikrConfigService;
            _ikrGenerateService = ikrGenerateService;
            _ikrGeneratePurchaseService = ikrGeneratePurchaseService;
            _ikrGeneratePurchaseDetailService = ikrGeneratePurchaseDetailService;
            _ikrGeneratePurchaseDetailSummaryService = ikrGeneratePurchaseDetailSummaryService;
            _ikrDataGeneratePurchaseService = ikrDataGeneratePurchaseService;
            _ikrReleasePlanService = ikrReleasePlanService;

            _purchaseRequestHeaderService = purchaseRequestHeaderService;
            _purchaseRequestLineService = purchaseRequestLineService;
            _purchaseRequestReleaseTempService = purchaseRequestReleaseTempService;

            _numberService = numberService;
            _teritoryService = teritoryService;
            _companyService = companyService;
            _employeeService = employeeService;
        }

        public async Task GenerateAllStep(dtPostIKR post)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var data = new trxBUSFTTHIKRGenerate();
            try
            {
                pAddLogger("Start", "Start Generate Purchase");
                data = await pPreparation();
                post.GenerateID = data.ID;

                await Step1(post);
                await Step2(post);
                pAddLogger("Delay", "wait for SSIS to run for 30 minutes");
                await Task.Delay(TimeSpan.FromMinutes(30));
                await Step3();
            }
            catch (Exception ex)
            {
                await logger.LogException(serviceProvider, ex, post.SchedullerID);
                throw;
            }
            finally
            {
                await pFinishing(data);
                pAddLogger("Finish", string.Format("This Job is completed in {0} minute(s)", sw.Elapsed.Minutes));
                sw.Stop();
            }
        }

        public async Task Step1(dtPostIKR post)
        {
            //1. Get Data di [TBGFTTH].[dbo].[uspBUSIKRGeneratePurchase]
            //2. Insert ke [TBGFTTH].[dbo].[trxBUSFTTHIKRGeneratePurchase]
            //3. Get Data di [TBGFTTH].[dbo].[vwBUSIKRGeneratePurchaseDetail]
            //4. Insert ke [TBGFTTH].[dbo].[trxBUSFTTHIKRGeneratePurchaseDetail]
            //5. Get Data di [TBGFTTH].[dbo].[vwBUSIKRGeneratePurchaseDetailSummary]
            //6. Insert ke [TBGFTTH].[dbo].[trxBUSFTTHIKRGeneratePurchaseDetailSummary]

            try
            {
                pAddLogger("Step", "Start Step 1");

                var WOTypeID = post.WoTypeID;
                var GenerateID = post.GenerateID;

                pAddLogger("Step1", "Create Header");
                #region CreateHeader
                //1.
                var listHead = await _ikrGeneratePurchaseService.GetDataToGeneratePurchase(new dtPostIKRGeneratePurchase()
                {
                    FTTHIKRGenerateID = GenerateID,
                    WOTypeID = Convert.ToInt32(WOTypeID),
                });
                var dataHead = listHead.Select(item => new trxBUSFTTHIKRGeneratePurchase()
                {
                    trxBUSFTTHIKRGenerateID = item.trxBUSFTTHIKRGenerateID,
                    HomepassNumber = item.HomepassNumber,
                    CustomerID = item.CustomerID,
                    WOID = item.WOID,
                    CustomerWOID = item.CustomerWOID,
                    Sonumb = item.Sonumb,
                    SiteID = item.SiteID,
                    Sitename = item.Sitename,
                    VendorID = item.VendorID,
                    CompanyID = item.CompanyID,
                    ResidenceID = Convert.ToInt32(item.ResidenceID),
                    PurchaseRequestNumber = item.PurchaseRequestNumber,
                    PurchaseOrderNumber = item.PurchaseOrderNumber,
                    PurchaseOrderName = item.PurchaseOrderName,
                    WOTypeID = item.WOTypeID,
                    TermPayment = Convert.ToInt32(item.TermPayment),
                    ContractNumber = item.ContractNumber,
                    PurchaseRequestCreator = item.PurchaseRequestCreator,
                    PurchaseRequestDiketahui = item.PurchaseRequestDiketahui,
                    PurchaseRequestDisetujui = item.PurchaseRequestDisetujui,
                    PurchaseRequestDikonfirmasi = item.PurchaseRequestDikonfirmasi,
                    PurchaseOrderCreator = item.PurchaseOrderCreator,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                }).ToList();

                //2.
                await _ikrGeneratePurchaseService.CreateGeneratePurchaseBulky(dataHead);
                await Task.Delay(1000);
                #endregion CreateHeader

                pAddLogger("Step1", "Create Detail");
                #region CreateDetail
                //3.
                var listDetail = await _ikrGeneratePurchaseDetailService.GetDataToGeneratePurchaseDetail();
                var dataDetail = listDetail.Select(item => new trxBUSFTTHIKRGeneratePurchaseDetail()
                {
                    trxBUSFTTHIKRGeneratePurchaseID = item.trxBUSFTTHIKRGeneratePurchaseID,
                    ItemID = item.ItemID,
                    Qty = item.Qty,
                    UoM = item.UoM,
                    Price = Convert.ToDecimal(item.Price),
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                }).ToList();

                //4.
                await _ikrGeneratePurchaseDetailService.CreateGeneratePurchaseDetailBulky(dataDetail);
                await Task.Delay(1000);
                #endregion CreateDetail

                pAddLogger("Step1", "Create Summary");
                #region CreateSummary
                //5.
                var listSummary = await _ikrGeneratePurchaseDetailSummaryService.GetDataToGeneratePurchaseDetailSummary(WOTypeID);
                var dataSummary = listSummary.Select(item => new trxBUSFTTHIKRGeneratePurchaseDetailSummary()
                {
                    trxBUSFTTHIKRGeneratePurchaseID = item.GeneratePurchaseID,
                    HomepassNumber = item.HomePassNumber,
                    ItemName = item.ItemName,
                    Qty = item.Quantity,
                    UoM = item.UoM,
                    Price = Convert.ToDecimal(item.Price),
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                }).ToList();

                //6.
                await _ikrGeneratePurchaseDetailSummaryService.CreateGeneratePurchaseDetailSummaryBulky(dataSummary);
                await Task.Delay(1000);
                #endregion CreateDetail
            }
            catch (Exception ex)
            {
                pAddLogger("Step1", "Something failed on last step");
                pAddLogger("Error", ex.Message);
                throw;
            }
        }

        public async Task Step2(dtPostIKR post)
        {
            //1. Loop[TBGFTTH].[dbo].[vwBUSIKRDataPurchase]
            //  1.1.Generate PRNum & ReqNum
            //  1.2.Insert ke TBG_sys.tbg.TR_PurchReq_Header(23)
            //  1.3.Insert ke TBiGSys.dbo.trxBUSPurchaseRequestReleaseTemp(223)
            //  1.4.Insert ke TBG_sys.tbg.TR_PurchReq_Line
            //  1.5 Update PurchaseRequestNumber di TBGFTTH.dbo.trxBUSFTTHIKRGeneratePurchase

            try
            {
                pAddLogger("Step", "Start Step 2");

                var configuration = await _ikrConfigService.GetAllConfiguration();
                var WOTypeID = post.WoTypeID;
                var GenerateID = Convert.ToInt32(post.GenerateID);
                var maxItem = Convert.ToInt32(configuration[Convert.ToString(IKRGeneratePurchaseConfigKey.MaxItemPerTransaction)]);

                var listData = await _ikrDataGeneratePurchaseService.GetListDataPurchase(new vwBUSIKRDataPurchase() { GenerateID = GenerateID, WOTypeID = Convert.ToInt32(WOTypeID) });
                pAddLogger("Step2", string.Format("Total Data Purchase: {0}", listData.Count()));

                var generateResult = new List<Step2Result>();
                foreach (var item in listData)
                {
                    var company = await _companyService.GetCompany(item.CompanyID);

                    var GeneratePurchase = await _ikrGeneratePurchaseService.GetListGeneratePurchase(new trxBUSFTTHIKRGeneratePurchase()
                    {
                        trxBUSFTTHIKRGenerateID = GenerateID,
                        CompanyID = item.CompanyID,
                        VendorID = item.VendorID,
                        ResidenceID = item.ResidenceID,
                        CustomerID = item.CustomerID,
                        WOTypeID = Convert.ToInt32(WOTypeID)
                    });

                    var vmGeneratePurchase = GeneratePurchase.Select(x => new vmIKRGeneratePurchase()
                    {
                        GeneratePurchase = x,
                        ID = x.ID,
                        ResidenceID = x.ResidenceID,
                        IsDone = false
                    }).ToList();

                    var GenerateDataIDs = GeneratePurchase.Select(x => x.ID).ToArray();
                    var generateDataSummaryList = await _ikrGeneratePurchaseDetailSummaryService.GetListGeneratePurchaseDetailSummary(GenerateDataIDs);

                    var GenerateDataRecidenceIDs = GeneratePurchase.Select(x => x.ResidenceID).ToArray();
                    var TeritoryList = await _teritoryService.GetTeritoryByResidenceIDs(GenerateDataRecidenceIDs);

                    var generateData = vmGeneratePurchase.FirstOrDefault();
                    var generatePurchase = generateData.GeneratePurchase;
                    var empDataRequest = await _employeeService.GetEmployee(new MF_EMPLOYEE() { Employ_Id_TBGSYS = generatePurchase.PurchaseRequestCreator });

                    var totalData = vmGeneratePurchase.Count();
                    int loop = (int)Math.Ceiling((double)totalData / maxItem);

                    pAddLogger("Step2", JsonConvert.SerializeObject(item));
                    pAddLogger("Step2", string.Format("Total Loop : {0}", loop));

                    for (int i = 0; i < loop; i++)
                    {
                        //1.1
                        var GetRequestID = await _numberService.GetRequestID(item.CompanyID);
                        var GetPurchReqId = await _numberService.GetPurchaseRequestID(item.CompanyID);

                        var requestID = GetRequestID.RequestNumber;
                        var purchReqID = GetPurchReqId.PRNumber;
                        pAddLogger("Step 2", string.Format("RequestID = {0}", requestID));
                        pAddLogger("Step 2", string.Format("PurchReqID = {0}", purchReqID));

                        //1.2
                        pAddLogger("Step 2", "Insert Header");
                        var header = new TR_PurchReq_Header()
                        {
                            RequestID = requestID,
                            PurchReqId = purchReqID,
                            PurchReqName = generatePurchase.PurchaseOrderName,
                            StatusPR = "New",
                            DeliveryAddress = company.Address + " " + company.Address1,
                            DeliveryZipCode = company.ZipCode,
                            DeliveryCountry = "INDONESIA",
                            DeliveryCountryRegionID = "",
                            DeliveryState = null,
                            DeliveryName = company.Company,
                            DeliveryCity = company.Address2,
                            DeliveryStreet = null,
                            Dimension = empDataRequest.DepartmentCode,
                            Dimension2 = null,
                            Dimension3 = null,
                            SubmittedBy = empDataRequest.Employ_Id_TBGSYS,
                            SubmittedDatetime = DateTime.Now,
                            AttachmentId = null,
                            StepPR = 1,
                            TanggalSelesaiProject = null,
                            NamaDiketahui = generatePurchase.PurchaseRequestDiketahui,
                            NamaKonfirmasi = generatePurchase.PurchaseRequestDikonfirmasi,
                            NamaDisetujui = generatePurchase.PurchaseRequestDisetujui,
                            ItemId = null,
                            PurchReqType = "FTTH IKR",
                            LogNumber = null,
                            LogDateOpen = null,
                            LogSiteId = null,
                            LogSiteName = null,
                            LogSPVId = null,
                            LogSPVName = null,
                            LogCustId = null,
                            Insurance = null,
                            Operator = null,
                            BOQId = null,
                            ModifiedDatetime = null,
                            ModifiedBy = null,
                            CreateDatetime = DateTime.Now,
                            CreatedBy = empDataRequest.Employ_Id_TBGSYS,
                            DataAreaId = company.CompanyId,
                            StartPeriode = null,
                            EndPeriode = null,
                            Remarks = generatePurchase.PurchaseOrderName,
                            ReferencePR = null,
                            OnBehalf = null,
                            Action = "Submit",
                            ReceivedBy = generatePurchase.PurchaseOrderCreator,
                            ReceivedDateTime = DateTime.Now,
                            RemarkReceive = "Auto PR FTTH IKR",
                            ApprovedBy = generatePurchase.PurchaseOrderCreator,
                            ApprovedDateTime = DateTime.Now,
                            RemarkApproval = "Auto PR FTTH IKR",
                            PrintDatetime = DateTime.Now,
                            IsRegional = false,
                            ApproveHO = null,
                            ApproveBy = null,
                            RemarksApproveRegional = null,
                            MaintenanceRutinType = null,
                            POReference = null,
                            VendorMaintenanceRutin = null,
                            ProjectType = null,
                            IsStandard = null,
                            PLN = null,
                            STIP = null,
                            IsGenerate = "1",
                            AddworkType = null,
                            DeptId = null,
                            SPK_Number = null,
                            AppHeaderID = null,
                            IsOverBudget = false
                        };

                        await _purchaseRequestHeaderService.CreatePurchaseRequest(header);
                        await Task.Delay(1000);

                        //1.3
                        pAddLogger("Step 2", "Insert Release Temp");
                        var prTemp = new trxBUSPurchaseRequestReleaseTemp()
                        {
                            Type = "ReleasePR",
                            PurchReqID = purchReqID,
                            RequestID = requestID,
                            LineNumber = 0,
                            ItemID = "",
                            Name = "",
                            PurchQty = 0,
                            PurchUnit = "",
                            PurchPrice = 0,
                            CurrencyCode = "IDR",
                            ProjID = "",
                            AuditUser = "SSIS",
                            ActionApprove = "Release",
                            Remarks = "Action has been updated to Release by SSIS",
                            ToUser = "",
                            DraftCORNumber = "",
                            ContractNumber = generatePurchase.ContractNumber,
                            Payment = generatePurchase.TermPayment,
                            Vendor = "",
                            ItemIDDetail = "",
                            SONumber = "",
                            PercentageUtilized = 0,
                            IsGenerate = false,
                            GenerateDate = DateTime.Now,
                            CreatedBy = "SSIS",
                            CreatedDate = DateTime.Now,
                        };
                        await _purchaseRequestReleaseTempService.CreatePurchaseRequestReleaseTemp(prTemp);
                        await Task.Delay(1000);

                        //1.4
                        pAddLogger("Step 2", "Insert Line");
                        var top50Data = vmGeneratePurchase.Where(x => !x.IsDone).Take(maxItem).ToList();
                        pAddLogger("Step 2", string.Format("Total Item = {0}", top50Data.Count()));

                        var insertLine = (from a in top50Data
                                          join b in generateDataSummaryList on a.ID equals b.trxBUSFTTHIKRGeneratePurchaseID
                                          join c in TeritoryList on a.ResidenceID equals c.ResidenceID
                                          select new TR_PurchReq_Line()
                                          {
                                              PurchReqId = purchReqID,
                                              RequestId = requestID,
                                              ItemId = a.GeneratePurchase.Sonumb,
                                              Name = b.ItemName,
                                              PurchQty = b.Qty,
                                              PurchUnit = b.UoM,
                                              PurchPrice = b.Price,
                                              CurrencyCode = "IDR",
                                              VendorAccount = a.GeneratePurchase.VendorID,
                                              PurchFQCaseId = null,
                                              RequiredDate = DateTime.Now,
                                              LineAmount = b.Qty * b.Price,
                                              Dimension = c.RegionID.ToString("D2"),
                                              Dimension2 = null,
                                              Dimension3 = a.GeneratePurchase.Sonumb + '.' + a.GeneratePurchase.CustomerID,
                                              PurchId = null,
                                              ProjId = "",
                                              AuditUser = empDataRequest.Employ_Id_TBGSYS,
                                              AuditDate = DateTime.Now,
                                              ItemIDDetail = "",
                                              PercentageUtilized = null
                                          }).ToList()
                                          .Select((x, i) => { x.LineNumber = i + 1; return x; })
                                          .ToList();
                        await _purchaseRequestLineService.CreatePurchaseRequestLineBulky(insertLine);
                        await Task.Delay(1000);

                        //1.5
                        pAddLogger("Step 2", "Update Generate Purchase");
                        top50Data.ForEach(data =>
                        {
                            data.GeneratePurchase.PurchaseRequestNumber = purchReqID;
                            data.IsDone = true;
                        });

                        var update = top50Data.Select(x => x.GeneratePurchase).ToList();

                        await _ikrGeneratePurchaseService.UpdateGeneratePurchaseBulky(update);

                        var summary = new Step2Result
                        {
                            RequestID = requestID,
                            PurchReqID = purchReqID,
                            WOTypeID = WOTypeID,
                            CustomerID = item.CustomerID,
                            Top50Count = top50Data.Count(),
                            TotalLine = insertLine.Count()
                        };
                        generateResult.Add(summary);

                        await Task.Delay(1000);
                    }
                }

                pAddLogger("Step 2", "Generate Summary");
                pAddLogger("Step 2", JsonConvert.SerializeObject(generateResult));
            }
            catch (Exception ex)
            {
                pAddLogger("Step2", "Something failed on last step");
                pAddLogger("Error", ex.Message);
                throw;
            }
        }

        public async Task Step3()
        {
            //1. Update PurchaseOrderNumber di [TBGFTTH].[dbo].[trxBUSFTTHIKRGeneratePurchase]
            //2. Update StatusID di [TBGFTTH].[dbo].[trxASMFTTHPOIKRReleasePlan]

            try
            {
                pAddLogger("Step", "Start Step 3");

                //1
                pAddLogger("Step3", "Update Generate Purchase");
                var GeneratePurchase_PO = await _ikrDataGeneratePurchaseService.GetListGeneratePurchase_PO();
                var updateGeneratePurchase = GeneratePurchase_PO.Select(item => new trxBUSFTTHIKRGeneratePurchase()
                {

                    ID = item.ID,
                    trxBUSFTTHIKRGenerateID = item.trxBUSFTTHIKRGenerateID,
                    HomepassNumber = item.HomepassNumber,
                    CustomerID = item.CustomerID,
                    WOID = item.WOID,
                    CustomerWOID = item.CustomerWOID,
                    Sonumb = item.Sonumb,
                    SiteID = item.SiteID,
                    Sitename = item.Sitename,
                    VendorID = item.VendorID,
                    CompanyID = item.CompanyID,
                    ResidenceID = item.ResidenceID,
                    PurchaseRequestNumber = item.PurchaseRequestNumber,
                    PurchaseOrderNumber = item.PurchId,
                    PurchaseOrderName = item.PurchaseOrderName,
                    WOTypeID = item.WOTypeID,
                    TermPayment = item.TermPayment,
                    ContractNumber = item.ContractNumber,
                    PurchaseRequestCreator = item.PurchaseRequestCreator,
                    PurchaseRequestDiketahui = item.PurchaseRequestDiketahui,
                    PurchaseRequestDisetujui = item.PurchaseRequestDisetujui,
                    PurchaseRequestDikonfirmasi = item.PurchaseRequestDikonfirmasi,
                    PurchaseOrderCreator = item.PurchaseOrderCreator,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    UpdatedBy = "DataIntegration",
                    UpdatedDate = DateTime.Now
                }).ToList();
                await _ikrGeneratePurchaseService.UpdateGeneratePurchaseBulky(updateGeneratePurchase);
                await Task.Delay(1000);

                //2
                pAddLogger("Step3", "Update Release Plan");
                var GeneratePurchase_ReleasePlan = await _ikrDataGeneratePurchaseService.GetListGeneratePurchase_ReleasePlan();
                var updateReleasePlan = GeneratePurchase_ReleasePlan.Select(item => new trxASMFTTHPOIKRReleasePlan()
                {
                    Id = item.ID,
                    HomepassNumber = item.HomepassNumber,
                    CustomerId = item.CustomerID,
                    WoId = item.WOID,
                    CustomerWoId = item.CustomerWOID,
                    Sonumb = item.Sonumb,
                    SiteId = item.SiteID,
                    Sitename = item.Sitename,
                    VendorId = item.VendorID,
                    VendorName = item.VendorName,
                    CompanyId = item.CompanyID,
                    ResidenceName = item.ResidenceName,
                    PurchaseOrderName = item.PurchaseOrderName,
                    WoType = item.WOType,
                    ContractNumber = item.ContractNumber,
                    InstallationDate = item.InstallationDate,
                    InstallationStatus = item.InstallationStatus,
                    PurchaseRequestCreator = item.PurchaseRequestCreator,
                    PurchaseRequestDiketahui = item.PurchaseRequestDiketahui,
                    PurchaseRequestDisetujui = item.PurchaseRequestDisetujui,
                    PurchaseRequestDikonfirmasi = item.PurchaseRequestDikonfirmasi,
                    PurchaseOrderCreator = item.PurchaseOrderCreator,
                    StatusId = 4,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    UpdatedBy = "DataIntegration",
                    UpdatedDate = DateTime.Now,
                    WoTypeId = item.WOTypeID,
                    TermPayment = item.TermPayment,
                    ResidenceId = item.ResidenceID,
                    RegionId = item.RegionID,
                    WoStatusId = item.WOStatusID,
                }).ToList();
                await _ikrReleasePlanService.UpdateReleasePlanBulky(updateReleasePlan);
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                pAddLogger("Step3", "Something failed on last step");
                pAddLogger("Error", ex.Message);
                throw;
            }
        }

        private async Task<trxBUSFTTHIKRGenerate> pPreparation()
        {
            try
            {
                pAddLogger("Step", string.Format("Prepare generate new data start from {0: dd MMM yyyy hh:mm:ss}", DateTime.Now));
                var data = new trxBUSFTTHIKRGenerate()
                {
                    DateGenerate = DateTime.Now,
                    StartTime = DateTime.Now.TimeOfDay,
                    CreatedBy = "DataIntegration",
                    CreatedDate = DateTime.Now,
                };
                await _ikrGenerateService.CreateNew(data);

                return data;
            }
            catch (Exception ex)
            {
                pAddLogger("Step", "Something failed on last step");
                pAddLogger("Error", ex.Message);
                throw;
            }
        }

        private async Task pFinishing(trxBUSFTTHIKRGenerate data)
        {
            //1. Update Finish Time trxBUSFTTHIKRGenerate
            try
            {
                pAddLogger("Step", string.Format("Generate data finish at {0: dd MMM yyyy hh:mm:ss}", DateTime.Now));
                data.FinishTime = DateTime.Now.TimeOfDay;
                data.UpdatedBy = "DataIntegration";
                data.UpdatedDate = DateTime.Now;

                await _ikrGenerateService.UpdateFinishTime(data);
            }
            catch (Exception ex)
            {
                pAddLogger("Step", "Something failed on last step");
                pAddLogger("Error", ex.Message);
                throw;
            }
        }

        private void pAddLogger(string LogName, object LogData)
        {
            logger.LogInformation(LogName, LogData);
            Console.WriteLine(string.Format("[{0}] {1}", LogName, LogData));
        }

        internal class Step2Result
        {
            public string RequestID { get; set; }
            public string PurchReqID { get; set; }
            public int WOTypeID { get; set; }
            public string CustomerID { get; set; }

            public int Top50Count { get; set; }
            public int TotalLine { get; set; }
        }
    }
}
