using System.Collections.Generic;
using System.Linq;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class Employee : Entity
	{
		private Name Name;
		private Sex Sex;
		private ClothingSize ClothingSize;
		private ShoesSize ShoesSize;
		private HireDate HireDate;

		private ICollection<MerchPack> _merchPacks = new List<MerchPack>();

		public Employee(int id, Name name, Sex sex, ClothingSize clothingSize, ShoesSize shoesSize, HireDate hireDate)
		{
			Id = id;
			Name = name;
			Sex = sex;
			ClothingSize = clothingSize;
			ShoesSize = shoesSize;
			HireDate = hireDate;
		}

		public bool HasMerchPack(int merchPackId)
		{
			return _merchPacks.Any(mp=> mp.Id == merchPackId);
		}

		public MerchPack GetMerchPackById(int merchPackId)
		{
			return _merchPacks.FirstOrDefault(mp=> mp.Id == merchPackId);
		}

		public string GetAllMerchPackTypes()
		{
			return string.Join(',', _merchPacks.Select(mp => mp.Type.Name));
		}

		public void AddNewMerchPack(MerchPack merchPack)
		{
			_merchPacks.Add(merchPack);
		}
	}
}