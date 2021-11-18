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
			var date = new HireDate(DateTime.Now - TimeSpan.FromHours(1));
			Assert.NotNull(date);
		}

		[Fact]
		public void SetHireDate_Correct_Exception()
		{
			Assert.Throws<WrongDateException>(() => 
				new HireDate(DateTime.Now + TimeSpan.FromHours(1)));
		}
	}
}