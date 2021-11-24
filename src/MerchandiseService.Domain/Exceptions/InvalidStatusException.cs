using System;

namespace MerchandiseService.Domain.Exceptions
{
	public class InvalidStatusException : Exception
	{
		public InvalidStatusException(string message) : base(message)
		{
            
		}
        
		public InvalidStatusException(string message, Exception innerException) : base(message, innerException)
		{
            
		}
	}
}