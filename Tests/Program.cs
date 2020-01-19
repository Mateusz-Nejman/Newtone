using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.ReadLine();
        }
    }
}
