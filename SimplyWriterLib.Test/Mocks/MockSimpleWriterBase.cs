using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplyWriterLib;
using System.IO;
using System.Diagnostics;

namespace SimplyWriterLib.Test.Mocks {
    /// <summary>
    /// Simulates abstract SimpleWriterBase class (note: mock is not abstract)
    /// </summary>
    public class MockSimpleWriterBase : ISimplyWrite {
        public bool SimplyWriteSpy = false;
        public bool WriteMemoryToStreamSpy = false;
        public MemoryStream MemorySpy;
        public Stream ReceiverStreamSpy;


        public const string TEXT = "Hello World";

        public static MemoryStream Memory {
            get; private set;
        }

        public byte[] ByteArray {
            get; private set;
        }

        public MockSimpleWriterBase() {

            // Create Memory instance, if not created yet
            if (Memory == null) {
                Memory = StoreInMemoryStream();
            }

            ByteArray = Memory.ToArray();


            MemorySpy = Memory;

        }

        public void SimplyWrite() { // method would be abstact, but needed a spy for testing purposes

            SimplyWriteSpy = true;
            //WriteMemoryToStream(ReceiverStreamSpy);

        }

        public void WriteMemoryToStream(Stream stream) {
            //Memory = MemorySpy;
            // Reset position to start
            Memory.Position = 0;

            // Output memory into target stream
            Memory.WriteTo(stream);
            Memory.Flush();

            WriteMemoryToStreamSpy = true;
            //ReceiverStreamSpy = stream;
        }

        private MemoryStream StoreInMemoryStream() {

            MemoryStream memory = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(memory);

            // Place text into memory for reuse by other streams
            streamWriter.Write(TEXT);
            streamWriter.Flush();

            return memory;

        }

        public string ReadFromMemoryStream(Stream stream) {
            //string str ="";

            //StreamReader sr = new StreamReader(stream);
            ////using (StreamReader sr = new StreamReader(stream)) {

            //    str = sr.ReadToEnd();
            ////}

            //return str;
            stream.Position = 0;

            var sr = new StreamReader(stream);
            var myStr = sr.ReadToEnd();

            return myStr;
        }

    }
}
