using AspNetCore.SecurityHeaders.Addons.PermissionsPolicy;
using Joonasw.AspNetCore.SecurityHeaders;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

namespace AspNetCore.SecurityHeaders.Addons.Extensions
{
    /// <summary>
    /// Extensions for adding security header in the request pipelines.
    /// </summary>
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Adds a Permissions Policy headerto the response.
        /// See https://github.com/WICG/feature-policy/blob/master/features.md for more information
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <param name="builderAction">Configuration action for the header.</param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UsePermissionsPolicy(this IApplicationBuilder app, Action<FeaturePolicyBuilder> builderAction)
        {
            var builder = new FeaturePolicyBuilder();
            builderAction(builder);

            var options = builder.BuildFeaturePolicyOptions();

            return app.UseMiddleware<PermissionsPolicyMiddleware>(new OptionsWrapper<FeaturePolicyOptions>(options));
        }

        /// <summary>
        /// Adds a Feature Policy header to the response.
        /// See https://github.com/WICG/feature-policy/blob/master/features.md for more information
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/></param>
        /// <returns>The <see cref="IApplicationBuilder"/></returns>
        public static IApplicationBuilder UsePermissionsPolicy(this IApplicationBuilder app)
        {
            return app.UseMiddleware<PermissionsPolicyMiddleware>();
        }
    }
}