using CSharpCourse.Core.Lib.Enums;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
	public class MerchRequest : Entity
	{
		private int _employeeId;
		private int _merchPackId;
		private EmployeeEventType _eventType;
		private MerchRequestStatus _status;

		public MerchRequest(int employeeId, int merchPackId, EmployeeEventType eventType, MerchRequestStatus status)
		{
			_employeeId = employeeId;
			_merchPackId = merchPackId;
			_eventType = eventType;
			_status = status;
		}
	}
}