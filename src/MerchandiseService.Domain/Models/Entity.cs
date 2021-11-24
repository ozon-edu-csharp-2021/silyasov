using System;
using System.Collections.Generic;
using MediatR;

namespace MerchandiseService.Domain.Models
{
	public abstract class Entity
	{
		int? _requestedHashCode;
		public virtual int Id { get; protected set; }

		private List<INotification> _domainEvents;
		public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

		public void AddDomainEvent(INotification eventItem)
		{
			_domainEvents ??= new List<INotification>();
			_domainEvents.Add(eventItem);
		}

		public void RemoveDomainEvent(INotification eventItem)
		{
			_domainEvents?.Remove(eventItem);
		}

		public void ClearDomainEvents()
		{
			_domainEvents?.Clear();
		}

		public bool IsTransient()
		{
			return this.Id == default(Int32);
		}

		public override bool Equals(object obj)
		{
			if (obj is not Entity entity)
				return false;

			if (object.ReferenceEquals(this, entity))
				return true;

			if (this.GetType() != entity.GetType())
				return false;

			if (entity.IsTransient() || IsTransient())
				return false;
			else
				return entity.Id == Id;
		}

		public override int GetHashCode()
		{
			if (!IsTransient())
			{
				if (!_requestedHashCode.HasValue)
					_requestedHashCode = HashCode.Combine(Id, 31);

				return _requestedHashCode.Value;
			}
			else
				return base.GetHashCode();

		}
		public static bool operator ==(Entity left, Entity right)
		{
			return Object.Equals(left, null) 
				? Object.Equals(right, null) 
				: left.Equals(right);
		}

		public static bool operator !=(Entity left, Entity right)
		{
			return !(left == right);
		}
	}
}