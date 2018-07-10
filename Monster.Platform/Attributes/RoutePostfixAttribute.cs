using System;

namespace Monster.Platform.Attributes
{
    public sealed class RoutePostfixAttribute: Attribute
    {
        public RoutePostfixAttribute(string postfix)
        {
            Postfix = postfix;
        }

        public string Postfix { get; }
    }
}
