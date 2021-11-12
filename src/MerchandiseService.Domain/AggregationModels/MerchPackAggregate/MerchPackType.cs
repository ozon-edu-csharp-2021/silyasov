using System;
using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class MerchPackType : Enumeration
	{
		public static MerchPackType WelcomePack = new(1, "Welcome Pack", new List<MerchItemType>
		{
			MerchItemType.Cup
		});
		public static MerchPackType StarterPack = new(2, "Starter Pack", new List<MerchItemType>
		{
			MerchItemType.Cup,
			MerchItemType.Coupon
		});
		public static MerchPackType ConferenceListenerPack = new(3, "Conference Listener Pack", new List<MerchItemType>
		{
			MerchItemType.Notebook,
			MerchItemType.Pen
		});
		public static MerchPackType ConferenceSpeakerPack = new(4, "Conference Speaker Pack", new List<MerchItemType>
		{
			MerchItemType.Cup,
			MerchItemType.Notebook,
			MerchItemType.Pen
		});
		public static MerchPackType VeteranPack = new(5, "Veteran Pack", new List<MerchItemType>
		{
			MerchItemType.Watch,
			MerchItemType.Socks,
			MerchItemType.Coupon
		});

		private readonly ICollection<MerchItemType> _merchItems;

		public MerchPackType(int id, string name, ICollection<MerchItemType> merchItems) : base(id, name)
		{
			_merchItems = merchItems;
		}

		public ICollection<MerchItemType> GetMerchItemsList()
		{
			return _merchItems;
		}
	}
}