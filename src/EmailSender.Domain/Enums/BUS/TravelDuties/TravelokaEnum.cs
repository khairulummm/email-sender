using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Enums.BUS.TravelDuties
{
    public enum TravelokaConfiguration
    {
        CustomerIpAddress,
        CustomerUserAgent,
        Locale,
        CurrencyCode,
        ClientInterface,
        LoginId,
        LoginType,
        EmailReceiver,
        TbgMobilePhone,
        SpecialRequest,
        LoopViewItinerary,
        LoopFlightStatus,
        AccommodationBookingType,
        ReviseConfirmationID,
        DelayBookingAccom,
        DelayIssuedAccom,
        DelayBookingFlight,
        DelayIssuedFlight,
        LogDocumentPath,
    }

    public enum TravelokaAPIStatus
    {
        New = 0,
        InProgress = 1,
        Success = 2,
        Failed = 3,
        Cancelled = 4,
    }

    public enum TravelokaEndpointCode
    {
        GetAccessToken,
        GeoList,
        PropertyList,
        SearchHotel,
        RoomList,
        Prebook,
        CreateBooking,
        AccomBooking,
        AccomConfirm,
        ViewItinerary,
        SearchOneWay,
        CheckRule,
        FlightBooking,
        AddOns,
        FlightConfirm,
        FlightBookingStatus,
        DownloadEticket,
        DownloadVoucher
    }

    public enum TravelokaRootCode
    {
        OAuth_API,
        Accom_Content_API,
        Accom_Search_API,
        Accom_Booking_API,
        Flight_API
    }

    public enum TravelokaCredentialName
    {
        corp_tower_bersama_accom,
        corp_tower_bersama_flight
    }

    public enum TravelokaPropertyOption
    {
        PROPERTY_SUMMARY,
        PROPERTY_DETAILS,
        PROPERTY_IMAGES,
        PROPERTY_AMENITIES,
        ROOM_AMENITIES
    }

    public enum TravelokaPrebookStatus
    {
        AVAILABLE,
        NOT_AVAILABLE
    }

    public enum TravelokaSeatClass
    {
        ECONOMY,
        PREMIUM_ECONOMY,
        BUSINESS,
        FIRST
    }

    public enum TravelokaPlaneSortBy
    {
        LOWEST_PRICE,
        EARLIEST_DEPARTURE,
        LATEST_DEPARTURE,
        EARLIEST_ARRIVAL,
        LATEST_ARRIVAL,
        SHORTEST_DURATION
    }

    public enum TravelokaJourneyType
    {
        ONE_WAY,
        BASIC_RT,
        PACKAGE_RT
    }

    public enum TravelokaLoginType
    {
        EMAIL,
        PN
    }

    public enum TravelokaDocumentType
    {
        NATIONAL_ID,
        PASSPORT,
        VISA,
        BIRTH_CERTIFICATE,
        DRIVING_LICENSE,
        OTHERS
    }

    public enum TravelokaGender
    {
        M,
        F
    }

    public enum TravelokaPassengerTitle
    {
        MR,
        MRS,
        MISS
    }

    public enum TravelokaAccommodationBookingStatus
    {
        SUCCESS,
        SUCCESS_WITH_PRICE_CHANGED, //Status sendiri. Jika ketika booking response statusnya PRICE_CHANGED dengan amount dibawah rate ketika applicant pilih kamar
        PENDING,
        PRICE_CHANGED,
        SOLD_OUT,
        FAILED
    }

    public enum TravelokaAccommodationItineraryStatus
    {
        CANCELLED,
        FAILED,
        PENDING,
        ISSUED,
        BOOKED,
        EXPIRED
    }

    public enum TravelokaTransportationPaymentStatus
    {
        SUCCESS,
        BOOKING_EXPIRED,
        BOOKING_NOT_FOUND,
        ALREADY_CONFIRMED,
        FAILED
    }

    public enum TravelokaTransportationBookingStatus
    {
        BOOKED,
        WAITING_FOR_ISSUANCE,
        ISSUED,
        ISSUANCE_FAILED,
        CANCELLED
    }

    public enum TravelokaTransportationSubmitBooking
    {
        TIMEOUT,
        FLIGHT_NOT_AVAILABLE
    }

    public enum TravelokaPaymentMethod
    {
        CREDIT_CARD,//Both
        NON_CREDIT_CARD, //Flight
        OTHERS //Accommodation
    }
}
