namespace DataIntegration.Domain.Enums.Workflow
{
    public static class TBGWorkflowModuleCode
    {
        public static readonly string TravelDuties = "STD";
        public static readonly string PurchaseRequest = "PR";
        public static readonly string PurchaseOrder = "PO";
        public static readonly string EMS = "EMS";
        public static readonly string SPHNonShoppingListNonNetwork = "SPHNSLNN";
    }

    public static class TBGWorkflowEndpoint
    {
        public static readonly string Initiate = "api/approval-flow-process/Approval/initiate";
        public static readonly string SubmitApproval = "api/approval-flow-process/Approval/approval";
        public static readonly string ListAssignmentParticipant = "api/assignment-participant/list";
        public static readonly string ListInitiatorTransaction = "api/assignment-participant/initiator-transaction";
        public static readonly string ListOwnAssignment = "api/assignment-participant/own-assignment";
        public static readonly string CurrentParticipant = "api/assignment-participant/current-participant";
        public static readonly string ListAssignmentDecision = "api/assignment-decision/list";
        public static readonly string ListAssignmentStatus = "api/assignment-status/list";
        public static readonly string ListAssignmentVariable = "api/assignment-variable/list";
        public static readonly string AssignmentProcess = "api/assignment-process/get-current";
        public static readonly string ListTaskToDo = "api/task-to-do/list";
    }
}
