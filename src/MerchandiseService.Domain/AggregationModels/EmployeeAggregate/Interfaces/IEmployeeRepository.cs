using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces
{
	public interface IEmployeeRepository : IRepository<Employee>
	{
		/// <summary>
		/// Проверка, выдавался ли уже мерчпак сотруднику
		/// </summary>
		/// <param name="employeeId"></param>
		/// <param name="merchPackId"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		Task<bool> CheckEmployeeHasMerchPack(int employeeId, int merchPackId, CancellationToken token);

		/// <summary>
		/// Проставление в БД статус запроса
		/// </summary>
		/// <param name="employeeId"></param>
		/// <param name="merchPackId"></param>
		/// <param name="status"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		Task<bool> SetStatusToMerchRequest(int employeeId, int merchPackId, MerchPackStatus status, CancellationToken token);
		
		/// <summary>
		/// Возвращение списка мерчпаков, уже полученных сотрудником 
		/// </summary>
		/// <param name="employeeId"></param>
		/// <param name="token"></param>
		/// <returns></returns>
		Task<IEnumerable<string>> GetMerchPacksReceivedByEmployee(int employeeId, CancellationToken token);
		
		/// <summary>
		/// Добавление нового мерчпака
		/// </summary>
		/// <param name="employeeId"></param>
		/// <param name="merchPackId"></param>
		/// <param name="eventType"></param>
		/// <returns></returns>
		Task<bool> AddNewMerchPack(int employeeId, int merchPackId, EventType eventType);
		/// <summary>
		/// Проверка, существует ли сотрудник
		/// </summary>
		/// <param name="employeeId"></param>
		/// <returns></returns>
		Task<bool> HasEmployee(int employeeId);
	}
}