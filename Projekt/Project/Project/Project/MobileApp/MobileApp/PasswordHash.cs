﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MobileApp
{
    public class PasswordHash
    {
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString(format: "x2"));
            }
            return sBuilder.ToString();

        }
    }
}
