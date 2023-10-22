using AspNetCore.SecurityHeaders.Addons.PermissionsPolicy;
using Joonasw.AspNetCore.SecurityHeaders;
using Joonasw.AspNetCore.SecurityHeaders.FeaturePolicy.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NFluent;

namespace AspNetCore.SecurityHeaders.Addons.Tests
{
    public class PermissionsPolicyMiddlewareTests
    {
        private const string headerName = "Permissions-Policy";

        [Fact]
        public async Task Given_PermissionPolicy_When_ConfigureSecurityHeaders_Then_CheckPermissionsPolicyHeaderAddedCorrectly()
        {
            string headerValue = null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers[headerName];
                return Task.CompletedTask;
            };
            var options = Options.Create(new FeaturePolicyOptions
            {
                Autoplay = new FeaturePolicyAutoplayOptions
                {
                    AllowSelf = true
                },
                Payment = new FeaturePolicyPaymentOptions
                {
                    AllowNone = true
                },
                Speaker = new FeaturePolicySpeakerOptions
                {
                    AllowSelf = true,
                    AllowedOrigins = new List<string>
                    {
                        "https://site1",
                        "https://site2"
                    }
                },
                Other = new Dictionary<string, FeaturePolicyOptionsBase>
                {
                    ["some-new-one"] = new FeaturePolicyOtherFeatureOptions("some-new-one")
                    {
                        AllowSelf = true
                    }
                }
            });
            var mockContext = new DefaultHttpContext();
            var sut = new PermissionsPolicyMiddleware(mockNext, options);

            await sut.Invoke(mockContext);

            Assert.Equal("speaker 'self' https://site1 https://site2; payment 'none'; autoplay 'self'; some-new-one 'self'", headerValue);
        }

        [Fact]
        public async Task Given_NullOptions_When_ConfigureSecurityHeaders_Then_ThrowArgumentNullException()
        {
            string headerValue = null;
            RequestDelegate mockNext = (HttpContext ctx) =>
            {
                headerValue = ctx.Response.Headers[headerName];
                return Task.CompletedTask;
            };
            var mockContext = new DefaultHttpContext();
            Check.ThatCode(() => new PermissionsPolicyMiddleware(mockNext, null)).Throws<ArgumentNullException>();
        }
    }
}