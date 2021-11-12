using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Infrastructure.Services.Interfaces;

namespace MerchandiseService.Infrastructure.Services
{
	public class MerchService : IMerchService
	{
		private readonly IEmployeeRepository _employeeRepository;

		public MerchService(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}
		public async Task<string> RequestMerchAsync(int employeeId, int merchPackId, EventType eventType, CancellationToken token)
		{
			if (!await _employeeRepository.HasEmployee(employeeId))
				return $"Employee not found!";
			
			if (!await _employeeRepository.HasMerchPack(merchPackId))
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