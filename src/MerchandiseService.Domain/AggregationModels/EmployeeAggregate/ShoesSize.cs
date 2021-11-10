using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class ShoesSize : ValueObject
	{
		public string Value { get; }
        
		public ShoesSize(string shoesSize)
		{
			Value = shoesSize;
		}
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}