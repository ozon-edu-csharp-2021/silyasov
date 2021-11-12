using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class MerchPackRepository : IMerchPackRepository
	{
		public IUnitOfWork UnitOfWork { get; }
		
		public async Task<MerchPack> CreateAsync(MerchPack itemToCreate, CancellationToken cancellationToken = default)
		{
			throw new System.NotImplementedException();
		}

		public async Task<MerchPack> UpdateAsync(MerchPack itemToUpdate, CancellationToken cancellationToken = default)
		{
			throw new System.NotImplementedException();
		}
	}
}