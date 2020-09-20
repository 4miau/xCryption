using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace xCryption
{
    public class xCryFuncs
    {
        public string publickey = "santhosh";
        public static xCryFuncs PublicKeySetting = new xCryFuncs();

        public string Encrypt(string textToEncrypt)
        {
            try
            {
                string ToReturn = "";
                string publickey = PublicKeySetting.publickey;
                string secretkey = "engineer";
                byte[] secretkeyByte = { };
                secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message/*, ex.InnerException*/);
            }
        }

        public string Decrypt(string textToDecrypt)
        {
            try
            {
                string ToReturn = "";
                string publickey = PublicKeySetting.publickey;
                string privatekey = "engineer";
                byte[] privatekeyByte = { };
                privatekeyByte = Encoding.UTF8.GetBytes(privatekey);
                byte[] publickeybyte = { };
                publickeybyte = Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("That is the incorrect key, here's a free error. " + ex.Message).ToString();
                return "There was an error decrypting this message.";
                //throw new Exception(ex.Message/*, ex.InnerException*/);
            }
        }
    }
}
