using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Infrastructure.MediatR.Requests;
using MerchandiseService.Infrastructure.Services.Interfaces;

namespace MerchandiseService.Infrastructure.MediatR.Handlers
{
	public class MerchRequestHandler: IRequestHandler<MerchRequest, string>
	{
		private readonly IMerchService _merchService;

		public MerchRequestHandler(IMerchService merchService)
		{
			_merchService = merchService;
		}

		public async Task<string> Handle(MerchRequest request, CancellationToken token)
		{
			var result = await _merchService.RequestMerchAsync(request.EmployeeId, request.MerchPackId, request.EventType,token);
			return result;
		}
	}
}