using System.Collections.Generic;
using MerchandiseService.Domain.Models;
using MerchandiseService.Domain.Exceptions;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class Sex : Enumeration
	{
		public static Sex Male = new (1, "Мужской");
		public static Sex Female = new (2, "Женский");

		private Sex(int id, string name) : base(id, name)
		{
		}
	}
}