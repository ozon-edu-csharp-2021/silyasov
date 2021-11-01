using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpClient.Models;

namespace MerchandiseService.HttpClient.Interfaces
{
	public interface IMerchHttpClient

	{
		Task<int> GetMerchAsync(int merchId, CancellationToken token);
		Task<string> GetMerchInfoAsync(int merchId, CancellationToken token);
	}
}