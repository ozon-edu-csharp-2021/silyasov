using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
	public class EmployeeRepositoryStub : IEmployeeRepository
	{
		public IUnitOfWork UnitOfWork { get; }

		private List<Employee> _employees = new()
		{
			new Employee(
				1,
				"Иван",
				"Волков",
				Sex.Male, 
				ClothingSize.XL,
				new HireDate(DateTime.Now))
		};

		private IMerchPackRepository _merchPackRepository;

		public EmployeeRepositoryStub(IMerchPackRepository merchPackRepository)
		{
			_merchPackRepository = merchPackRepository;
		}

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
			var merchPack = await _merchPackRepository.GetMerchPackById(merchPackId);
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
	}
}