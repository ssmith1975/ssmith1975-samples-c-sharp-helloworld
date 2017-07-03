using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplyWriterLib;
using System.Reflection;
using System.IO;

namespace SimplyHello {
    class Program {
        static void Main(string[] args) {
            string writerType;           /*   */
            string outputFileFullPath;

            // Grab writer type from project settings
            //writerType = Properties.Settings.Default.WriterType;

            writerType = "SimpleWriterMemory";
            //writerType = "SimpleWriter";
            outputFileFullPath = Properties.Settings.Default.OutputFileFullPath;

            // Create instance from factory method
            IWriteHello simpleDataWriter = SimpleWriterFactory.GetWriter(writerType);

            if (simpleDataWriter is SimpleWriterStreamBase) {
            
                using (SimpleWriterStreamBase simpleWriterStream = (SimpleWriterStreamBase)simpleDataWriter) {

                    // Write output within using statement to ensure Dispose
                    simpleDataWriter.SayHello();

                    if (simpleWriterStream is SimpleWriterMemory) {
                        ((SimpleWriterMemory)simpleDataWriter).ReadFromMemory();
                    }

                }

            } else {
                // Write output
                simpleDataWriter.SayHello();
            }



            


          /*

            FileStream fs;
            string outputFileFullPath = Properties.Settings.Default.OutputFileFullPath;

            fs = new FileStream(outputFileFullPath, FileMode.Create);
            WriteStream(fs);

            MemoryStream memory;
            memory = new MemoryStream();

            WriteStream(memory);
            Console.WriteLine();
            Console.WriteLine("Memory");

            memory.Position = 0;
            var sr = new StreamReader(memory);
            var myStr = sr.ReadToEnd();
            Console.WriteLine(myStr);
            */

            //Console.WriteLine(memory.ReadByte());




            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }


    }
}
