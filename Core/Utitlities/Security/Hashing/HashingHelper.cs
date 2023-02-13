using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utitlities.Security.Hashing
{
   public class HashingHelper
    {
        //Bu Metodda bir şifre veriyoruz ve bize onun güçlendirilmiş halini ve farklılaştırılmış halini dönderiyor.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        //Bu metodda ise kullanıcı şifresini girince şifreyi oluşturduğumuz algoritmayla güçlendirilmiş hali kullanarak karşılaştırarak doğruluyor.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
