namespace BasecampAPI.Attributes
{
	public class UnhandledExceptionAttribute : Attribute
	{
		public UnhandledExceptionAttribute(int errorCode)
		{
			this.ErrorCode = errorCode;
		}

		public int ErrorCode { get; set; }
    }
}
