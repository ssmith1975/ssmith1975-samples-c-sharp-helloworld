 # SimplyWriterLib for Writing <i>"Hello World"</i>
Use SimplyWriterLib to output <i>"Hello World"</i> into the various forms of output streams such as the FileStream, HttpContext.Current.Response, and to standard Console.Write.

Supports three writer types:

* <b>SimpleWriter</b> - outputs to console/screen
* <b>SimpleWriterFile</b> - outputs to file
* <b>SimpleHttpWriter</b> - yes, it can send a <i>"Hello World"</i> to the web browser.

 Other forms of streams can be added simply by the following:

* adding a new class in the <i>SimplyWriterLib</i>'s <b>WriterTypes</b> folder 
* inheriting from the SimpleWriterBase
* and overriding the <i>SimplyWrite</i> method


<p>This library also return "Hello World" in an byte array, which provides greater flexibility for writing to databases, for example.</p>

### Configuration
Optionally store writer type into Project Settings of an application as a <b>string</b> variable called <var>WriterType</var>. Then refer writer type as:

<pre>
string writerType = Properties.Settings.Default.WriterType;
</pre>

## Example use of API:
### Output to console/screen
<pre>
// Include a reference to SimplyWriterLib in project
using SimplyWriterLib;
</pre>

<pre>
// Create instance from factory method
//Prints to console/screen
ISimplyWrite simpleDataWriter = SimpleWriterFactory.GetWriter();

// Execute write method
simpleDataWriter.SimplyWrite();
</pre>

### Output to file
<pre>
// Include a reference to SimplyWriterLib in project
using SimplyWriterLib;
</pre>
<pre>
string writerType = "SimpleWriterFile";;
string outputFileFullPath = "D:\DEV\temp\myfile.txt";


// Prints to file
ISimplyWrite simpleDataWriter = SimpleWriterFactory.GetWriter(writerType, outputFileFullPath);

// Execute write method
simpleDataWriter.SimplyWrite();
</pre>

### Output to web as plain text
<pre>
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
</pre>


## Authors

* **Samantha Smith** - *Creator* - [ssmith1975 on github](https://github.com/ssmith1975/)
