using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyWriterLib.Test.Mocks {
    public class MockSimpleWriter : MockSimpleWriterBase {
        public bool IsWrittenToConsoleSpy = false;
       // public Stream ReceiverStream;


        public MockSimpleWriter() {

            // Inherits the ability to write to console/screen from base class


        }

        public new void SimplyWrite() {

            // Create stream to output into console/screen
            using (Stream stream = Console.OpenStandardOutput()) {
                // ReceiverStreamSpy = stream;
                // Write to console/screen
                IsWrittenToConsoleSpy = true;
                WriteMemoryToStream(stream);
                stream.Flush();
                //Memory.Position = 0;
                //Memory.WriteTo(ReceiverStreamSpy);
                //Memory.Flush();
               // stream.Flush();

            }
        }

        public new void WriteMemoryToStream(Stream stream) {

            ReceiverStreamSpy = new MemoryStream();

            base.WriteMemoryToStream(ReceiverStreamSpy);
               // Console.SetOut(tmp);
            //};

            //ReceiverStream = stream;
            //IsWrittenToStreamSpy = true;

        }




    }
}



