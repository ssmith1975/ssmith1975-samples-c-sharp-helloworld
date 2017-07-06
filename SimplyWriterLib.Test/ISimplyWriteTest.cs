using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimplyWriterLib.Test.Mocks;
using System.IO;

namespace SimplyWriterLib.Test {

    [TestClass]   
    public class ISimplyWriteTest {

        [ClassCleanup()]
        public static void MyTestCleanup() {

            // Dispose objects to free up resources
            MockSimpleWriterBase.Memory.Dispose();
        }


        [TestMethod]
        public void Is_Instance_Of_Type_ISimplyWrite() {
           // Arrange
            SimpleWriter simpleWriter = new SimpleWriter();

            // Assert
            Assert.IsInstanceOfType(simpleWriter, typeof(ISimplyWrite));

        }

        [TestMethod]
        public void Is_SimplyWrite_Called() {
            // Arrange
            ISimplyWrite sw;
            var mock = new Mock<ISimplyWrite>();

            mock.Setup(m => m.SimplyWrite()).Verifiable("SimplyWrite method is broken");
            sw = mock.Object;

            // Act
            sw.SimplyWrite();

            // Assert
            mock.Verify(m => m.SimplyWrite(), Times.AtLeastOnce()); 
        }
    }
}
