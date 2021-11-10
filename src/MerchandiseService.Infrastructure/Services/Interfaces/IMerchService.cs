using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace MerchandiseService.Infrastructure.Services.Interfaces
{
	public interface IMerchService
	{
		Task<string> RequestMerchAsync(int merchRequestId, CancellationToken token);
		Task<IEnumerable<MerchPackType>> GetMerchPacksReceivedByEmployeeAsync(int merchId, CancellationToken token);
	}
}