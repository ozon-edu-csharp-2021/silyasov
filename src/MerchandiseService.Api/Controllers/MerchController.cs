using System.Threading;
using System.Threading.Tasks;
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

		[HttpGet("{merchId:int}")]
		public async Task<IActionResult> GetMerch(int merchId, CancellationToken token)
		{
			var result = await _merchService.RequestMerchAsync(merchId, token);
			return Ok(result);
		}

		[HttpGet("{merchId:int}/info")]
		public async Task<IActionResult> GetMerchInfo(int merchId, CancellationToken token)
		{
			var result = await  _merchService.GetMerchPacksReceivedByEmployeeAsync(merchId, token);
			return Ok(result);
		}
	}
}