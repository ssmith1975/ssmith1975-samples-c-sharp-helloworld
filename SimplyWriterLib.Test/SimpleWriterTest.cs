using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using SimplyWriterLib.Test.Mocks;
using SimplyWriterLib.Test.Fakes;

namespace SimplyWriterLib.Test {
    /// <summary>
    /// Summary description for SimpleWriterTest
    /// </summary>
    [TestClass]
    public class SimpleWriterTest {

        static Mock<MockSimpleWriter> mock;

        // Use TestInit to run code before each test starts
        [ClassInitialize()]
        public static void TestInit(TestContext tc) {

            mock = new Mock<MockSimpleWriter>();
        }
        [ClassCleanup()]
        public static void MyTestCleanup() {

            // Dispose objects to free up resources
            mock.Object.MemorySpy.Dispose();
            mock.Object.ReceiverStreamSpy.Dispose();
            MockSimpleWriterBase.Memory.Dispose();
        }

        [TestMethod]
        public void Is_Output_To_Console() {

            // Arrange
            //Mock<MockSimpleWriter> mock;
            //mock = new Mock<MockSimpleWriter>();
            var sw = mock.Object; //SimpleWriterFactory.GetWriter("SimpleWriter");   

            // Act

            sw.SimplyWrite();

            //actual = simpleWriter.IsWrittenToStreamSpy;

            // Assert
            //Assert.IsInstanceOfType(sw.ReceiverStreamSpy, typeof(ConsoleStream));
            Assert.IsTrue(sw.IsWrittenToConsoleSpy);

        }

        [TestMethod]
        public void Is_Output_HelloWorld() {
            // Arrange
            string expected;
            string actual;


            //Mock<MockSimpleWriter> mock;
            //mock = new Mock<MockSimpleWriter>();
            var sw = mock.Object; //SimpleWriterFactory.GetWriter("SimpleWriter");   
            expected = "Hello World";
            // Act

            sw.SimplyWrite();

            actual = sw.ReadFromMemoryStream(((Stream)sw.MemorySpy));
         

            // Assert
            Assert.AreEqual(expected, actual);

        }

    }
}
