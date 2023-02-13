using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utitlities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //appsettingsdeki stringi byte çevirerek bir simetrik anahtar oluşturuyor. Asp.NET
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
