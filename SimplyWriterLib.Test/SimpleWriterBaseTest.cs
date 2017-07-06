using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using SimplyWriterLib.Test.Mocks;
using System.Diagnostics;

namespace SimplyWriterLib.Test {
    /// <summary>
    /// Summary description for SimpleWriterBaseTest
    /// </summary>
    [TestClass]
    public class SimpleWriterBaseTest {
        static Mock<MockSimpleWriterBase> mock;

        #region Additional test attributes
        // Use TestInit to run code before each test starts
        [ClassInitialize()]
        public static void TestInit(TestContext tc) {

           mock = new Mock<MockSimpleWriterBase>();
        }

        // Use TestCleanup to run code after each test has run
        [ClassCleanup()]
        //[TestCleanup()]
        public static void MyTestCleanup() {

            // Dispose objects to free up resources
            mock.Object.MemorySpy.Dispose();
            MockSimpleWriterBase.Memory.Dispose();
        }

        #endregion

        [TestMethod]
        public void Is_HelloWorld_Saved_To_Memory() {

            // Arrange
            //Mock<MockSimpleWriterBase> mock;
            //mock = new Mock<MockSimpleWriterBase>();
            MockSimpleWriterBase sw;

            string actual;
            string expected;
           
            sw = mock.Object;
            expected = "Hello World";

            // Act            
            actual = sw.ReadFromMemoryStream(sw.MemorySpy);

            // Assert 
            Assert.IsNotNull(MockSimpleWriterBase.Memory);
            Assert.IsInstanceOfType(MockSimpleWriterBase.Memory, typeof(MemoryStream));
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Is_SimplyWrite_Called_From_AbstractClass() {

            // Arrange
            //Mock<MockSimpleWriterBase> mock;
            //mock = new Mock<MockSimpleWriterBase>();

            MockSimpleWriterBase sw;

            bool actual;

            sw = mock.Object;

            // Act  
            sw.SimplyWrite();          
            actual = sw.SimplyWriteSpy;

            // Assert 
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void Can_WriteMemoryToStream_Stream_Hello_World() {

            // Arrange
            //Mock<MockSimpleWriterBase> mock;
            //mock = new Mock<MockSimpleWriterBase>();
            MockSimpleWriterBase sw;
            MemoryStream receiver;

            string actual;
            string expected;

            expected = "Hello World";

            sw = mock.Object;

            receiver = new MemoryStream();

            // Act
            sw.WriteMemoryToStream(receiver);
            actual = sw.ReadFromMemoryStream(receiver);

            // Assert 
            Assert.AreEqual(expected, actual);
            receiver.Dispose();

        }

        [TestMethod]
        public void Is_ByteArray_Correct_For_HelloWorld() {

            // Arrange
            byte[] actual;
            byte[] expected;
            string text;

            //Mock<MockSimpleWriterBase> mock;
           // mock = new Mock<MockSimpleWriterBase>();
            MockSimpleWriterBase sw;

            text = "Hello World";
            sw = mock.Object;
            expected = Encoding.Default.GetBytes(text);

            // Act
            actual = sw.ByteArray;

            CollectionAssert.AreEqual(expected, actual);
        }



    }




}
