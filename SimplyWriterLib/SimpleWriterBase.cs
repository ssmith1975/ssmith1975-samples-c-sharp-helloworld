using System;
using System.IO;


namespace SimplyWriterLib {
    public abstract class SimpleWriterBase : ISimplyWrite {

        public const string TEXT = "Hello World";

        public static MemoryStream Memory {
            get; private set;
        }
        
        public byte[] ByteArray {
            get; private set;
        }

            
        public SimpleWriterBase() {

            // Create Memory instance, if not created yet
            if (Memory == null) {
                Memory = StoreInMemoryStream();
                ByteArray = Memory.ToArray();
            }

        }

        public abstract void SimplyWrite();

        protected void WriteMemoryToStream(Stream stream) {
            // Reset position to start
            Memory.Position = 0;

            // Output memory into target stream
            Memory.WriteTo(stream);
            Memory.Flush();
           
        }

        private MemoryStream StoreInMemoryStream() {

            MemoryStream memory = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(memory);

                // Place text into memory for reuse by other streams
                streamWriter.WriteLine(TEXT);
                streamWriter.Flush();

                return memory;

        }

        public void WriteFromMemoryStream() {
            Memory.Position = 0;
            var sr = new StreamReader(Memory);
            var myStr = sr.ReadToEnd();
            Console.WriteLine(myStr);

        }

    }
}
