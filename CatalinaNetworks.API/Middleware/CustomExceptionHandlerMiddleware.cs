using System.Net;

namespace CatalinaNetworks.API.Middleware
{
    internal class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            string result = string.Empty;
            // TODO : доделать обработку исключений
        }
    }
}
