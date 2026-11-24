using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Domain.Enums.BUS.TravelDuties
{
    public enum KiaEndpointCode
    {
        GetAccessToken,
        GetCountries,
        GetCities,
        HotelAvailabilityFirst,
        HotelAvailabilityNext,
        HotelDetail,
        HotelConfirmation,
        HotelIssued,
        GetHotelReservation,
        GetAirportByCountry,
        GetAirports,
        FlightAvailability,
        FlightReservation,
        FlightIssued,
        GetFlightReservation,
        GetStation,
        TrainAvailability,
        SeatMap,
        BookTrain,
        SetSeat,
        TrainIssued,
        GetBookTrain,
    }

    public enum KiaAPIStatus
    {
        New = 0,
        InProgress = 1,
        Success = 2,
        Failed = 3,
        Cancelled = 4,
    }

    public enum KiaHotelStatus
    {
        Saved,
        OnRequest,
        Reserved,
        Ticketed,
        BookingError,
        Canceled
    }

    public enum KiaConfiguration
    {
        TbgMobilePhone,
        EmailReceiver,
        PasswordReceiver,
        HostnameEmail,
        PortEmail,
        TimeoutEmail,
        LoopGetHotelReservation,
        LoopGetFlightReservation,
        LoopGetTrainReservation,
        HeaderHost,
        DelayBookingAccom,
        DelayIssuedAccom,
        DelayBookingFlight,
        DelayIssuedFlight,
        LogDocumentPath
    }

    public enum KiaPersonTitle
    {
        MR,
        MRS,
        MS,
        MSTR,
        MALE,
        FEMALE
    }

    public enum KiaBedType
    {
        Single,
        Double,
        Twin,
        Triple,
        Quad
    }

    public enum KiaHotelPaymentCode
    {
        ROOMRATE,
        BASE_RATE_,
        TOTAL,
        SF,
        PPN,
        TOTAL_PAID
    }

    public enum KiaFlightFareType
    {
        Default,
        LowestFare
    }

    public enum KiaFlightCabinClass
    {
        Economy,
        PremiumEconomy,
        Business,
        First,
        PremiumFirst
    }

    public enum KiaAirline
    {
        Lion = 2,
        Citilink = 4,
        AirAsia = 5,
        Scoot = 17,
        Malindo = 18,
        Pelita = 48,
    }

    public enum KiaFlightStatus
    {
        Saved,
        Reserved,
        Ticketed,
        BookingError,
        FlightUnavailable,
        TicketingError,
        Expired,
        FormValidationError,
        TimeoutError
    }

    public enum KiaFlightPaymentCode
    {
        YQF,
        BASE_FARE,
        ID,
        D5,
        P4,
        TOTAL,
        NTS,
        SF,
        TOTAL_PAID
    }
}
