using System.Threading.Tasks;
using MerchandiseService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MerchandiseService.Controllers
{
	public class StockController : ControllerBase
	{
	//	async Task<ActionResult<StockItem>>	
	}

	public class StockItemPostViewModel
	{
		private string ItemName { get; set; }
	}
}