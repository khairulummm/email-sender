using DataIntegration.Domain.Enums.BUS.TravelDuties;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.Traveloka;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties.TravelAgent.Traveloka
{
    public interface ITravelokaService
    {
        Task<vmAccessToken> GetToken(TravelokaCredentialName credName, string logPath, string userID);
        Task<vmAccomAffiliateBookingAPIResponse> CreateBooking(IUnitOfWork uow, dtPostApi<vmAccomAffiliateBookingAPISpec> param);
        Task<vmAccomAffiliateViewItinerariesResult> ViewItinerary(IUnitOfWork uow, dtPostApi<vmAccomAffiliateViewItinerariesSpec> param);
        Task<vmFlightBookingRS> FlightBooking(IUnitOfWork uow, dtPostApi<vmFlightBookingRQ> param);
        Task<vmFlightBookingStatusRS> FlightBookingStatus(IUnitOfWork uow, dtPostApi<vmFlightBookingStatusRQ> param);
        Task<vmPaymentConfirmationRS> FlightConfirm(IUnitOfWork uow, dtPostApi<vmPaymentConfirmationRQ> param);
    }
}
