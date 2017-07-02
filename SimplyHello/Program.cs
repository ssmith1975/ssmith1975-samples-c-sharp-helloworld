using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplyWriterLib;
namespace SimplyHello {
    class Program {
        static void Main(string[] args) {

            // Create instance from factory method
            IWriteHello simpleDataWriter = SimpleWriterFactory.GetWriter("SimpleWriterFile");

            // Write output
            simpleDataWriter.SayHello();

            // Create another instance from factoryy method
            simpleDataWriter = SimpleWriterFactory.GetWriter();

            // Write output
            simpleDataWriter.SayHello();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
