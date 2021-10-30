using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpClient.Models;

namespace MerchandiseService.HttpClient.Interfaces
{
	public interface IMerchHttpClient

	{
		Task<List<MerchModelResponse>> GetMerchAsync(int merchId, CancellationToken token);
		Task<List<MerchModelResponse>> GetMerchInfoAsync(int merchId, CancellationToken token);
	}
}