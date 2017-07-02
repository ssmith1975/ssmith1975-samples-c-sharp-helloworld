using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyWriterLib
{
    public class SimpleWriterFactory
    {
        public static IWriteHello GetWriter(string writerType="")
        {

            switch (writerType)
            {
                case "SimpleWriterFile": return new SimpleWriterFile();
                    break;
                case "SimpleHttpWriter": return new SimpleHttpWriter();
                    break;
                default: return new SimpleWriter();
                    break;
            }
        }

    }
}
