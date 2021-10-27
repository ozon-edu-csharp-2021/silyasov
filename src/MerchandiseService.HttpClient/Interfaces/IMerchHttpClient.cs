using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpClient.Models;

namespace MerchandiseService.HttpClient.Interfaces
{
	public interface IMerchHttpClient

	{
		Task<List<MerchModelResponse>> GetMerch(int merchId, CancellationToken token);
	}
}