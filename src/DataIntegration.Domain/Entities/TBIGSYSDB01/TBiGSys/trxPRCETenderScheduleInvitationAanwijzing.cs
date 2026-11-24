using System.ComponentModel.DataAnnotations;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    public class trxPRCETenderScheduleInvitationAanwijzing
    {
        [Key]
        public long ID { get; set; }
        public long trxPRCETenderActivityID { get; set; }
        public int? mstPRCETenderLocationTypeID { get; set; }
        public long? trxRequestMeetingRoomID { get; set; }
        public long? trxRequestMeetingRoomVirtualID { get; set; }
        public string EmailBody { get; set; }
        public string Remarks { get; set; }
        public string EmailParticipants { get; set; }
        public int TimeReminder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}