 # SimplyWriterLib for Writing <i>"Hello World"</i>
Use SimplyWriterLib to output <i>"Hello World"</i> into the various forms of output streams such as the FileStream, HttpContext.CurrentResponse, and to standard Console.Write.

Supports three writer types:

* <b>SimpleWriter</b> - outputs to console/screen
* <b>SimpleWriterFile</b> - outputs to file
* <b>SimpleHttpWriter</b> - yes, it can send a <i>"Hello World"</i> to the web browser.

<h3>Configuration</h3>
Optionally store writer type into Project Settings of an application as a <b>string</b> variable called <var>WriterType</var>. Then refer writer type as:

<pre>
string writerType = Properties.Settings.Default.WriterType;
</pre>

##Example use of API:
<h3>utput to console/screen</h3>
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

<h3>Output to File</h3>
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

## Authors

* **Samantha Smith** - *Creator* - [ssmith1975 on github](https://github.com/ssmith1975/)
