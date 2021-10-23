using Homework2;
using Homework2IL;
using NUnit.Framework;

namespace CalculatorTests
{
    public class ParserTests
    {
        [Test]
        public void ParseArguments_AllArgumentsCorrect_SuccessReturned()
        {
            var args = new[]{"2", "+", "9"};
            var result = Parser.ParseArguments(args, out _);
            Assert.AreEqual(HundledExceptions.Success, result);
        }

        [Test]
        public void ParseArguments_ArgumentsLengthIsNot3_WrongArgLengthReturned()
        {
            var args = new[]{"1", "-", "14", "5"};
            var result = Parser.ParseArguments(args, out _);
            Assert.AreEqual(HundledExceptions.WrongArgLength, result);
        }

        [Test]
        public void ParseArguments_WrongOperation_WrongOperationReturned()
        {
            var args = new[]{"6", "%", "3"};
            var result = Parser.ParseArguments(args, out _);
            Assert.AreEqual(HundledExceptions.WrongOperation, result);
        }
        
        [Test]
        public void ParseArguments_FirstArgumentIsNotInt_WrongArgFormatReturned()
        {
            var args = new[]{"6.2", "/", "3"};
            var result = Parser.ParseArguments(args, out _);
            Assert.AreEqual(HundledExceptions.WrongArgFormatInt, result);
        }
        
        [Test]
        public void ParseArguments_SecondArgumentIsNotInt_WrongArgFormatReturned()
        {
            var args = new[]{"6", "/", "a"};
            var result = Parser.ParseArguments(args, out _);
            Assert.AreEqual(HundledExceptions.WrongArgFormatInt, result);
        }
        
        [Test]
        public void ParseArguments_ParseOperation_SuccessReturned()
        {
            var args = new[]{"6", "*", "6"};
            var result = Parser.ParseArguments(args, out _);
            Assert.AreEqual(HundledExceptions.Success, result);
        }
        
    }
}