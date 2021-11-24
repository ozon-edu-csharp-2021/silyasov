using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace MerchandiseService.Infrastructure.Services.Interfaces
{
	public interface IMerchService
	{
		Task<string> RequestMerchAsync(int employeeId, int merchPackId, EventType eventType, CancellationToken token);
		Task<IEnumerable<string>> GetMerchPacksReceivedByEmployeeAsync(int employeeId, CancellationToken token);
	}
}