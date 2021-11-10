using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class Name : ValueObject
	{
		public string Value { get; }
        
		public Name(string name)
		{
			Value = name;
		}
		
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}