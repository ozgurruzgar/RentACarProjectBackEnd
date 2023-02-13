using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utitlities.Security.Encryption
{
    public class SigningCredencialsHelper
    {
        //Burda SecurityKeyHelper da oluşturduğumuz simetrik anahtarı güvenlik algoritmalarıyla imzalama nesnesi üretiyor.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
