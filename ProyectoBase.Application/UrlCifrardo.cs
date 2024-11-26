using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class UrlCifrardo
    {
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


        private const int keysize = 256;

#if DEBUG
        //MACOS
        //static readonly string initVector = File.ReadAllText("/Users/luisantonio/Downloads/Data/textFileInitVector.config");
        //static readonly string passPhrase = File.ReadAllText("/Users/luisantonio/Downloads/Data/textFilePassPhrase.config");
        //static readonly string textFileSalt = File.ReadAllText("/Users/luisantonio/Downloads/Data/textFileSalt.config");

        static readonly string initVector = File.ReadAllText(@"C:\Data\textFileInitVector.config");
        static readonly string passPhrase = File.ReadAllText(@"C:\Data\textFilePassPhrase.config");
        static readonly string textFileSalt = File.ReadAllText(@"C:\Data\textFileSalt.config");

#else
        //WINDOWS
        static readonly string initVector = File.ReadAllText(@"C:\Data\textFileInitVector.config");
        static readonly string passPhrase = File.ReadAllText(@"C:\Data\textFilePassPhrase.config");
        static readonly string textFileSalt = File.ReadAllText(@"C:\Data\textFileSalt.config");
#endif



        private static string EncryptString(string plainText)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var salt = Encoding.UTF8.GetBytes(textFileSalt);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, salt);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }


        private static string DecryptString(string cipherText)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            //EspacionEnBlancoCIFRADO
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            var salt = Encoding.UTF8.GetBytes(textFileSalt);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, salt);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }


        public static string Encriptar(string cadena)
        {
            return EncryptString(cadena);
        }


        public static string Desencriptar(string cadena)
        {
            return DecryptString(cadena);
        }
    }
}

