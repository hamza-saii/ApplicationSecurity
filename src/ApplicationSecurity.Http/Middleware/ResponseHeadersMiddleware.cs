namespace ApplicationSecurity.Http.Middleware
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;

    public class ResponseHeadersMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.Headers.Add("referrer-policy", new StringValues("strict-origin-when-cross-origin"));
            await next(context);
        }
    }
}
