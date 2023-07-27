using System.Runtime.Serialization;

namespace BasecampAPI.Enums
{
	public enum ErrorCode 
	{
		[EnumMember(Value ="Board creation failed")]
		BoardCreateFailed
	}
}
