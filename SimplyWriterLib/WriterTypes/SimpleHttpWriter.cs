using System.IO;
using System.Web;

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
