using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcClassBr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ErrorLibrary;

namespace AnalaizerClassLibrary.Tests
{
    [TestClass]
    public class CalcClassTests
    {
        public TestContext TestContext { get; set; }
     
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml", "TestWithValidNumbers", DataAccessMethod.Sequential)]
        public void Div_WhenNumbersAreValid_ReturnsExpectedResult()
        {
            //Arrange
            long incomingFirstNumber = Convert.ToInt64(TestContext.DataRow["incomingFirstNumber"]);
            long incomingSecondNumber = Convert.ToInt64(TestContext.DataRow["incomingSecondNumber"]);
            long expected = Convert.ToInt64(TestContext.DataRow["expectedResult"]);

            //Actual
            long actual = CalcClass.Div(incomingFirstNumber, incomingSecondNumber);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "testData.xml", "TestWithInvalidNumbers", DataAccessMethod.Sequential)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), ErrorsExpression.ERROR_06)]
        public void Div_WhenNumbersAreInvalid_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            long incomingFirstNumber = Convert.ToInt64(TestContext.DataRow["incomingFirstNumber"]);
            long incomingSecondNumber = Convert.ToInt64(TestContext.DataRow["incomingSecondNumber"]);

            //Actual
            long actual = CalcClass.Div(incomingFirstNumber, incomingSecondNumber);

            //Assert - - Expects exception
        }
    }
}