using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyHello
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write output
            SimpleDataWriter simpleDataWriter = new SimpleDataWriter();

            simpleDataWriter.SayHello();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
