using SimplyWriterLib;
using System;

namespace SimpleWeb {
    public partial class HelloWorld : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            string writerType;
      
            // Grab writer type from project settings
            writerType = Properties.Settings.Default.WriterType;

            // Create instance from factory method
            ISimplyWrite simpleDataWriter = SimpleWriterFactory.GetWriter(writerType);

            // Write output
            simpleDataWriter.SimplyWrite();
        }
    }
}