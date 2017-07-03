using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Net.Sockets;
using System.IO;

namespace SimplyWriterLib {
    public class SimpleHttpWriter : SimpleWriterStreamBase {

        protected HttpResponse httpResponse;

        public SimpleHttpWriter() {
            // Grab reference to response object
            httpResponse  = HttpContext.Current.Response;


            // Output to web browser
            Stream = httpResponse.OutputStream;

            // What to do when SayHello begins
            OnStartSayHello = () => {
                httpResponse.Clear();
                httpResponse.ContentType = "text/plain";
            };

            // What to do when SayHello completes
            OnEndSayHello = (bw) => {
                HttpContext.Current.Response.End();

                // Close BinaryWriter stream and Stream object at end of SayHello
                bw.Close();
                base.Dispose();
            };


        }
 

    }
}
