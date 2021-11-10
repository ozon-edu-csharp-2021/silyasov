using System.Data.Common;
using CSharpCourse.Core.Lib.Enums;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
	public class MerchRequest : Entity
	{
		public int Id;
		public int EmployeeId;
		public int MerchPackId;
		public EventType EventType;
		public MerchRequestStatus Status;

		public MerchRequest(int id, int employeeId, int merchPackId, EventType eventType, MerchRequestStatus status)
		{
			Id = id;
			EmployeeId = employeeId;
			MerchPackId = merchPackId;
			EventType = eventType;
			Status = status;
		}
	}
}