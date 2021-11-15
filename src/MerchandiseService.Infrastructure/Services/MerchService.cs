using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces;
using MerchandiseService.Infrastructure.Services.Interfaces;

namespace MerchandiseService.Infrastructure.Services
{
	public class MerchService : IMerchService
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IMerchPackRepository _merchPackRepository;

		public MerchService(IEmployeeRepository employeeRepository, IMerchPackRepository merchPackRepository)
		{
			_employeeRepository = employeeRepository;
			_merchPackRepository = merchPackRepository;
		}
		public async Task<string> RequestMerchAsync(int employeeId, int merchPackId, EventType eventType, CancellationToken token)
		{
			if (!await _employeeRepository.HasEmployee(employeeId))
				return $"Employee not found!";
			
			if (!await _merchPackRepository.HasMerchPack(merchPackId))
				return $"MerchPack not found!";
			
				
			if (eventType == EventType.GetMerchByRequest)
			{
				var employeeHasMerch = await _employeeRepository.CheckEmployeeHasMerchPack(employeeId, merchPackId, token);
				if (!employeeHasMerch)
					return $"Employee already has merch pack!";
			}

			await _employeeRepository.AddNewMerchPack(employeeId, merchPackId, eventType);
			
			//TODO запрос к stockApi, проверяющий, есть ли мерч на складе
			
			var stockHasMerch = true;
			if (!stockHasMerch)
			{
				await _employeeRepository.SetStatusToMerchRequest(employeeId, merchPackId, MerchPackStatus.NotInStock, token);
				return "Merch is out of stock!";
			}
			
			//TODO запрос к stockApi, резервирующий мерч для сотрудника
			
			_employeeRepository.SetStatusToMerchRequest(employeeId, merchPackId, MerchPackStatus.Received, token);
			
			return await Task.FromResult("Merch pack reserved to employee!");
		}

		public async Task<string> GetMerchPacksReceivedByEmployeeAsync(int employeeId, CancellationToken token)
		{
			return await _employeeRepository.GetMerchPacksReceivedByEmployee(employeeId, token);
		}
	}
}