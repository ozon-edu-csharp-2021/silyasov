using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using MerchandiseService.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Api.Controllers
{
	[ApiController]
	[Route("v1/api/merch")]
	[Produces("application/json")]
	public class MerchController : ControllerBase
	{
		private readonly IMerchService _merchService;

		public MerchController(IMerchService merchService)
		{
			_merchService = merchService;
		}

		[HttpGet]
		public async Task<IActionResult> GetMerch([FromQuery]int employeeId, [FromQuery]int merchPackId, CancellationToken token)
		{
			var result = await _merchService.RequestMerchAsync(employeeId, merchPackId, EventType.GetMerchByRequest, token);
			return Ok(result);
		}

		[HttpGet("{employeeId:int}/info")]
		public async Task<IActionResult> GetMerchInfo(int employeeId, CancellationToken token)
		{
			var result = await  _merchService.GetMerchPacksReceivedByEmployeeAsync(employeeId, token);
			return Ok(result);
		}
	}
}