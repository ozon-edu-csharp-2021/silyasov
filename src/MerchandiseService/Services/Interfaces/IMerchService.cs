using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Services.Interfaces
{
	public interface IMerchService
	{
		Task<int> RequestMerchAsync(int merchId, CancellationToken token);
		Task<string> GetInfoAboutMerchAsync(int merchId, CancellationToken token);
	}
}