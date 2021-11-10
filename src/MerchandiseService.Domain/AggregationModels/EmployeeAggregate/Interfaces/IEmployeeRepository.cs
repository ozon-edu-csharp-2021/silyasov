using System.Threading.Tasks;
using MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Interfaces
{
	public interface IEmployeeRepository : IRepository<Employee>
	{
		
	}
}