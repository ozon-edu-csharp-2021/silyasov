using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Grpc;
using MerchandiseService.Infrastructure.MediatR.Requests;

namespace MerchandiseService.Api.GrpcServices.Extensions
{
	public static class GetMerchRequestExtension
	{
		public static MerchRequest ToMediatorMerchRequest(this GetMerchRequest getMerchRequest)
		{
			return new MerchRequest(
				getMerchRequest.EmployeeId,
				getMerchRequest.MerchPackId,
				EventType.GetMerchByRequest);
		}
	}
}