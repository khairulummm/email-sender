using DataIntegration.Application.DTOs.ETender.SPH.NonNetwork;
using DataIntegration.Application.Extensions;
using DataIntegration.Application.Interfaces.Entities.TBIGSYSDB01.TBiGSys;
using DataIntegration.Application.Interfaces.Modules.BUS.SPH.NonNetwork;
using DataIntegration.Application.Interfaces.Modules.Workflow;
using DataIntegration.Domain.Enums.Workflow;
using DataIntegration.Domain.Models.ViewModels.BUS.SPH.NonNetwork;
using DataIntegration.Domain.Models.ViewModels.Workflow.parameter;
using Microsoft.Extensions.Logging;

namespace DataIntegration.Application.Services.Modules.BUS.SPH.NonNetwork
{
    public class NegotiationWorkflowService : INegotiationWorkflowService
    {
        private readonly IuspPRCSPHNonShoppingListNonNetworkGetHeaderService _headerService;
        private readonly IvwPRCSPHNonShoppingListNonNetworkNegotiationCountService _countNegoService;
        private readonly ILogger<NegotiationWorkflowService> _logger;
        private readonly IWorkflowService _workflowService;

        public NegotiationWorkflowService(IuspPRCSPHNonShoppingListNonNetworkGetHeaderService headerService, IvwPRCSPHNonShoppingListNonNetworkNegotiationCountService countNegoService,
            ILogger<NegotiationWorkflowService> logger, IWorkflowService workflowService)
        {
            _headerService = headerService;
            _countNegoService = countNegoService;
            _logger = logger;
            _workflowService = workflowService;
        }

        public async Task GenerateApprovalNegotiationAsync(SPHNonShoppingListNonNetworkNegotiation dataInput, IServiceProvider serviceProvider)
        {
            try
            {
                vmWorkflowData<vmSPHNonNetworkWorkflow> dataWorkflow = new vmWorkflowData<vmSPHNonNetworkWorkflow>();
                dataWorkflow.Variable = new vmSPHNonNetworkWorkflow();

                var nego = (await _countNegoService.GetListAsync(filter: x => x.NegotiationID == dataInput.SPHNonNetworkWorkTypePriceID).ConfigureAwait(false)).FirstOrDefault();
                if (nego != null)
                {
                    if (nego.HeaderStatusID == 5 && nego.CountNego == 0)
                    {
                        var result = (await _headerService.ExecuteStoredProcedureQueryAsync
                            ($"TBIGSYS.dbo.uspPRCSPHNonShoppingListNonNetworkGetHeader @vType = 'Detail', @vID = {nego.HeaderID}")
                            .ConfigureAwait(false));
                        var dataHeader = result.FirstOrDefault();
                        dataWorkflow.AppID = "TBIGSys";
                        dataWorkflow.CoreID = Convert.ToString(dataHeader.ID);
                        dataWorkflow.ModuleCode = TBGWorkflowModuleCode.SPHNonShoppingListNonNetwork;
                        dataWorkflow.UserID = "VendorNonNetwork";
                        dataWorkflow.Variable.AssignmentStatusCode = "";
                        dataWorkflow.Variable.CoreID = dataHeader.ID.ToString();
                        dataWorkflow.Variable.ModuleTransactionID = dataHeader.ModuleTransactionID;
                        dataWorkflow.Variable.TransactionModuleID = dataHeader.ModuleTransactionID;
                        dataWorkflow.Variable.IsNeedAlternativeVendor = "0";
                        dataWorkflow.Variable.IsNeedNegotiation = "0";
                        dataWorkflow.Variable.AssignmentBeforeStatusCode = dataHeader.AssignmentStatusCode;
                        dataWorkflow.Variable.StatusCode = dataHeader.AssignmentStatusCode;
                        dataWorkflow.Variable.DecisionCode = dataHeader.AssignmentStatusCode == "SPHNSLNN_STS_3" ? "SPHNSLNN_DEC_7" : "SPHNSLNN_DEC_12";
                        dataWorkflow.Variable.AssignmentStatusDecisionCode = dataHeader.AssignmentStatusCode == "SPHNSLNN_STS_3" ? "SPHNSLNN_DEC_7" : "SPHNSLNN_DEC_12";
                        dataWorkflow.Variable.Remarks = "";
                        dataWorkflow.Variable.ParticipantID = "VendorNonNetwork";
                        dataWorkflow.Variable.Requestor = dataHeader.Requestor;
                        dataWorkflow.Variable.DateApprove = dataInput.CreatedDate;
                        dataWorkflow.Variable.BudgetRequest = 0;
                        dataWorkflow.Variable.PriceFinalNego = 0;
                        dataWorkflow.Variable.UserID = "VendorNonNetwork";

                        var wfResult = await Task.Run(() => _workflowService.SubmitApprovalAsync(dataWorkflow));
                    }
                }
            }
            catch (Exception ex)
            {
                await _logger.LogException(serviceProvider, ex);
                throw;
            }
        }
    }
}
