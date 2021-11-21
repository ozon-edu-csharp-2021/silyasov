using System;
using System.Collections.Generic;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
	public class MerchPack : Entity
	{
		 private string Name { get; }
		 /// <summary>
		 /// int - количество айтемов
		 /// </summary>
		 private Dictionary<MerchItem, int> MerchItems { get; } = new();
		 public MerchPackType Type { get; private set; }
		 public MerchPackStatus Status { get; private set; }
		
		public MerchPack(int id, Dictionary<MerchItem, int> merchItems, MerchPackType type)
		{
			Id = id;
			Name = type.Name;
			Type = type;
			Status = MerchPackStatus.Requested;
			AddMerchItems(merchItems);
		}

		private void AddMerchItems(Dictionary<MerchItem, int> merchItems)
		{
			var items = Type.GetMerchItemTypesList();
			if (items.Count != merchItems.Count)
				throw new Exception("Wrong num of elements in collection!");
			foreach (var merchItem in merchItems) 
				MerchItems.Add(merchItem.Key, merchItem.Value);
		}
		
		private void AddMerchItem(MerchItem merchItem, int quantity)
		{
			MerchItems.Add(merchItem, quantity);
		}

		public void SetStatus(MerchPackStatus status)
		{
			if (Status == MerchPackStatus.Received)
				throw new InvalidStatusException("Current status is \"Received\" and it cannot be changed.");
			if (Status == MerchPackStatus.NotInStock && status == MerchPackStatus.Requested)
				throw new InvalidStatusException("Invalid status change.");
			Status = status;
		}
	}
}