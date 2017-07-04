using System;

namespace SimplyWriterLib {
    public class SimpleWriterFactory {

        public static ISimplyWrite GetWriter(string writerType="", params object[] args) {
            string stringClassName;
            Type selectedType;

            // If writerType is null/empty, default to console/screen output
            if (String.IsNullOrEmpty(writerType)) {

                // Default to console mode
                writerType = "SimpleWriter";
            }

            // Setup fully qualified name for class
            stringClassName = String.Format("SimplyWriterLib.{0}", writerType);

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
