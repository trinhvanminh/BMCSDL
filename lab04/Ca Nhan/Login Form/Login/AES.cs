using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class AES
    {
        AesCryptoServiceProvider crypt_provider;
        public AES(string key)
        {
            crypt_provider = new AesCryptoServiceProvider();

            crypt_provider.BlockSize = 128;
            crypt_provider.KeySize = 256;
            crypt_provider.IV = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            crypt_provider.Key = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            crypt_provider.Mode = CipherMode.CBC; //cipher block chaining
            crypt_provider.Padding = PaddingMode.PKCS7;
        }
        public byte[] Encrypt(string clear_text)
        {
            ICryptoTransform transform = crypt_provider.CreateEncryptor();
            byte[] encryptedd_bytes = transform.TransformFinalBlock(ASCIIEncoding.ASCII.GetBytes(clear_text), 0, clear_text.Length);
            return encryptedd_bytes;
        }
        public string Decrypt(byte[] enc_bytes)
        {
            ICryptoTransform transform = crypt_provider.CreateDecryptor();
            byte[] decrypted_bytes = transform.TransformFinalBlock(enc_bytes, 0, enc_bytes.Length);
            string str = ASCIIEncoding.ASCII.GetString(decrypted_bytes);

            return str;
        }
    }
}
