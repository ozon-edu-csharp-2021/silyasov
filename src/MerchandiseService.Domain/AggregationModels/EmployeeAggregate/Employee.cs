using System.Collections.Generic;
using System.Linq;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class Employee : Entity
	{
		private string _firstName;
		private string _lastName;
		private Sex _sex;
		private ClothingSize _clothingSize;
		private HireDate _hireDate;

		private readonly ICollection<MerchPack> _merchPacks = new List<MerchPack>();

		public Employee(int id, string firstName, string lastName, Sex sex, ClothingSize clothingSize, HireDate hireDate)
		{
			Id = id;
			_firstName = firstName;
			_lastName = lastName;
			_sex = sex;
			SetClothingSize(clothingSize);
			_hireDate = hireDate;
		}

		public void SetClothingSize(ClothingSize size)
		{
			_clothingSize = size ?? throw new NegativeValueException("Указан неправильный размер.");
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