using MediatR;

namespace MerchandiseService.Infrastructure.MediatR.Requests
{
	public class EmployeeRequest : IRequest<string>
	{
		public int EmployeeId;

		public EmployeeRequest(int employeeId)
		{
			EmployeeId = employeeId;
		}
	}
}