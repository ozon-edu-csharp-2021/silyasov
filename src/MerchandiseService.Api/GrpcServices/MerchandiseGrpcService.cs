using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchandiseService.Infrastructure.Services.Interfaces;

namespace MerchandiseService.Api.GrpcServices
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
	        return null;
	        //    var response = await _merchService.RequestMerchAsync(request.MerchRequestId, context.CancellationToken);
	        /*    return new GetMerchResponse
	            {
	                Response = response
	            };*/
        }

        public override async Task<GetMerchInfoResponse> GetMerchInfo  (GetMerchInfoRequest request, ServerCallContext context)
        {
            var merchInfo = await _merchService.GetMerchPacksReceivedByEmployeeAsync(request.EmployeeId, context.CancellationToken);
            var merchPackTypes = merchInfo.Select(mi => mi);

            return new GetMerchInfoResponse()
            {
	            MerchPackType = string.Join(',', merchPackTypes)
            };
        }
	}
}