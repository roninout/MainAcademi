using System;
using ClassWork_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        [TestCategory("MyCalcDivision")]
        public void Check_Correct_Devision()
        {
            // arrange
            double arg1 = 4.0;
            double arg2 = 2.0;
            double expected = 2.0;
            // act
            double actual = Calculator.Div(arg1, arg2);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Check_Exception_Devision()
        {
            // arrange
            double arg1 = 4.0;
            double arg2 = 0.0;
            // act
            double actual = Calculator.Div(arg1, arg2);
            // assert

        }
    }
}
