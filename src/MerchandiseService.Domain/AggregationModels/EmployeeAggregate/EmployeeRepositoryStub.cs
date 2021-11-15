using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class EmployeeRepositoryStub : IEmployeeRepository
	{
		public IUnitOfWork UnitOfWork { get; }

		private List<Employee> _employees = new List<Employee>()
		{
			new Employee(
				1,
				new Name("Иван Волков"), 
				new Sex("Мужской"), 
				new ClothingSize("XL"),
				new ShoesSize("44"),
				new HireDate(DateTime.Now))
		};
		
		private List<MerchPack> _merchPacks = new()
		{
			new MerchPack(
				1, 
				new List<MerchItem>
				{
					new("Black cup", MerchItemType.Cup, new(395444)),
					new("10% discount Tehnosila", MerchItemType.Coupon, new(443123))
				}, 
				MerchPackType.StarterPack, 
				MerchPackStatus.Requested)
		};
		
		public async Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
		{
			throw new System.NotImplementedException();
		}

		public async Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
		{
			throw new System.NotImplementedException();
		}

		public async Task<bool> CheckEmployeeHasMerchPack(int employeeId, int merchPackId, CancellationToken token)
		{
			return await Task.FromResult(!_employees
				.Any(e => e.Id == employeeId && e.HasMerchPack(merchPackId))
			);
		}

		async Task<string> IEmployeeRepository.GetMerchPacksReceivedByEmployee(int employeeId, CancellationToken token)
		{
			var result = _employees
				.FirstOrDefault(e => e.Id == employeeId)
				?.GetAllMerchPackTypes();
			return await Task.FromResult(result);
		}

		public async Task<bool> AddNewMerchPack(int employeeId, int merchPackId, EventType eventType)
		{
			var merchPack = _merchPacks
				.FirstOrDefault(mp => mp.Id == merchPackId);
			if (merchPack == null)
				return false;
			
			_employees
				.FirstOrDefault(e => e.Id == employeeId)
				?.AddNewMerchPack(merchPack);
			return true;
		}

		public async Task<bool> HasEmployee(int employeeId)
		{
			return _employees.Any(e => e.Id == employeeId);
		}
		public async Task<bool> HasMerchPack(int merchPackId)
		{
			return _merchPacks.Any(e => e.Id == merchPackId);
		}

		public async Task<bool> SetStatusToMerchRequest(int employeeId, int merchPackId, MerchPackStatus status, CancellationToken token)
		{
			var temp = _employees
				.FirstOrDefault(e => e.Id == employeeId)
				?.GetMerchPackById(merchPackId);
			if (temp == null)
				return false;
			
			temp.Status = status;
			return true;
		}
/*
		public Task<EventType> GetEmployeeEventType(int merchRequestId, CancellationToken token)
		{
			throw new System.NotImplementedException();
		}

		public Task<int> AddNewMerchRequest(int employeeId, int merchPackId, EventType eventType)
		{
			var maxId = _merchRequests.Max(mr => mr.Id);
			var request = new MerchRequest(maxId+1, employeeId, merchPackId, eventType, MerchPackStatus.MerchPackRequested);
			_merchRequests.Add(request);
			return Task.FromResult(maxId+1);
		}

		public Task DeleteMerchRequest(int merchRequestId)
		{
			var temp = _merchRequests.FirstOrDefault(mr => mr.Id == merchRequestId);
			_merchRequests.Remove(temp);
			return null;
		}*/
	}
}