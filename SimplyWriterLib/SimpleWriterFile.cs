using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SimplyWriterLib {
    public class SimpleWriterFile : SimpleWriterBase {
        private string fileName;

        public SimpleWriterFile() {
            string currentDirectory;

            // Create file in current directory the application is running in
            currentDirectory = Directory.GetCurrentDirectory();
            fileName = currentDirectory + @"\SimpleOutput.txt"; 
        }


        public override void SayHello() {

            // Create StreamWriter instance
            using (StreamWriter writer = new StreamWriter(fileName)) {

                Console.WriteLine("Writing to {0}...", fileName);

                // Output content to file
                writer.Write(TEXT);
            }

        }
    }
}
