using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxRequestMeetingRoomVirtual
    {
        [Key]
        public long ID { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MeetingRoomVirtualID { get; set; }
        public string Remarks { get; set; }
        public bool IsCancel { get; set; }
        public string? RemarksCancel { get; set; }
        public string ZoomID { get; set; }
        public string ZoomPassword { get; set; }
        public string ZoomJoinURL { get; set; }
        public string? ApprovalStatus { get; set; }
        public string? ApprovalBy { get; set; }
        public string? ApprovalRemarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}