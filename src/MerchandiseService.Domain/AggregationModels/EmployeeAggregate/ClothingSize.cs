using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class ClothingSize : ValueObject
	{
		public string Value { get; }
        
		public ClothingSize(string clothingSize)
		{
				Value = clothingSize;
		}
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}