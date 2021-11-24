using System.Collections.Generic;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Exceptions;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
	public class MerchPackTests
	{
		MerchPack TestPack = new (
			1, 
		new Dictionary<MerchItem, int>
		{ 
			{new("Black", MerchItemType.Pen, new(222222)), 2},
			{new("White", MerchItemType.Notebook, new(111111)),1}
		}, 
		MerchPackType.StarterPack);
		
		[Fact]
		public void SetMerchPackStatus_Correct_Exception()
		{
			TestPack.SetStatus(MerchPackStatus.Received);
			Assert.Throws<InvalidStatusException>(() => TestPack.SetStatus(MerchPackStatus.NotInStock));
		}
	}
}