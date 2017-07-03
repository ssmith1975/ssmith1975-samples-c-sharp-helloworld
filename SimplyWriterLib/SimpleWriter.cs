using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyWriterLib {
    public class SimpleWriter : SimpleWriterStreamBase {

        public SimpleWriter(){

            // Inherits the ability to write to console/screen from base class
            Stream = Console.OpenStandardOutput();
        
        }



    }
}
