using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Brudnopis
{
    internal class IdentityServerGrantTypesTest
    {
        public void Test()
        {
            var flow = IdentityServerFlows.ClientCredentials;
            var grt = flow.ToGrantTypes();
        }
    }

    static class IdentityServerExtensions
    {
        public static ICollection<string> ToGrantTypes(this IdentityServerFlows flowType)
        {

            PropertyInfo[] properties = typeof(GrantTypes).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object val = property.GetValue(property);
                if (val is string[]
                    && ((string[])val).Count() == 1
                    && flowType.GetEnumDescription() == ((string[])val)[0])
                {
                    return (ICollection<string>)val;
                }
            }

            return new string[0];
        }
    }

    enum IdentityServerFlows
    {
        /// <summary>
        /// List of IdentityServer hybrid flow
        /// https://github.com/IdentityServer/Documentation/issues/73
        /// </summary>
        [Description("authorization_code")]
        AuthorizationCode = 0,  //introduced in OAuth2 then extended by OIDC.
        [Description("implicit")]
        Implicit = 1,           //introduced in OAuth2 then extended by OIDC.
        [Description("hybrid")]
        Hybrid = 2,             //introduced in OIDC
        [Description("client_credentials")]
        ClientCredentials = 3,  //OIDC specs didn't extend this flow.
        [Description("None")]
        None = 4
    }
    class GrantTypes
    {
        public static ICollection<string> Implicit => new string[1]
        {
            "implicit"
        };

        public static ICollection<string> ImplicitAndClientCredentials => new string[2]
        {
            "implicit",
            "client_credentials"
        };

        public static ICollection<string> Code => new string[1]
        {
            "authorization_code"
        };

        public static ICollection<string> CodeAndClientCredentials => new string[2]
        {
            "authorization_code",
            "client_credentials"
        };

        public static ICollection<string> Hybrid => new string[1]
        {
            "hybrid"
        };

        public static ICollection<string> HybridAndClientCredentials => new string[2]
        {
            "hybrid",
            "client_credentials"
        };

        public static ICollection<string> ClientCredentials => new string[1]
        {
            "client_credentials"
        };

        public static ICollection<string> ResourceOwnerPassword => new string[1]
        {
            "password"
        };

        public static ICollection<string> ResourceOwnerPasswordAndClientCredentials => new string[2]
        {
            "password",
            "client_credentials"
        };

        public static ICollection<string> DeviceFlow => new string[1]
        {
            "urn:ietf:params:oauth:grant-type:device_code"
        };
    }
}
