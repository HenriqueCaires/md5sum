using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace md5sum
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var file in args)
                if (File.Exists(file))
                    Console.WriteLine($"{CalculateMD5(file)}  {file}");
                else
                    Console.WriteLine($"md5sum: {file}: No such file or directory");
        }

        public static string CalculateMD5(string file)
        {
            using var md5 = MD5.Create();
            using var stream = File.OpenRead(file);
            return
                string.Join(string.Empty,
                    md5.ComputeHash(stream)
                        .Select(b => b.ToString("x2"))
                )
                ;
        }
    }
}
