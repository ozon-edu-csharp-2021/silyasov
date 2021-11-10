using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.Core.Lib.Enums;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Interfaces;
using MerchandiseService.Infrastructure.Services.Interfaces;

namespace MerchandiseService.Infrastructure.Services
{
	public class MerchService : IMerchService
	{
		private readonly IMerchRequestRepository _merchRequestRepository;

		public MerchService(IMerchRequestRepository merchRequestRepository)
		{
			_merchRequestRepository = merchRequestRepository;
		}
		public async Task<string> RequestMerchAsync(int employeeId, int merchPackId, EventType eventType, CancellationToken token)
		{
			if (eventType == EventType.GetMerchByRequest)
			{
				var employeeHasMerch = await _merchRequestRepository.CheckEmployeeHasMerch(employeeId, merchPackId, token);
				if (!employeeHasMerch)
					return $"Employee already has merch pack!";
			}
			
			var merchRequestId = await _merchRequestRepository.AddNewMerchRequest(employeeId, merchPackId, eventType);
			
			//Здесь должен быть запрос к stockApi, проверяющий, есть ли мерч на складе
			
			var stockHasMerch = true;
			if (!stockHasMerch)
			{
				await _merchRequestRepository.SetStatusToMerchRequest(merchRequestId, MerchRequestStatus.NotInStock, token);
				return "Merch is out of stock!";
			}
			
			//Здесь должен быть запрос к stockApi, резервирующий мерч для сотрудника
			
			_merchRequestRepository.SetStatusToMerchRequest(merchRequestId, MerchRequestStatus.EmployeeGotMerch, token);
			
			return await Task.FromResult("Merch pack reserved to employee!");
		}

		public async Task<IEnumerable<int>> GetMerchPacksReceivedByEmployeeAsync(int employeeId, CancellationToken token)
		{
			return await _merchRequestRepository.GetMerchPacksReceivedByEmployee(employeeId, token);
		}
	}
}