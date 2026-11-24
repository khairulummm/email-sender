using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent.KIA;
using DataIntegration.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties.TravelAgent.KIA
{
    public interface IKiaService
    {
        Task<vmAccessToken> GetToken(string logPath, string userID);
        Task<vmResponseHotelConfirmation> HotelConfirmation(IUnitOfWork uow, dtPostApi<vmRequestHotelConfirmation> param);
        Task<vmResponseHotelIssued> HotelIssued(IUnitOfWork uow, dtPostApi<vmRequestHotelIssued> param);
        Task<vmResponseGetHotelReservation> GetHotelReservation(IUnitOfWork uow, dtPostApi<string> param);
        Task<vmResponseFlightReservation> FlightReservation(IUnitOfWork uow, dtPostApi<vmRequestFlightReservation> param);
        Task<vmResponseFlightIssued> FlightIssued(IUnitOfWork uow, dtPostApi<vmRequestFlightIssued> param);
        Task<vmResponseGetFlightReservation> GetFlightReservation(IUnitOfWork uow, dtPostApi<string> param);
    }
}
