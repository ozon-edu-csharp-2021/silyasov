using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class ClothingSize : Enumeration
	{
		public static ClothingSize XS = new(1, "XS");
		public static ClothingSize S = new(2, "S");
		public static ClothingSize M = new(3, "M");
		public static ClothingSize L = new(4, "L");
		public static ClothingSize XL = new(5, "XL");
		public static ClothingSize XXL = new(6, "XXL");
		private ClothingSize(int id, string name) : base(id, name)
		{
		}
	}
}