using BasecampAPI.Attributes;
using Microsoft.AspNetCore.Http.Features;
using System.Net;

namespace BasecampAPI.MiddleWares
{
	public class CustomErrorHandlingMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;

				if (endpoint != null)
				{
					var attribute = endpoint?.Metadata.GetMetadata<UnhandledExceptionAttribute>();
					context.Response.ContentType = "application/problem+json";
					context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

					if (attribute != null)
					{
						await context.Response.WriteAsync($"Error occured :: {attribute}");
					}
                    {
						await context.Response.WriteAsync("The API has logged an unhandled exception");
					}
                }

			}
		}
	}
}
