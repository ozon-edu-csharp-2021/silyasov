using System;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.Exceptions;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
	public class EmployeeTests
	{
		[Fact]
		public void SetHireDate_Correct_Success()
		{
			var employee = 
				new Employee(
					2, 
					"Петр", 
					"Иванов", 
					Sex.Male,
					ClothingSize.XL, 
					new HireDate(DateTime.Now-TimeSpan.FromHours(1))
					);
			Assert.True(employee != null);
		}

		[Fact]
		public void SetHireDate_Correct_Exception()
		{
			Assert.Throws<WrongDateException>(() => new Employee(
				2, 
				"Петр", 
				"Иванов", 
				Sex.Male,
				ClothingSize.XL, 
				new HireDate(DateTime.Now+TimeSpan.FromHours(1))
			));
		}
	}
}