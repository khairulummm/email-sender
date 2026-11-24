using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataIntegration.Domain.Entities.TBIGSYSDB01.TBiGSys
{
    [Table("vwBUSTravelDutiesBookingAccommodation")]
    public class vwBUSTravelDutiesBookingAccommodation
    {
        [Key] // EF Core mengharuskan adanya key, walau hanya untuk tracking.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TravelDutiesLocationID { get; set; }

        public string? DT_RowId { get; set; }
        public long TravelDutiesID { get; set; }
        public string? DestinationType { get; set; }
        public string? STDNumber { get; set; }
        public string? Location { get; set; }
        public string? Destination { get; set; }
        public string? DepartureFrom { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string? ApplicantID { get; set; }
        public string? Applicant { get; set; }
        public string? AccomodationType { get; set; }
        public int? OtherBookingAccommodationDetailID { get; set; }
        public long? OtherTravelDutiesID { get; set; }
        public long? OtherTravelDutiesLocationID { get; set; }
        public string? OtherDestinationType { get; set; }
        public string? OtherSTDNumber { get; set; }
        public string? ShareRoomID { get; set; }
        public string? ShareRoomWith { get; set; }
        public int? BookingAccommodationID { get; set; }
        public int? BookingAccommodationDetailID { get; set; }
        public int? TravelAgentID { get; set; }
        public string? TravelAgent { get; set; }
        public string? AccommodationID { get; set; }
        public string? AccommodationName { get; set; }
        public string? AccommodationPhone { get; set; }
        public string? AccommodationImage { get; set; }
        public string? AccommodationLocation { get; set; }
        public string? RoomId { get; set; }
        public string? RoomName { get; set; }
        public int? Star { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? NumOfAdult { get; set; }
        public decimal? Total { get; set; }
        public bool? IsBreakfast { get; set; }
        public int? TravelokaBookingAccommodationID { get; set; }
        public int? TravelokaRevision { get; set; }
        public string? TravelokaBookingID { get; set; }
        public string? TravelokaConfirmationID { get; set; }
        public string? TravelokaItineraryID { get; set; }
        public string? TravelokaBookingStatus { get; set; }
        public string? TravelokaRateKey { get; set; }
        public int? TravelokaIteration { get; set; }
        public int? KiaBookingAccommodationID { get; set; }
        public string? KiaCorrelationID { get; set; }
        public string? KiaConfirmationID { get; set; }
        public string? KiaPnrID { get; set; }
        public string? KiaBookingStatus { get; set; }
        public string? KiaBookingID { get; set; }
        public string? KiaBookingCode { get; set; }
        public int? KiaIteration { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
    }
}
