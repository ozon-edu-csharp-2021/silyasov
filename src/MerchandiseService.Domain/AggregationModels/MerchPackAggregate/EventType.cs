using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class EventType: Enumeration
	{
		public static EventType GetMerchByRequest = new(1, "Get Merch By Request");
		public static EventType NewEmployee = new(2, "New Employee");
		public static EventType ConferenceListener = new(3,"ConferenceListener");
		public static EventType ConferenceSpeaker = new(4, "ConferenceSpeaker");
		public static EventType EmployeeDismissal = new(5, "EmployeeDismissal");
		
		private EventType(int id, string name) : base(id, name)
		{
		}
	}
}