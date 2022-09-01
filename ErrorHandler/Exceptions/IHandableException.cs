namespace YuraSoft.ErrorHandler
{
	/// <summary>
	/// Handable exception interface
	/// </summary>
	public interface IHandableException
	{
		public IErrorData GetErrorData();
	}
}
