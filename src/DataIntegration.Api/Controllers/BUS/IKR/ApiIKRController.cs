using DataIntegration.Application.Interfaces.Scheduller.BUS;
using DataIntegration.Domain.Models.ViewModels.BUS.IKR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataIntegration.Api.Controllers.BUS.IKR
{
    [Route("api/ikr")]
    [ApiController]
    public class ApiIKRController(IIKRScheduller scheduller) : ControllerBase
    {
        private readonly IIKRScheduller _scheduller = scheduller;

        [HttpPost("all-step")]
        public async Task<IActionResult> GenerateAllStep([FromBody] dtPostIKR param)
        {

            //potensi logic disini
            var result = await _scheduller.GenerateAllStep(param);
            return Ok(result);
        }

        [HttpPost("step-1")]
        public async Task<IActionResult> GenerateStep1([FromBody] dtPostIKR param)
        {
            if (!param.GenerateID.HasValue || param.GenerateID == 0)
                throw new Exception("Generate ID is required");

            //potensi logic disini
            var result = await _scheduller.GenerateStep1(param);
            return Ok(result);
        }

        [HttpPost("step-2")]
        public async Task<IActionResult> GenerateStep2([FromBody] dtPostIKR param)
        {

            //potensi logic disini
            var result = await _scheduller.GenerateStep2(param);
            return Ok(result);
        }

        [HttpPost("step-3")]
        public async Task<IActionResult> GenerateStep3([FromBody] dtPostIKR param)
        {

            //potensi logic disini
            var result = await _scheduller.GenerateStep3(param);
            return Ok(result);
        }
    }
}
