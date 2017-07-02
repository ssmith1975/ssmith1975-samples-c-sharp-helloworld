using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimplyWriterLib {
    public abstract class SimpleWriterBase : IWriteHello {

        public const string TEXT = "Hello World";

        public SimpleWriterBase() {
        }

        public virtual void SayHello() {
            
            Console.WriteLine(TEXT);
        }

    }
}
