using Homework2;
using Homework2IL;

using NUnit.Framework;

namespace CalculatorTests
{
    public class CalculatorTests
    {

        [Test]
        public void Sum_3Plus7_10Returned()
        {
            var res = Calculator.Calculate(3, CalculatorOperation.Plus, 7);
            Assert.AreEqual(10, res);
        }
        
        [Test]
        public void Composition_8Multiply7_56Returned()
        {
            var res = Calculator.Calculate(8, CalculatorOperation.Multiply, 7);
            Assert.AreEqual(56, res);
        }
        
        [Test]
        public void Difference_1000Minus7_993Returned()
        {
            var res = Calculator.Calculate(1000, CalculatorOperation.Minus, 7);
            Assert.AreEqual(993, res);
        }
        
        [Test]
        public void Fraction_121Multiply11_11Returned()
        {
            var res = Calculator.Calculate(121, CalculatorOperation.Divide, 11);
            Assert.AreEqual(11, res);
        }
        
    }
}