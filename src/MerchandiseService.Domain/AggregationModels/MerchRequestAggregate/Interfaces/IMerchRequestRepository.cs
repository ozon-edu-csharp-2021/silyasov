using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.Core.Lib.Enums;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Interfaces
{
	public interface IMerchRequestRepository : IRepository<MerchRequest>
	{
		//Запрос в БД с проверкой, выдавался ли уже мерч сотруднику
		Task<bool> CheckEmployeeHasMerch(int merchRequestId, CancellationToken token);
		
		//Метод, проставляющий в БД в статус запроса
		Task SetStatusToMerchRequest(int merchRequestId, MerchRequestStatus status, CancellationToken token);
		
		//Возвращает список мерча, уже полученный сотрудником 
		Task<IEnumerable<MerchPackType>> GetMerchPacksReceivedByEmployee(int employeeId, CancellationToken token);
		
		Task<EventType> GetEmployeeEventType(int merchRequestId, CancellationToken token);
	}
}