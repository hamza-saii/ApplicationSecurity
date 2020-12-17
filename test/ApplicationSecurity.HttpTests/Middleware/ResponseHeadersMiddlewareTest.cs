namespace ApplicationSecurity.HttpTests.Middleware
{
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ApplicationSecurity.Http.Middleware;
    using FluentAssertions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Xunit;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Primitives;

    public class ResponseHeadersMiddlewareTest
    {
        [Fact]
        public async Task ResponseHeadersMiddleware_DefaultConfiguration_ReturnsResponseWithAllHeadersAsync()
        {
            // Arrange
            using var host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder
                        .UseTestServer()
                        .ConfigureServices(services =>
                        {
                            services.AddSingleton<ResponseHeadersMiddleware>();
                        })
                        .Configure(app =>
                        {
                            app.UseMiddleware<ResponseHeadersMiddleware>();
                        });
                })
                .StartAsync();

            var exceptedHeaders = new Dictionary<string, string>()
            {
                ["referrer-policy"] = new StringValues("strict-origin-when-cross-origin"),
            };

            // Act
            using var response = await host.GetTestClient().GetAsync("/");

            // Assert
            foreach (var exceptedHeader in exceptedHeaders)
            {
                var header = response.Headers.SingleOrDefault(i =>
                    i.Key.Equals(exceptedHeader.Key, StringComparison.OrdinalIgnoreCase));

                header.Should().NotBeNull();
                header.Value.Should().BeEquivalentTo(new List<string>() { exceptedHeader.Value });
            }

        }
    }
}
