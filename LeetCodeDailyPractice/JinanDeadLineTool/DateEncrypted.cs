/*******************************************************************
* Copyright(c) 2020 ZHTL
* All rights reserved.
*
* 文件名称: DateEncrypted.cs
* 简要描述:
*
* 创建日期: 2020/09/21 15:01:05
* 作者:     MURAN
* 说明:     截止日期加密解密工具，先把截止日期转为base64然后异或加密
******************************************************************/
using System;
using System.Text;

namespace Utils
{
    /// <summary>
    /// 日期加密工具
    /// </summary>
    public static class DateEncrypted
    {
        //可以自定义密钥
        private const string miyao = "djasnd-ndaskd-ndjasn-kdsnjak";
        private static byte[] jm_key = null;

        //简单的8位密钥
        static readonly byte[] Key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };

        static DateEncrypted()
        {
            jm_key = Encoding.UTF8.GetBytes(miyao);
        }

        /// <summary>
        /// 加密日期
        /// </summary>
        /// <param name="endDate"></param>
        public static string EncryptDate(DateTime endDate)
        {
            return GetBase64String(endDate);
        }

        /// <summary>
        /// 解密日期
        /// </summary>
        /// <param name="content"></param>
        public static DateTime DeCryptDate(string content)
        {
            return ParseBase64String(content);
        }

        //异或加密日期
        private static string GetBase64String(DateTime date)
        {
            var txt = date.ToString();
            var data = Encoding.UTF8.GetBytes(txt);
            Xor(data, Key);
            return Convert.ToBase64String(data);
        }

        //异或解密日期
        private static DateTime ParseBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            Xor(data, Key);
            var txt = Encoding.UTF8.GetString(data);
            if (DateTime.TryParse(txt, out DateTime rt))
            {
                return rt;
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// 异或加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <param name="key">密钥</param>
        private static void Xor(byte[] data, byte[] key)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= key[i % key.Length];
            }
        }
    }
}
