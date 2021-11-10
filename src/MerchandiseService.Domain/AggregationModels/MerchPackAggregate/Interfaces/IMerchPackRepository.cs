using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces
{
	public interface IMerchPackRepository : IRepository<MerchPack>
	{
		
	}
}