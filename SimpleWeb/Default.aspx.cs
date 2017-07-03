using SimplyWriterLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleWeb {
    public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            //Response.Clear();
            string writerType;
            writerType = "SimpleHttpWriter";
            //outputFileFullPath = Properties.Settings.Default.OutputFileFullPath;

            // Create instance from factory method
            IWriteHello simpleDataWriter = SimpleWriterFactory.GetWriter(writerType);

            // Write output
            simpleDataWriter.SayHello();

        }
    }
}