namespace YuraSoft.ExceptionHandler
{
	/// <summary>
	/// Handable exception interface
	/// </summary>
	public interface IHandableException
	{
		public IExceptionResponse ToExceptionResponse();
	}
}
