using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utitlities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utitlities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration Configuration; //WebAPI deki appsettings.json dosyamızı değerlerini set etmek için kullandık.
        private TokenOptions _tokenOptions; //appsettings.json'daki TokenOptions'a IConfigration kullanarak set edicez, onun için field ürettik.
        private DateTime _accessTokenExpiration; // Token'ınımızın geçerlilik süresi
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //appsettings.json'daki TokenOptions'a IConfigration kullanarak set ettik. Yani bu field appsettingsdeki tokenOptions Bölümünü temsil.ediyor.
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//AppSettingde verdiğimiz süreyi şu anki sistem saatinin üstüne koyarak token'a geçerlilik süresi oluşturduk.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//ASP.NET'inde doğruyalabilmesi için simetrik keyimizi oluşturduğumuz helper ile kullandık.
            var signingCredentials = SigningCredencialsHelper.CreateSigningCredentials(securityKey);//Oluşturdğumuz simetrik anahtarı, güvenlik algoritmasıyla harmanlayıp bir imzalama nesnesi çıkardık ki ASP.Net doğrulayabilsin.
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//Tokenda olması gerekenler, hangi kullanıcı için, Kullanıcının yetkileri, imzalama nesnesi vererek bir jwt ürettik.
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler(); 
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
    SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now, //Sistem saatindaki saatten önce bir değer verilemez.
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private List<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray()); 

            return claims;
        }
    }
}
