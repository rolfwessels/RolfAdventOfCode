using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Core
{
    public class Day04StockingStuffer
    {
        public int Calculate2(string prefix, string value)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                var hash = GetHash(prefix+i);
               // Console.Out.WriteLine("hash" + hash);
                if (hash.StartsWith(value))
                    return i;
            }
            return -1;
        }

        public int Calculate(string prefix, string value)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                var hash = GetHash(prefix+i);
               // Console.Out.WriteLine("hash" + hash);
                if (hash.StartsWith(value))
                    return i;
            }
            return -1;
        }


        public string GetHash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            return BitConverter.ToString(data).Replace("-","");
        }
        
    }
}