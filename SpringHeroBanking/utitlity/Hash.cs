using System.Security.Cryptography;

namespace SpringHeroBanking.Unity
{
    public class Hash
    {
        public  string EncryptString(string contnent, string salt)
        {
            var str_md5 = "";
            byte[] byteArryayPasswordSalt = System.Text.Encoding.UTF8.GetBytes(contnent + salt);
            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byteArryayPasswordSalt = md5CryptoServiceProvider.ComputeHash(byteArryayPasswordSalt);
            foreach (var b in byteArryayPasswordSalt)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }
    }
}