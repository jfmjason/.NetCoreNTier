using BA.UI.WebV2.Custom;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Extension
{
  
        public static class AuthenticationExtensions
        {
            public static AuthenticationBuilder AddCustomAuthentication(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<AuthenticationSchemeOptions> configureOptions)
            {
                return builder.AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>(authenticationScheme, displayName, configureOptions);
            }
        }
    
}
