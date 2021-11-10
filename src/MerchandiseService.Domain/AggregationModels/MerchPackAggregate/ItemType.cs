using System.Collections.Generic;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class ItemType
	{
		private string Name { get; }
		private Dictionary<string, string> Properties { get; }
		private int Weight { get; }
	}
}