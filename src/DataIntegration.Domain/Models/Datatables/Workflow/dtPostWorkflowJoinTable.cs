using DataIntegration.Domain.Models.ViewModels.Workflow;

namespace DataIntegration.Domain.Models.Datatables.Workflow
{
    public class dtPostWorkflowJoinTable<T>
    {
        public IQueryable<T> ListMain { get; set; }
        public IQueryable<vmWorkflowAssignmentParticipant> ListParticipant { get; set; }
        public Func<T, long> CoreID { get; set; }
        public Func<T, vmWorkflowAssignmentParticipant, T> MappingData { get; set; }
    }
}
