using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class EventType: Enumeration
	{
		public static EventType GetMerchByRequest = new(1, nameof(GetMerchByRequest));
		public static EventType NewEmployee = new(2, nameof(NewEmployee));
		public static EventType ConferenceListener = new(3, nameof(ConferenceListener));
		public static EventType ConferenceSpeaker = new(4, nameof(ConferenceSpeaker));
		public static EventType EmployeeDismissal = new(5, nameof(EmployeeDismissal));
		
		private EventType(int id, string name) : base(id, name)
		{
		}
	}
}