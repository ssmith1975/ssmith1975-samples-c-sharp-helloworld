using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyWriterLib.Test.Mocks {
    public class MockSimpleWriterFactory {

        public static ISimplyWrite GetWriter(string writerType = "", params object[] args) {
            string stringClassName;
            Type selectedType;

            // If writerType is null/empty, default to console/screen output
            if (String.IsNullOrEmpty(writerType)) {

                // Default to console mode
                writerType = "FakeClass1";
            }

            // Setup fully qualified name for class
            stringClassName = String.Format("SimplyWriterLib.Test.Fakes.{0}", writerType);

            // Get type of class based on string name
            selectedType = Type.GetType(stringClassName);

            // Check that writer type is a valid type
            if (!typeof(ISimplyWrite).IsAssignableFrom(selectedType)) {

                string errorMsg = String.Format("{0} is an invalid writer type", stringClassName);

                throw new ArgumentException(errorMsg);
            }

            // Create and return instance of writer type of as an IWriteHello object
            return (ISimplyWrite)(Activator.CreateInstance(selectedType, args));

        }

    }
}
