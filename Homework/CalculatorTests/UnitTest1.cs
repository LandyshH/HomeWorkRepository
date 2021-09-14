using HomeWork;

using NUnit.Framework;

namespace CalculatorTests
{
    public class Tests
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
        
        [Test]
        public void ParseArguments_AllArgumentsCorrect_0Returned()
        {
            var args = new[]{"2", "+", "9"};
            var result = Parser.ParseArguments(args, out _, out _, out _);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ParseArguments_ArgumentsLengthIsNot3_2Returned()
        {
            var args = new[]{"1", "-", "14", "5"};
            var result = Parser.ParseArguments(args, out _, out _, out _);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ParseArguments_WrongOperation_1Returned()
        {
            var args = new[]{"6", "%", "3"};
            var result = Parser.ParseArguments(args, out _, out _, out _);
            Assert.AreEqual(1, result);
        }
        
        [Test]
        public void ParseArguments_FirstArgumentIsNotInt_3Returned()
        {
            var args = new[]{"6.2", "/", "3"};
            var result = Parser.ParseArguments(args, out _, out _, out _);
            Assert.AreEqual(3, result);
        }
        
        [Test]
        public void ParseArguments_SecondArgumentIsNotInt_3Returned()
        {
            var args = new[]{"6", "/", "a"};
            var result = Parser.ParseArguments(args, out _, out _, out _);
            Assert.AreEqual(3, result);
        }
        
        [Test]
        public void ParseArguments_ParseOperation_0Returned()
        {
            var args = new[]{"6", "*", "6"};
            var result = Parser.ParseArguments(args, out _, out _, out _);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ProgramCheck_AllArgumentsCorrect_0Returned()
        {
            var args = new[]{"9", "-", "1"};
            var result = Program.Main(args);
            Assert.AreEqual(0, result);
        }
        
        [Test]
        public void ProgramCheck_WrongOperation_1Returned()
        {
            var args = new[]{"9", "^", "2"};
            var result = Program.Main(args);
            Assert.AreEqual(1, result);
        }
    }
}