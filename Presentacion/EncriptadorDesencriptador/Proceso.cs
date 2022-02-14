using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.EncriptadorDesencriptador
{
    public class Proceso
    {

        public string Desencriptar(string Token, string Password)
        {
            byte[] encryptBytesWithSalt = Convert.FromBase64String(Token);
            byte[] salt = new byte[8];

            byte[] encryptBytes = new byte[encryptBytesWithSalt.Length - salt.Length - 8];
            Buffer.BlockCopy(encryptBytesWithSalt, 8, salt, 0, salt.Length);

            Buffer.BlockCopy(encryptBytesWithSalt, salt.Length + 8, encryptBytes, 0, encryptBytes.Length);
            byte[] key, iv;
            DerivaKeyIv(Password, salt, out key, out iv);
            return DecifrarCadenaBytes(encryptBytes, key, iv);
        }

        private static void DerivaKeyIv(string Password, byte[] salt, out byte[] key, out byte[] iv)
        {
            List<byte> concatenatedHashes = new List<byte>(48);
            byte[] password = Encoding.UTF8.GetBytes(Password);
            byte[] currentHash = new byte[0];
            MD5 md5 = MD5.Create();
            bool enoughBytesForKey = false;

            while (!enoughBytesForKey)
            {
                int preHashLength = currentHash.Length + password.Length + salt.Length;
                byte[] preHash = new byte[preHashLength];
                Buffer.BlockCopy(currentHash, 0, preHash, 0, currentHash.Length);
                Buffer.BlockCopy(password, 0, preHash, currentHash.Length, password.Length);
                Buffer.BlockCopy(salt, 0, preHash, currentHash.Length + password.Length, salt.Length);
                currentHash = md5.ComputeHash(preHash);
                concatenatedHashes.AddRange(currentHash);
                if (concatenatedHashes.Count >= 48)
                    enoughBytesForKey = true;
            }

            key = new byte[32];
            iv = new byte[16];
            concatenatedHashes.CopyTo(0, key, 0, 32);
            concatenatedHashes.CopyTo(32, iv, 0, 16);
            md5.Clear();
            md5 = null;
        }

        static string DecifrarCadenaBytes(byte[] encryptBytes, byte[] key, byte[] iv)
        {
            if (encryptBytes == null || encryptBytes.Length <= 0)
                throw new ArgumentNullException("encryptBytes");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("iv");
            RijndaelManaged RijMan = null;
            string Texto;

            try
            {

                RijMan = new RijndaelManaged { Mode = CipherMode.CBC, KeySize = 256, BlockSize = 128, Key = key, IV = iv };
                ICryptoTransform decryptor = RijMan.CreateDecryptor(RijMan.Key, RijMan.IV);
                using (MemoryStream msDecrypt = new MemoryStream(encryptBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            Texto = srDecrypt.ReadToEnd();
                            srDecrypt.Close();
                        }
                    }
                }
            }
            finally
            {
                if (RijMan != null)
                    RijMan.Clear();
            }

            return Texto;

        }


    }
}