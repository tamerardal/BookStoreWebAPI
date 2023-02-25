using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;

public class CustomExceptionMiddleware
{
	private readonly RequestDelegate _next;
	public CustomExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}
	public async Task Invoke(HttpContext httpContext)
	{
		var watch = Stopwatch.StartNew();
		
		try
		{
			string message = "[Request] HTTP " + httpContext.Request.Method + " - " + httpContext.Request.Path;
			Console.WriteLine(message);
			await _next(httpContext);
			watch.Stop();
			message = "[Response] HTTP " + httpContext.Request.Method + " - " + httpContext.Request.Path + " responded " + httpContext.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + "ms.";
		}
		catch (Exception ex)
		{
			watch.Stop();
			await HandleException(httpContext, watch, ex);
		}
		
	}

	private Task HandleException(HttpContext httpContext, Stopwatch watch, Exception ex)
	{
		httpContext.Response.ContentType = "application/json";
		httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

		string message = "[ERROR] HTTP " + httpContext.Request.Method + " - " + httpContext.Response.StatusCode + " ERROR MESSAGE: " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + "ms.";
		
		var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
		
		return httpContext.Response.WriteAsync(result);
	}
}

public static class CustomExceptionMiddlewareExtention
{
	public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder applicationBuilder)
	{
		return applicationBuilder.UseMiddleware<CustomExceptionMiddleware>();
	}
}