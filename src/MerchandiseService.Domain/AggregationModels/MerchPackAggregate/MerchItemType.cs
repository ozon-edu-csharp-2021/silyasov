using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class MerchItemType:Enumeration
	{
		public static MerchItemType Socks = new(1, "Socks");
		public static MerchItemType Cup = new(2, "Cup");
		public static MerchItemType Notebook = new(3, "Notebook");
		public static MerchItemType Pen = new(4, "Pen");
		public static MerchItemType Coupon = new(5, "Coupon");
		public static MerchItemType Watch = new(6, "Watch");

		private MerchItemType(int id, string name) : base(id, name)
		{
		}
	}
}