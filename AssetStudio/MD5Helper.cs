using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssetStudio
{
    public static class MD5Helper
    {
        public static string ComputeMD5Hash(Stream input)
        {
            // 创建一个 MD5 对象
            using (MD5 md5 = MD5.Create())
            {
                // 计算 Stream 的 MD5 值
                byte[] hash = md5.ComputeHash(input);

                // 将字节数组转换成十六进制的字符串
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static string ComputeMD5Hash(byte[] input)
        {
            // 创建一个 MD5 对象
            using (MD5 md5 = MD5.Create())
            {
                // 计算 Stream 的 MD5 值
                byte[] hash = md5.ComputeHash(input);

                // 将字节数组转换成十六进制的字符串
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
