using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
		public async Task<string> RequestMerchAsync(int merchRequestId, CancellationToken token)
		{
			var eventType = await _merchRequestRepository.GetEmployeeEventType(merchRequestId, token);

			if (eventType == EventType.GetMerchByRequest)
			{
				var employeeHasMerch = await _merchRequestRepository.CheckEmployeeHasMerch(merchRequestId, token);
				if (!employeeHasMerch)
					return $"Employee already has merch pack!";
			}
			
			//Здесь должен быть запрос к stockApi, проверяющий, есть ли мерч на складе
			
			var stockHasMerch = true;
			if (!stockHasMerch)
			{
				await _merchRequestRepository.SetStatusToMerchRequest(merchRequestId, MerchRequestStatus.NotInStock, token);
				return "Merch is out of stock!";
			}
			
			//Здесь должен быть запрос к stockApi, резервирующий мерч для сотрудника
			
			await _merchRequestRepository.SetStatusToMerchRequest(merchRequestId, MerchRequestStatus.EmployeeGotMerch, token);
			
			return "Employee got a merch pack!";
		}

		public async Task<IEnumerable<MerchPackType>> GetMerchPacksReceivedByEmployeeAsync(int employeeId, CancellationToken token)
		{
			return await _merchRequestRepository.GetMerchPacksReceivedByEmployee(employeeId, token);
		}
	}
}