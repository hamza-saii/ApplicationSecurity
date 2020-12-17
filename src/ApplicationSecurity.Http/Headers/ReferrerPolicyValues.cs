namespace ApplicationSecurity.Http.Headers
{
    using System.ComponentModel;

    public enum ReferrerPolicyValues
    {
        [Description("no-referrer")]
        NoReferrer,

        [Description("no-referrer-when-downgrade")]
        NoReferrerWhenDowngrade,

        [Description("origin")]
        Origin,

        [Description("origin-when-cross-origin")]
        OriginWhenCrossOrigin,

        [Description("same-origin")]
        SameOrigin,

        [Description("strict-origin")]
        StrictOrigin,

        [Description("strict-origin-when-cross-origin")]
        StrictOriginWhenCrossOrigin,

        [Description("unsafe-url")]
        UnsafeUrl,
}
}
