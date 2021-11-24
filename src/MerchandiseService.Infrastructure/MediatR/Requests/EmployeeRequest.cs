using System.Collections.Generic;
using MediatR;

namespace MerchandiseService.Infrastructure.MediatR.Requests
{
	public class EmployeeRequest : IRequest<IEnumerable<string>>
	{
		public int EmployeeId;

		public EmployeeRequest(int employeeId)
		{
			EmployeeId = employeeId;
		}
	}
}