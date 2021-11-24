using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class MerchPackRepositoryStub : IMerchPackRepository
	{
		public IUnitOfWork UnitOfWork { get; }
		
		private List<MerchPack> _merchPacks = new()
		{
			new MerchPack(
				1, 
				new Dictionary<MerchItem, int>
				{ 
					{new("Black cup", MerchItemType.Cup, new(395444)), 1},
					{new("10% discount Tehnosila", MerchItemType.Coupon, new(443123)),3}
				}, 
				MerchPackType.StarterPack)
		};
		
		public async Task<MerchPack> CreateAsync(MerchPack itemToCreate, CancellationToken cancellationToken = default)
		{
			throw new System.NotImplementedException();
		}

		public async Task<MerchPack> UpdateAsync(MerchPack itemToUpdate, CancellationToken cancellationToken = default)
		{
			throw new System.NotImplementedException();
		}

		public async Task<MerchPack> GetMerchPackById(int merchPackId)
		{
			return _merchPacks.FirstOrDefault(mp => mp.Id == merchPackId);
		}

		public async Task<bool> HasMerchPack(int merchPackId)
		{
			return _merchPacks.Any(mp => mp.Id == merchPackId);
		}
	}
}