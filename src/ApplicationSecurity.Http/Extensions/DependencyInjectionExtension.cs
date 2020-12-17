namespace ApplicationSecurity.Http.Extensions
{
    using ApplicationSecurity.Http.Headers;
    using ApplicationSecurity.Http.Middleware;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class DependencyInjectionExtension
    {
        public static IServiceCollection ConfigureSecurityServices(this IServiceCollection serviceCollection)
        {
            // Register policy headers
            serviceCollection.TryAddSingleton<ReferrerPolicyHeader>();

            return serviceCollection.AddSingleton<ResponseHeadersMiddleware>();
        }

        public static IApplicationBuilder UseSecurityServices(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ResponseHeadersMiddleware>();
        }
    }
}
