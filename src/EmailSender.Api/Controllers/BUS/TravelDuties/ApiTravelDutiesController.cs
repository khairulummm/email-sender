using DataIntegration.Application.Interfaces.Modules.BUS.TravelDuties;
using DataIntegration.Application.Interfaces.Scheduller;
using DataIntegration.Application.Interfaces.Scheduller.BUS;
using DataIntegration.Domain.Models.ViewModels.BUS.TravelDuties.TravelAgent;
using Microsoft.AspNetCore.Mvc;

namespace DataIntegration.Api.Controllers.BUS.TravelDuties
{
    [Route("api/travel-duties")]
    [ApiController]
    public class ApiTravelDutiesController(ITravelDutiesScheduller scheduller) : ControllerBase
    {
        private readonly ITravelDutiesScheduller _scheduller = scheduller;

        [HttpPost("booking-ota")]
        public async Task<IActionResult> BookingOTAFromJson([FromBody] dtPostBookingOTA param)
        {

            var result = await _scheduller.ScheduleBookingOTAAsync(param);
            return Ok(result);
        }


        [HttpPost("test-email")]
        public async Task<IActionResult> TestEmail([FromBody] dtPostBookingOTA param)
        {

            var result = await _scheduller.TestEmail(param);
            return Ok(result);
        }
    }
}
