using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleApplicationLayer.DTO;
using VehicleApplicationLayer.RequestDto;
using VehicleApplicationLayer.VM;

namespace VehicleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly IMediator _mediator;
        public VehicleController(
            ILogger<VehicleController> logger,
             IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("add-vehicle")]
        public async Task<ActionResult> AddVehicle([FromBody] InsertVehicle model)
        {
            await _mediator.Send(model);

            //return viewModel
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<VehicleVm>), 200)]
        [Route("get-vehicles")]
        public async Task<ActionResult> GetVehicles()
        {
            var response = await _mediator.Send(new GetVehicles());

            //return viewModel
            return Ok(response);
        }
    }
}
