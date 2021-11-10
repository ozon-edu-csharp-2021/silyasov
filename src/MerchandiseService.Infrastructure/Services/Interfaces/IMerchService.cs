using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;

namespace MerchandiseService.Infrastructure.Services.Interfaces
{
	public interface IMerchService
	{
		Task<string> RequestMerchAsync(int employeeId, int merchPackId, EventType eventType, CancellationToken token);
		Task<IEnumerable<int>> GetMerchPacksReceivedByEmployeeAsync(int employeeId, CancellationToken token);
	}
}