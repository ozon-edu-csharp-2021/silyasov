using System.Collections.Generic;
using MerchandiseService.Domain.Models;
using MerchandiseService.Domain.Exceptions;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class Sex : ValueObject
	{
		public string Value { get; }
        
		public Sex(string sex)
		{
			if(sex is "Мужской" or "Женский")
				Value = sex;
			else
				throw new NegativeValueException("Пол указан неправильно.");
		}
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}