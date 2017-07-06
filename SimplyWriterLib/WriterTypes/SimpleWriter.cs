using System;
using System.IO;

namespace SimplyWriterLib {
    public class SimpleWriter : SimpleWriterBase {
        //private Stream stream;

        public SimpleWriter(){

            // Inherits the ability to write to console/screen from base class
     
        
        }

        public override void SimplyWrite() {
            //Create stream to output into console/screen
            using (Stream stream = Console.OpenStandardOutput()) {

                // Write to console/screen
                WriteMemoryToStream(stream);
                stream.Flush();

            }

        }

    }


}
