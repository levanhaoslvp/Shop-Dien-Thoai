using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace CNWeb.Common
{
    public class Encrypt
    {
        public Encrypt()
        {

        }
        public string EncryptPassowrd(string text)
        {
            string password = "";
            if (!string.IsNullOrEmpty(text))
            {
                byte[] data = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
                foreach(var item in data)
                {
                    password += item;
                }
            }
            return password;
        }
    }
}