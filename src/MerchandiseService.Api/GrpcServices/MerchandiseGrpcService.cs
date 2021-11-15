using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using MerchandiseService.Api.GrpcServices.Extensions;
using MerchandiseService.Grpc;

namespace MerchandiseService.Api.GrpcServices
{
	public class MerchandiseGrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
	{
		private readonly IMediator _mediator;

        public MerchandiseGrpcService(IMediator mediator)
        {
	        _mediator = mediator;
        }

        public override async Task<GetMerchResponse> GetMerch(
            GetMerchRequest request,
            ServerCallContext context)
        {
	        var merchRequest = request.ToMediatorMerchRequest();
            var response = await _mediator.Send(merchRequest, context.CancellationToken);
             return new GetMerchResponse
             {
                 Response = response
             };
        }

        public override async Task<GetMerchInfoResponse> GetMerchInfo  (GetMerchInfoRequest request, ServerCallContext context)
        {
	        var employeeRequest = request.ToMediatorEmployeeRequest();
	        var result = await _mediator.Send(employeeRequest, context.CancellationToken);
	        
            return new GetMerchInfoResponse
            {
	            MerchPacks = result
            };
        }
	}
}