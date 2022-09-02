namespace YuraSoft.ExceptionHandler
{
	/// <summary>
	/// Handable exception interface
	/// </summary>
	public interface IHandableException
	{
		/// <summary>
		/// Get exception response method
		/// </summary>
		/// <returns>Returns exception response</returns>
		public IExceptionResponse ToExceptionResponse();
	}
}
