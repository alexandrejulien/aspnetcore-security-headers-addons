using Joonasw.AspNetCore.SecurityHeaders;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace AspNetCore.SecurityHeaders.Addons.PermissionsPolicy
{
    /// <summary>
    /// Permissions Policy middelware based on old-naming Features-Policy.
    /// </summary>
    public class PermissionsPolicyMiddleware
    {
        /// <summary>
        /// HTTP Security Header name for permissions policy.
        /// </summary>
        private const string HeaderName = "Permissions-Policy";

        /// <summary>
        /// Request Delegate.
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Head value.
        /// </summary>
        private readonly string _headerValue;

        /// <summary>
        /// Construct with feature policy options.
        /// </summary>
        /// <param name="next">Request delegate.</param>
        /// <param name="options">Options.</param>
        /// <exception cref="ArgumentNullException">Options.</exception>
        public PermissionsPolicyMiddleware(RequestDelegate next, IOptions<FeaturePolicyOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _next = next;
            _headerValue = options.Value.ToString();
        }

        /// <summary>
        /// Invoke http context.
        /// </summary>
        /// <param name="context">Http Context.</param>
        /// <returns>Request delegate.</returns>
        public async Task Invoke(HttpContext context)
        {
            if (!ContainsPermissionsPolicyHeader(context.Response))
            {
                context.Response.Headers.Add(HeaderName, _headerValue);
            }
            await _next.Invoke(context);
        }

        /// <summary>
        /// Check headers contains Permissions Policy header.
        /// </summary>
        /// <param name="response">Http Response.</param>
        /// <returns>True if permissions policy are present.</returns>
        private static bool ContainsPermissionsPolicyHeader(HttpResponse response)
            => response.Headers.Any(h =>
            h.Key.Equals(HeaderName, StringComparison.OrdinalIgnoreCase));
    }
}