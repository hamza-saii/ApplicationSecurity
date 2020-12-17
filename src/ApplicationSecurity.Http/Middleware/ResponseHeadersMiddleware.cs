namespace ApplicationSecurity.Http.Middleware
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ApplicationSecurity.Http.Headers;
    using Microsoft.AspNetCore.Http;

    public class ResponseHeadersMiddleware : IMiddleware
    {
        private readonly ICollection<AbstractHeader> _headersCollection;

        public ResponseHeadersMiddleware(ReferrerPolicyHeader referrerPolicyHeader)
        {
            _headersCollection = new List<AbstractHeader>()
            {
                referrerPolicyHeader,
            };
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            foreach (var header in _headersCollection)
            {
                header.Configure(context);
            }

            await next(context);
        }
    }
}
