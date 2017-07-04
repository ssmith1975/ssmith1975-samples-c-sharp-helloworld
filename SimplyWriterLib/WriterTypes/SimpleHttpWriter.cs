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
    public class SimpleHttpWriter : SimpleWriterBase {

        protected HttpResponse httpResponse;

        public SimpleHttpWriter() {

            // Grab reference to response object
            httpResponse  = HttpContext.Current.Response;

        }


        public override void SimplyWrite() {

            using (Stream stream = httpResponse.OutputStream) {

                // Setup http response
                httpResponse.Clear();
                httpResponse.ContentType = "text/plain";

                // Write to page as a text file
                WriteMemoryToStream(stream);

                stream.Flush();
                httpResponse.End();

            }

        }


    }
}
