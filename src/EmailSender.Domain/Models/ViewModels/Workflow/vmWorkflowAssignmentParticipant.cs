namespace DataIntegration.Domain.Models.ViewModels.Workflow
{
    public class vmWorkflowAssignmentParticipant
    {
        public int ModuleApplicationID { get; set; }
        public string ModuleCode { get; set; }
        public string Module { get; set; }
        public string AssignmentCode { get; set; }
        public string Assignment { get; set; }
        public string AssignmentStatusCode { get; set; }
        public string AssignmentStatus { get; set; }
        public int TransactionID { get; set; }
        public string ParticipantIDs { get; set; }
        public string Participants { get; set; }
        public string ParticipantsWithID { get; set; }
        public string ParticipantVendorIDs { get; set; }
        public string ParticipantVendors { get; set; }
        public string ParticipantVendorsWithID { get; set; }

        public int? StatusCode { get; set; }
        public string JsonError { get; set; }
    }
}
