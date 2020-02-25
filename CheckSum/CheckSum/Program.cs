using System;
using System.IO;
using System.Security.Cryptography;

namespace CheckSum
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Please specify file.");
                return;
            }
            if(args.Length == 1)
            {
                Console.WriteLine("SHA256: " + SHA256CheckSum(args[0]));
                return;
            }
            switch(args[0])
            {
                case "SHA1": 
                    Console.WriteLine("SHA1: " + SHA1CheckSum(args[1]));
                    break;
                case "SHA256": 
                    Console.WriteLine("SHA256: " + SHA256CheckSum(args[1]));
                    break;
                case "SHA512": 
                    Console.WriteLine("SHA512: " + SHA512CheckSum(args[1]));
                    break;
                default:
                    Console.WriteLine("first argument specifies the algorithm: SHA1 or SHA256 or SHA512");
                    break;
            }
        }

        private static string SHA256CheckSum(string filePath)
        {
            using SHA256 sha256 = SHA256Managed.Create();
            using FileStream fileStream = File.OpenRead(filePath);
            return BytesToString(sha256.ComputeHash(fileStream));
        }

        private static string SHA512CheckSum(string filePath)
        {
            using SHA512 sha512 = SHA512Managed.Create();
            using FileStream fileStream = File.OpenRead(filePath);
            return BytesToString(sha512.ComputeHash(fileStream));
        }

        private static string SHA1CheckSum(string filePath)
        {
            using SHA1 sha1 = SHA1Managed.Create();
            using FileStream fileStream = File.OpenRead(filePath);
            return BytesToString(sha1.ComputeHash(fileStream));
        }

        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result.ToUpper();
        }

    }
}
