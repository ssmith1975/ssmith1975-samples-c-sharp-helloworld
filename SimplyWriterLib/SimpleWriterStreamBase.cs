using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyWriterLib {

     
    public class SimpleWriterStreamBase : SimpleWriterBase {

        public SimpleWriterStreamBase() {
            // What to do when SayHello completes
            // Cleanup resources
            OnEndSayHello = (bw) => {
                // Dispose stream and Stream object at end of SayHello
                Dispose();
            };
        }

        protected Stream Stream { get; set; }
        protected Action OnStartSayHello{
            get; set;
        }
        protected Action<BinaryWriter> OnStartSayHelloWrite {
            get; set;
        }
        protected Action<BinaryWriter> OnEndSayHelloWrite {
            get; set;
        }

        protected Action<BinaryWriter> OnEndSayHello {
            get; set;
        }
       


        public override void SayHello() {
            BinaryWriter binWriter;
            Byte[] bytes;

            try {

                //Exeute OnStartSayHello property, if set
                if (OnStartSayHello != null) {
                    OnStartSayHello.Invoke();
                }

                // Inject stream object into BinaryWriter
                binWriter = new BinaryWriter(Stream);


                // Convert string into bytes
                bytes = Encoding.UTF8.GetBytes(TEXT);

                //BinaryWriter binWriter = WriteStream(Stream);

                //Exeute OnStartSayHelloWrite property, if set
                if (OnStartSayHelloWrite != null) {
                    OnStartSayHelloWrite.Invoke(binWriter);
                }

                // Write stream into BinaryWriter
                binWriter.Write(bytes);

                //Exeute OnEndSayHelloWrite property, if set
                if (OnEndSayHelloWrite != null) {
                    OnEndSayHelloWrite.Invoke(binWriter);
                }

                // Flush out buffer
                binWriter.Flush();


                //Exeute OnEndSayHello property, if set
                if (OnEndSayHello != null) {
                    OnEndSayHello.Invoke(binWriter);
                }

            } catch {
                // Free up resources
                bytes = null;
                binWriter=null;
                Dispose();
            }

        }

        public override void Dispose() {

            if (Stream != null) {
                Stream.Close();
                Stream.Dispose();
            }

        }


    }



}
