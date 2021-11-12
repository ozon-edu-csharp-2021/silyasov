using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class MerchItem : Entity
	{
		public MerchItem(string name, MerchItemType type, Sku sku)
		{
			Name = name;
			Type = type;
			Sku = sku;
		}

		private string Name { get; }
		public MerchItemType Type { get; }
		private Sku Sku { get; }
	}
}