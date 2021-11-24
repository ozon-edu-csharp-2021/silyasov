using System;
using System.Collections.Generic;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class HireDate : ValueObject
	{
		private DateTime Value { get; set; }
        
		public HireDate(DateTime hireDate)
		{
			SetHireDate(hireDate);
		}
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}

		private void SetHireDate(DateTime hireDate)
		{
			if (hireDate > DateTime.Now)
				throw new WrongDateException("Неправильная дата приема на работу.");
			Value = hireDate;
		}
	}
}