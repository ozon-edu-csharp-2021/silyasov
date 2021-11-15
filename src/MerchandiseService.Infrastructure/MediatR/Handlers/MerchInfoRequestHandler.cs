using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Infrastructure.MediatR.Requests;
using MerchandiseService.Infrastructure.Services.Interfaces;

namespace MerchandiseService.Infrastructure.MediatR.Handlers
{
	public class MerchInfoRequestHandler : IRequestHandler<EmployeeRequest, string>
	{
		private IMerchService _merchService;

		public MerchInfoRequestHandler(IMerchService merchService)
		{
			_merchService = merchService;
		}

		public async Task<string> Handle(EmployeeRequest request, CancellationToken token)
		{
			var result = await _merchService.GetMerchPacksReceivedByEmployeeAsync(request.EmployeeId, token);
			return result;
		}
	}
}