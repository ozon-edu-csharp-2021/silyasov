using MerchandiseService.Grpc;
using MerchandiseService.Infrastructure.MediatR.Requests;

namespace MerchandiseService.Api.GrpcServices.Extensions
{
	public static class GetMerchInfoRequestExtension
	{
		public static EmployeeRequest ToMediatorEmployeeRequest(this GetMerchInfoRequest getMerchInfoRequest)
		{
			return new EmployeeRequest(getMerchInfoRequest.EmployeeId);
		}
	}
}