using AspNetCore.SecurityHeaders.Addons.Extensions;
using Joonasw.AspNetCore.SecurityHeaders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.SecurityHeaders.Addons.Tests
{
    public class AppBuilderExtensionsTests
    {
        [Fact]
        public void When_AddServiceToAspNetPipeline_Then_CheckServiceIsAdded()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddCsp();
            var provider = services.BuildServiceProvider();
            IApplicationBuilder app = new ApplicationBuilder(provider);
            app.UseFeaturePolicy();
            app.UsePermissionsPolicy();
            app.UseCsp();
        }

        [Fact]
        public void Given_ExistingPipeline_When_AddServiceToAspNetPipeline_Then_CheckServiceIsAdded()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddCsp();
            var provider = services.BuildServiceProvider();
            IApplicationBuilder app = new ApplicationBuilder(provider);
            app.UseFeaturePolicy();
            app.UsePermissionsPolicy(config =>
            {
                config.AllowOtherFeature("everything");
            });
            app.UseCsp();
        }
    }
}