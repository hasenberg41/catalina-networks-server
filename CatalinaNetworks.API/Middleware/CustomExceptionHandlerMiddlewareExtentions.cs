namespace CatalinaNetworks.API.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHundler(this IApplicationBuilder application)
        {
            return application.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
