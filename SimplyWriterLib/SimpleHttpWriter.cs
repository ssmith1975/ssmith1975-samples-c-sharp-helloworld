using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net.Sockets;


namespace SimplyWriterLib {
    class SimpleHttpWriter : SimpleWriterStreamBase {
        public SimpleHttpWriter() {

            // Output to web browser
            Stream = HttpContext.Current.Response.OutputStream;
        }
    }
}
