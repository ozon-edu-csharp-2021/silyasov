using System;
using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class HireDate : ValueObject
	{
		public DateTime Value { get; }
        
		public HireDate(DateTime hireDate)
		{
			Value = hireDate;
		}
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}