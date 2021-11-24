using System.Threading.Tasks;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate.Interfaces
{
	public interface IMerchPackRepository : IRepository<MerchPack>
	{
		/// <summary>
		/// Получение мерчпака по Id
		/// </summary>
		/// <param name="merchPackId"></param>
		/// <returns></returns>
		Task<MerchPack> GetMerchPackById(int merchPackId);
		
		/// <summary>
		/// Проверка, существует ли мерчпак
		/// </summary>
		/// <param name="merchPackId"></param>
		/// <returns></returns>
		Task<bool> HasMerchPack(int merchPackId);
	}
}