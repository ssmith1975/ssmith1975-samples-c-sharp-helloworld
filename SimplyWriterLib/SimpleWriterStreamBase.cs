using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyWriterLib {

     
    public class SimpleWriterStreamBase : SimpleWriterBase {

        public SimpleWriterStreamBase() {
            CloseStream = true;
        }

        protected Stream Stream { get; set; }
        protected bool CloseStream { get; set; }

        protected virtual BinaryWriter WriteStream(Stream stream) {

            // Inject stream object into BinaryWriter
            BinaryWriter binWriter = new BinaryWriter(stream);
            return binWriter;
        }


        public override void SayHello() {
            // Convert string into bytes
            Byte[] bytes = Encoding.UTF8.GetBytes(TEXT);

            BinaryWriter binWriter = WriteStream(Stream);
            // Write stream into BinaryWriter
            binWriter.Write(bytes);

            // Flush out buffer
            binWriter.Flush();

            if (CloseStream) {
                // Close Binary Writer and Stream objects
                binWriter.Close();
                Stream.Close();
            }
        }

    }



}
