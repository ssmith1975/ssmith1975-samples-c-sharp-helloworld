﻿using System;
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

        public void WriteMemoryToStream(Stream stream) {
            // Reset position to start
            Memory.Position = 0;

            // Output memory into target stream
            Memory.WriteTo(stream);
            Memory.Flush();

            //var str = ReadFromMemoryStream(stream);
            //Console.WriteLine("Stream check: {0}", str);

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

            stream.Position = 0;

            var sr = new StreamReader(stream);
            var myStr = sr.ReadToEnd();

            return myStr;

        }

    }
}
