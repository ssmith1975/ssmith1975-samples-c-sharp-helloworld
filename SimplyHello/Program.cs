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

            writerType = "SimpleWriterFile";
            outputFileFullPath = Properties.Settings.Default.OutputFileFullPath;

            // Create instance from factory method
            IWriteHello simpleDataWriter = SimpleWriterFactory.GetWriter(writerType);

            // Write output
            simpleDataWriter.SayHello();


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

            //// Display the files to the current output source to the console.
            //Console.WriteLine(str);


            //// Redirect output to a file named Files.txt and write file list.
            //StreamWriter sw = new StreamWriter(@".\Files.txt");
            //sw.AutoFlush = true;
            //Console.SetOut(sw);
            //Console.Out.WriteLine(str);

            //// Close previous output stream and redirect output to standard output.
            //Console.Out.Close();
            //sw = new StreamWriter(Console.OpenStandardOutput());
            //sw.AutoFlush = true;
            //Console.SetOut(sw);




            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }


    }
}
