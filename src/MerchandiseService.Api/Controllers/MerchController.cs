using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Infrastructure.MediatR.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Api.Controllers
{
	[ApiController]
	[Route("v1/api/merch")]
	[Produces("application/json")]
	public class MerchController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MerchController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetMerch([FromQuery]int employeeId, [FromQuery]int merchPackId, CancellationToken token)
		{
			var merchRequest = new MerchRequest(employeeId, merchPackId, EventType.GetMerchByRequest);
			var result = await _mediator.Send(merchRequest, token);
			return Ok(result);
		}

		[HttpGet("{employeeId:int}/info")]
		public async Task<IActionResult> GetMerchInfo(int employeeId, CancellationToken token)
		{
			var merchRequest = new EmployeeRequest(employeeId);
			var result = await _mediator.Send(merchRequest, token);
			return Ok(result);
		}
	}
}