using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("C:\\Test\\");

            Console.WriteLine(uri.AbsoluteUri);

            int intValue = 1;
            // Convert integer 182 as a hex in a string variable
            string hexValue = intValue.ToString("X");
            // Convert the hex string back to the number
            int intAgain = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            int intAgain1 = int.Parse("01", System.Globalization.NumberStyles.HexNumber);
            Console.WriteLine(intAgain);
            Console.WriteLine(intAgain1);

            IPAddress addr = new IPAddress(new byte[] { 192, 168, 8, 1 });
            Console.WriteLine(addr.ToString());
            int c1 = addr.GetAddressBytes()[0];
            int c2 = addr.GetAddressBytes()[1];
            int c3 = addr.GetAddressBytes()[2];
            int c4 = addr.GetAddressBytes()[3];

            Console.WriteLine($"{c1}.{c2}.{c3}.{c4}");
            string hex = ToHex(addr);
            Console.WriteLine(hex);
            Console.WriteLine(FromHex(hex).ToString());

            Console.ReadLine();
        }

        static string ToHex(IPAddress addr)
        {
            string c1 = ((int)addr.GetAddressBytes()[0]).ToString("X").PadLeft(2, '0');
            string c2 = ((int)addr.GetAddressBytes()[1]).ToString("X").PadLeft(2, '0');
            string c3 = ((int)addr.GetAddressBytes()[2]).ToString("X").PadLeft(2, '0');
            string c4 = ((int)addr.GetAddressBytes()[3]).ToString("X").PadLeft(2, '0');

            return $"{c1}{c2}{c3}{c4}";
        }

        static IPAddress FromHex(string hex)
        {
            string h1 = hex[0].ToString() + hex[1].ToString();
            string h2 = hex[2].ToString() + hex[3].ToString();
            string h3 = hex[4].ToString() + hex[5].ToString();
            string h4 = hex[6].ToString() + hex[7].ToString();

            return new IPAddress(new byte[] { (byte)int.Parse(h1, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h2, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h3, System.Globalization.NumberStyles.HexNumber), (byte)int.Parse(h4, System.Globalization.NumberStyles.HexNumber) });
        }
    }
}
