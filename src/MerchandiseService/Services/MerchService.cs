using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
	public class MerchService : IMerchService
	{
		public int RequestMerch(int merchId, CancellationToken token)
		{
			return merchId;
		}

		public string GetInfoAboutMerch(int merchId, CancellationToken token)
		{
			return $"Info about merch {merchId}";
		}
	}
}