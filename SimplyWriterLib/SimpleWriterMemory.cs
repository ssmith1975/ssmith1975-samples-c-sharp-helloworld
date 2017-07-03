using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyWriterLib {
    public class SimpleWriterMemory : SimpleWriterStreamBase, IArrayBytes {

        public byte[] ArrayBytes {
            get {
                return ((MemoryStream)Stream).ToArray();
            }
            
        }
        public SimpleWriterMemory() {
 
            Stream = new MemoryStream();

            OnEndSayHello = (bw) => {
                // don't close stream just yet...
                Console.WriteLine("Write to Memory");
            };
        }

        public void ReadFromMemory() {
            MemoryStream memory = (MemoryStream)Stream;
            memory.Position = 0;
            var sr = new StreamReader(memory);
            var str = sr.ReadToEnd();
            Console.WriteLine(str);
        }
    }
}
