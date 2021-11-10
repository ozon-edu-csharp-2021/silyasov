using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CSharpCourse.Core.Lib.Enums;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.AggregationModels.MerchRequestAggregate.Interfaces;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchRequestAggregate
{
	public class MerchRequestRepository : IMerchRequestRepository
	{
		public IUnitOfWork UnitOfWork { get; }

		private List<MerchRequest> _merchRequests = new List<MerchRequest>()
		{
			new MerchRequest(1, 1, 3, EventType.GetMerchByRequest,
				MerchRequestStatus.NewRequest),
			new MerchRequest(2,1, 4, EventType.ConferenceListener,
				MerchRequestStatus.EmployeeGotMerch),
			new MerchRequest(3,2, 1, EventType.NewEmployee,
				MerchRequestStatus.EmployeeGotMerch),
		};
		
		public Task<MerchRequest> CreateAsync(MerchRequest itemToCreate, CancellationToken cancellationToken = default)
		{
			throw new System.NotImplementedException();
		}

		public Task<MerchRequest> UpdateAsync(MerchRequest itemToUpdate, CancellationToken cancellationToken = default)
		{
			throw new System.NotImplementedException();
		}

		public async Task<bool> CheckEmployeeHasMerch(int employeeId, int merchPackId, CancellationToken token)
		{
			return await Task.FromResult(!_merchRequests
				.Any(mr => mr.EmployeeId == employeeId && mr.MerchPackId == merchPackId)
			);
		}

		public Task SetStatusToMerchRequest(int merchRequestId, MerchRequestStatus status, CancellationToken token)
		{
			var temp = _merchRequests.FirstOrDefault(mr => mr.Id == merchRequestId);
			if (temp != null) 
				temp.Status = status;
			return null;
		}

		public async Task<IEnumerable<int>> GetMerchPacksReceivedByEmployee(int employeeId, CancellationToken token)
		{
			return await Task.FromResult(_merchRequests.Select(mr => mr.MerchPackId));
		}

		public Task<EventType> GetEmployeeEventType(int merchRequestId, CancellationToken token)
		{
			throw new System.NotImplementedException();
		}

		public Task<int> AddNewMerchRequest(int employeeId, int merchPackId, EventType eventType)
		{
			var maxId = _merchRequests.Max(mr => mr.Id);
			var request = new MerchRequest(maxId+1, employeeId, merchPackId, eventType, MerchRequestStatus.NewRequest);
			_merchRequests.Add(request);
			return Task.FromResult(maxId+1);
		}

		public Task DeleteMerchRequest(int merchRequestId)
		{
			var temp = _merchRequests.FirstOrDefault(mr => mr.Id == merchRequestId);
			_merchRequests.Remove(temp);
			return null;
		}
	}
}