using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
	public class MerchRequestStatus : Enumeration
	{
		public static MerchRequestStatus NewRequest = new(1, nameof(NewRequest));
		public static MerchRequestStatus NotInStock = new(2, nameof(NotInStock));
		public static MerchRequestStatus EmployeeGotMerch = new(3, nameof(EmployeeGotMerch));
		
		public MerchRequestStatus(int id, string name) : base(id, name)
		{
		}
	}
}