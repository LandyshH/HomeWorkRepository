using System;
using Homework4;
using NUnit.Framework;

namespace Tests4
{
    public class ParserTests
    {
        [Test]
        public void ParseArguments_AllArgumentsCorrect_SuccessReturned()
        {
            var args = new[]{"2", "+", "9"};
            var (item1, item2, item3) = Parser.ParseArguments(args);
            var res = new ValueType[] {item1, item2, item3};
            var exp = new ValueType[] {2, CalculatorOperation.Plus, 9};
            Assert.AreEqual(exp, res);
        } 

        [Test]
        public void ParseArguments_ArgumentsLengthIsNot3_WrongArgLengthReturned()
        {
            var args = new[]{"1", "-", "14", "5"};
            Assert.Throws<HundledExceptions.WrongArgLength>(() => Parser.ParseArguments(args));
        }

        [Test]
        public void ParseArguments_WrongOperation_WrongOperationReturned()
        {
            var args = new[]{"6", "%", "3"};
            Assert.Throws<HundledExceptions.WrongOperation>(() => Parser.ParseArguments(args));
        }
        
        [Test]
        public void ParseArguments_FirstArgumentIsNotInt_WrongArgFormatReturned()
        {
            var args = new[]{"6.2", "/", "3"};
            Assert.Throws<HundledExceptions.WrongArgFormatInt>(() => Parser.ParseArguments(args));
        }
        
        [Test]
        public void ParseArguments_SecondArgumentIsNotInt_WrongArgFormatReturned()
        {
            var args = new[]{"6", "/", "a"};
            var result = Parser.TryParseOperationOrQuit(args[1]);
            Assert.Throws<HundledExceptions.WrongArgFormatInt>(() => Parser.ParseArguments(args));
        }
        
        [Test]
        public void ParseArguments_ParseOperation_SuccessReturned()
        {
            var args = new[]{"6", "*", "6"};
            var (item1, item2, item3) = Parser.ParseArguments(args);
            var res = new ValueType[] {item1, item2, item3};
            var exp = new ValueType[] {6, CalculatorOperation.Multiply, 6};
            Assert.AreEqual(exp, res);
        }
    }
}