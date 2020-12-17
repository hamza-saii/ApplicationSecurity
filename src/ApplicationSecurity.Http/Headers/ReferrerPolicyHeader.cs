// The Referer (sic) header contains the address of the previous web page from which a link to the currently requested page was followed, which has lots of fairly innocent uses including analytics,
// logging, or optimized caching. However, there are more problematic uses such as tracking or stealing information, or even just side effects such as inadvertently leaking sensitive information.
// 
// For example, consider a "reset password" page with a social media link in a footer. If the link was followed,
// depending on how information was shared the social media site may receive the reset password URL and may still be able to use the shared information, potentially compromising a user's security.
// 
// By the same logic, an image hosted on a third party side but embedded in your page could result in sensitive information being leaked to the third party.
// Even if security is not compromised, the information may not be something the user wants shared.
// https://developer.mozilla.org/fr/docs/Web/HTTP/Headers/Referrer-Policy
// https://developer.mozilla.org/en-us/docs/Web/Security/Referer_header:_privacy_and_security_concerns

namespace ApplicationSecurity.Http.Headers
{
    using ApplicationSecurity.Http.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;

    public class ReferrerPolicyHeader : AbstractHeader
    {
        public override void Configure(HttpContext httpContext)
        {
            // by default, use no referrer, value will be configured based on user choice later
            httpContext.Response.Headers.Add(SecurityHeaderNames.ReferrerPolicyHeaderName, new StringValues(ReferrerPolicyValues.NoReferrer.GetDescription()));
        }
    }
}
