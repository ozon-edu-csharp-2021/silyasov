using System;
using System.Collections.Generic;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class MerchPack : Entity
	{
		 private string Name { get; }
		 private ICollection<MerchItem> MerchItems { get; } = new List<MerchItem>();
		 public MerchPackType Type { get; private set; }

		 private MerchPackStatus _status;
		 public MerchPackStatus Status
		 {
			 get => _status;
			 set => _status = value;
		 }
		
		public MerchPack(int id, ICollection<MerchItem> merchItems, MerchPackType type, MerchPackStatus status)
		{
			Id = id;
			Name = type.Name;
			Type = type;
			Status = status;
			AddMerchItems(merchItems);
		}

		private void AddMerchItems(ICollection<MerchItem> merchItems)
		{
			var items = Type.GetMerchItemTypesList();
			if (items.Count != merchItems.Count)
				throw new Exception("Wrong num of elements in collection!");
			foreach (var merchItem in merchItems) 
				MerchItems.Add(merchItem);
		}
	}
}