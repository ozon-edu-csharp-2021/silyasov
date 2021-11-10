
namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class Employee
	{
		public Name Name;
		public Sex Sex;
		public ClothingSize ClothingSize;
		public ShoesSize ShoesSize;
		public HireDate HireDate;

		public Employee(Name name, Sex sex, ClothingSize clothingSize, ShoesSize shoesSize, HireDate hireDate)
		{
			Name = name;
			Sex = sex;
			ClothingSize = clothingSize;
			ShoesSize = shoesSize;
			HireDate = hireDate;
		}
	}
}