using System;
using System.Security.Cryptography;
using System.Text;

namespace SerialNumberHasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the serial number: ");
            string serialNumber = Console.ReadLine();

            if (string.IsNullOrEmpty(serialNumber))
            {
                Console.WriteLine("Serial number cannot be empty.");
                return;
            }

            string serialHash = HashSerialNumber(serialNumber);
            Console.WriteLine("SHA256 Hash (Base64): " + serialHash);
            Console.WriteLine("SHA256 Hash (Hex): " + Convert.ToHexString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(serialNumber)))); // Hex format

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        public static string HashSerialNumber(string serialNumber)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(serialNumber);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}