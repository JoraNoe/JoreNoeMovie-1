using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JoreNoeVideo.DomainServices.Tools
{
    public static class MD5
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string Token)
        {
            //MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            //var hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(Token));
            //StringBuilder tmp = new StringBuilder();
            //foreach (byte i in hashedDataBytes)
            //{
            //    tmp.Append(i.ToString("x2"));
            //}
            //return tmp.ToString();

            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();//实例化加密对象
            byte[] key = Encoding.Unicode.GetBytes("");//定义字节数组，用来存储秘钥
            byte[] data = Encoding.Unicode.GetBytes(Token);//定义字节数组，用来要存储加密的字符串
            MemoryStream mStream = new MemoryStream();//实例化内存流对象
            //使用内存流实例化加密对象
            CryptoStream cStream = new CryptoStream(mStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            cStream.Write(data, 0, data.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        public static string DesCrypr(string Token)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();//定义加密类对象
            byte[] key = Encoding.Unicode.GetBytes("");
            byte[] data = Convert.FromBase64String(Token);
            MemoryStream mStram = new MemoryStream();//实例化内存流对象
            CryptoStream cStream = new CryptoStream(mStram, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            cStream.Write(data, 0, data.Length);
            cStream.FlushFinalBlock();
            return Encoding.Unicode.GetString(mStram.ToArray());

        }
    }
}
