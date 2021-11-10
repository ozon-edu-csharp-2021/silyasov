using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class MerchPack : Entity
	{
		public MerchPack()
		{
			
		}
		
		public string Name { get; }
		public List<MerchItem> MerchItems { get; private set; }
		public MerchPackType Type;
	}
}