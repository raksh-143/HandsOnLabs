using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SimpleCalculatorLibrary;
using SimpleCalculator.DataAccess;
using Moq;

namespace SimpleCalculator.UnitTest
{
    //class MockCalculatorRepo : ICalculatorRepo
    //{
    //    public bool Save(string data)
    //    {
    //        return true;
    //    }
    //}
    [TestClass]
    public class CalculatorUnitTest
    {
        private Calculator target = null;
        Mock<ICalculatorRepo> mock = null;
        [TestInitialize]
        public void Init()
        {
            //ICalculatorRepo mock = new MockCalculatorRepo();
            //target = new Calculator(new MockCalculatorRepo());
            mock = new Mock<ICalculatorRepo>();
            //class MockCalculatorRepo : ICalculatorRepo
            //{
            //}
            mock.Setup(m => m.Save(string.Empty)).Returns(true);
            //    public bool Save(string data)
            //    {
            //        return true;
            //    }
            target = new Calculator(mock.Object);
        }
        [TestCleanup]
        public void Cleanup()
        {
            target = null;
            mock = null;
        }

        [TestMethod]
        public void Sum_WithValidInput_ShouldGiveValidResult()//Test cases
        {
            //AAA
            //ARRANGE
            int fno = 10;
            int sno = 20;
            int expected = 30;
            //ACT
            int actual = target.Sum(fno, sno);
            //ASSERT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NumberNegativeException))]
        public void Sum_WithNegativeInput_ShouldThrowExp()//Test cases
        {
            //AAA
            //ARRANGE
            //ACT
            target.Sum(-1, -1);
            //ASSERT//Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NumberOddException))]
        public void Sum_WithOddInput_ShouldThrowExp()//Test cases
        {
            target.Sum(3, 1);
        }

        [TestMethod]
        public void Sum_WithValidInput_ShouldCallSaveMethod()//Test cases
        {
            target.Sum(10, 20);
            mock.Verify(m => m.Save("10+20=30"), Times.Once()); //Atleast once the save method should be called else the test fails
        }
    }
}
