using System.Threading.Tasks;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Services.Interfaces;

namespace MerchandiseService.GrpcServices
{
	public class MerchandiseGrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
	{
		private readonly IMerchService _merchService;

        public MerchandiseGrpcService(IMerchService merchService)
        {
            _merchService = merchService;
        }

        public override async Task<GetMerchResponse> GetMerch(
            GetMerchRequest request,
            ServerCallContext context)
        {
            var merchId = _merchService.RequestMerch(request.ItemId, context.CancellationToken);
            return new GetMerchResponse
            {
                ItemId = merchId,
                ItemName = "grpcMerch"
            };
        }

        public override async Task<GetMerchInfoResponse> GetMerchInfo  (GetMerchRequest request, ServerCallContext context)
        {
            var merchInfo = _merchService.GetInfoAboutMerch(request.ItemId, context.CancellationToken);
            return new GetMerchInfoResponse
            {
                ItemId = request.ItemId,
                ItemName = merchInfo
            };
        }
	}
}