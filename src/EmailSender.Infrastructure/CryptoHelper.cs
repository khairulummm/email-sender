using System.Security.Cryptography;
using System.Text;

namespace DataIntegration.Infrastructure
{
    public static class CryptoHelper
    {
        public static string Decrypt(string str)
        {
            str = str.Replace(" ", "+");
            string DecryptKey = "TowerBersamaGroup";
            byte[] byKey = { };
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] inputByteArray = new byte[str.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(ms.ToArray());
        }

        public static string EncodeBTOA(string toEncode)
        {
            byte[] bytes = Encoding.GetEncoding(28591).GetBytes(toEncode);
            string toReturn = Convert.ToBase64String(bytes);
            return toReturn;
        }

        public static string DecodeBTOA(string toDecode)
        {
            string toReturn = Encoding.UTF8.GetString(Convert.FromBase64String(toDecode));
            return toReturn;
        }
    }
}