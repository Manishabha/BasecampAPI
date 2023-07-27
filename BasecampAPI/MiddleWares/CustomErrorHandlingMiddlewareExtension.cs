
namespace BasecampAPI.MiddleWares
{
	public static class CustomErrorHandlingMiddlewareExtension
	{
		public static IApplicationBuilder UseCustomErrorHandlingMiddleWare(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CustomErrorHandlingMiddleware>();
		}
	}
}
