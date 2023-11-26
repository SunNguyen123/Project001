using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Resource
{
   public class MD5Hash
    {
        public static string Hash(string c)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] sample = Encoding.UTF8.GetBytes(c);
                byte[] hash = md5.ComputeHash(sample);
                foreach (var i in hash)
                {
                    stringBuilder.Append(i.ToString());
                }
            }
            return stringBuilder.ToString();
        }
    }
}
