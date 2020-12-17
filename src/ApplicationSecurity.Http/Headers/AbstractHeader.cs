namespace ApplicationSecurity.Http.Headers
{
    using Microsoft.AspNetCore.Http;

    public abstract class AbstractHeader
    {
        public abstract void Configure(HttpContext httpContext);
    }
}
