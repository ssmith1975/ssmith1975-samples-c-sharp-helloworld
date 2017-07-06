using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using SimplyWriterLib.Test.Mocks;
using SimplyWriterLib.Test.Fakes;

namespace SimplyWriterLib.Test {

    [TestClass]
    public class SimpleWriterFactoryTest {
        [TestMethod]
        public void Does_SimpleWriterFactory_Return_Correct_Type_Based_On_String_Input() {

            // Arrange
            Type expected;
            Type actual;
            string writerType;


            writerType = "FakeClass1";
            expected = typeof(FakeClass1);

            // Act
            var simpleWriter = MockSimpleWriterFactory.GetWriter(writerType);
            actual = simpleWriter.GetType();

            // Assert
            Assert.IsInstanceOfType(simpleWriter, expected);
            Assert.IsInstanceOfType(simpleWriter, typeof(ISimplyWrite));
            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid class requested")]
        public void Does_SimpleWriterFactory_Return_Exception_For_Invalid_Class() {

            // Arrange
            Type expected;
            Type actual;
            string writerType;


            writerType = "FakeClass2";
            //expected = typeof(FakeClass1);

            // Act
            var simpleWriter = MockSimpleWriterFactory.GetWriter(writerType);

            // Assert
            //Should throw ArgumentException

        }


        [TestMethod]
        public void Does_SimpleWriterFactory_Has_Default_WriterType() {

            // Arrange
            Type expected;
            Type actual;

            expected = typeof(FakeClass1);

            // Act
            var simpleWriter = MockSimpleWriterFactory.GetWriter();
            actual = simpleWriter.GetType();

            // Assert
            Assert.IsInstanceOfType(simpleWriter, expected);
            Assert.IsInstanceOfType(simpleWriter, typeof(ISimplyWrite));
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Does_SimpleWriterFactory_Accept_Class_Initialization() {

            // Arrange
            string expected1;
            string expected2;
            string actual1;
            string actual2;
            string writerType;
            string arg1;
            string arg2;

            writerType = "FakeClass3";

            arg1 = expected1 = "MyParameter1";
            arg2 = expected2 = "MyParameter2";

            // Act 1
            var simpleWriter1 = MockSimpleWriterFactory.GetWriter(writerType, arg1);
            actual1 = ((FakeClass3)simpleWriter1).ParameterSpy1;

            // Assert 1
            Assert.AreEqual(expected1, actual1);

            // Support for multiple arguments
            // Act 2
            var simpleWriter2 = MockSimpleWriterFactory.GetWriter(writerType, arg1, arg2);
            actual1 = ((FakeClass3)simpleWriter1).ParameterSpy1;
            actual2 = ((FakeClass3)simpleWriter2).ParameterSpy2;

            // Assert 2

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            //Assert.AreEqual(expected2, actual2);

        }


    }
}
