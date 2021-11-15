using MediatR;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace MerchandiseService.Infrastructure.MediatR.Requests
{
	public class MerchRequest : IRequest<string>
	{
		public int EmployeeId;
		public int MerchPackId;
		public EventType EventType;

		public MerchRequest(int employeeId, int merchPackId, EventType eventType)
		{
			EmployeeId = employeeId;
			MerchPackId = merchPackId;
			EventType = eventType;
		}
	}
}