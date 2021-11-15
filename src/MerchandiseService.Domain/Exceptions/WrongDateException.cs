using System;

namespace MerchandiseService.Domain.Exceptions
{
	public class WrongDateException : Exception
	{
		public WrongDateException(string message) : base(message)
		{
		}
        
		public WrongDateException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}