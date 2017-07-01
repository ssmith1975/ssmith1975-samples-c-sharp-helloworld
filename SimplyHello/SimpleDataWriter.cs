using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimplyHello
{
    public class SimpleDataWriter: IWriteHello
    {

        public SimpleDataWriter() {         
        }

        public void SayHello()
        {

            Console.WriteLine("Hello World");
        }

    }
}
