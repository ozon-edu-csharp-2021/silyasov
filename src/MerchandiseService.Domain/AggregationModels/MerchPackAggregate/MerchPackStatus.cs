using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class MerchPackStatus : Enumeration
	{
		public static MerchPackStatus Requested = new(1, nameof(Requested));
		public static MerchPackStatus NotInStock = new(2, nameof(NotInStock));
		public static MerchPackStatus Received = new(3, nameof(Received));
		
		public MerchPackStatus(int id, string name) : base(id, name)
		{
		}
	}
}