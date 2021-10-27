using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
	[ApiController]
	[Route("v1/api/merch")]
	[Produces("application/json")]
	public class MerchController : ControllerBase
	{
		[HttpGet("getmerch/{merchId:int}")]
		public async Task<IActionResult> GetMerch(int merchId, CancellationToken token)
		{
			return Ok($"You requested merch with id {merchId}");
		}

		[HttpGet("getmerchinfo/{merchInfoId:int}")]
		public async Task<IActionResult> GetMerchInfo(int merchInfoId, CancellationToken token)
		{
			return Ok($"You requested info about merch with id {merchInfoId}");
		}
	}
}