using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.Services
{
	public class MerchService : IMerchService
	{
		public async Task<int> RequestMerchAsync(int merchId, CancellationToken token)
		{
			return await Task.FromResult(merchId);
		}

		public async Task<string> GetInfoAboutMerchAsync(int merchId, CancellationToken token)
		{
			return await Task.FromResult($"Info about merch {merchId}");
		}
	}
}