using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net.Sockets;


namespace SimplyWriterLib {
    class SimpleHttpWriter : SimpleWriterBase {
        public SimpleHttpWriter() {
        }
        public override void SayHello() {

            HttpContext.Current.Response.Write(TEXT);

        }
    }
}
