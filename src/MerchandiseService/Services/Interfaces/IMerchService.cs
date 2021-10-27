using System.Threading;

namespace MerchandiseService.Services.Interfaces
{
	public interface IMerchService
	{
		int RequestMerch(int merchId, CancellationToken token);
		string GetInfoAboutMerch(int merchId, CancellationToken token);
	}
}