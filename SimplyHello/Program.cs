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
            writerType = Properties.Settings.Default.WriterType;

            // Grab writer type from project settings
            outputFileFullPath = Properties.Settings.Default.OutputFileFullPath; // D:\DEV\temp\myfile.txt

            // Create instance from factory method
            ISimplyWrite simpleDataWriter = SimpleWriterFactory.GetWriter(writerType, outputFileFullPath);
            simpleDataWriter.SimplyWrite();

           
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }


    }
}
