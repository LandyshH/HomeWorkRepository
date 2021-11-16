using Homewrok8.Calculator;
using Homewrok8.Controllers;
using Xunit;

namespace Tests8
{
    public class TheoryTests
    {
        [Theory]
        [InlineData("9", "4", "Plus", "13")]
        [InlineData("1000", "7", "Minus",  "993")]
        [InlineData("63", "3", "Divide", "21")]
        [InlineData("56", "7", "Multiply", "392")]
        public void Calculate_CorrectArguments_CorrectResultReturned(string val1, string val2, string operation, string expected)
        {
            var calculator = new Calculator();
            var actualResult = new CalcController().Calculate(calculator, val1, operation, val2);
            Assert.Equal(expected, actualResult);
        }
        
        [Theory]
        [InlineData("a", "4", "Plus", "\"Wrong parameter\"")]
        [InlineData("1000", "b", "Minus",  "\"Wrong parameter\"")]
        [InlineData("63", "3", "pepe", "\"Wrong operation\"")]
        [InlineData("63", "0", "Divide", "\"Infinity\"")]
        [InlineData("99", "7", "Minus",  "92")]
        public void Calculate_IncorrectArguments_ExceptionStringReturned(string val1, string val2, string operation, string expected)
        {
            var calculator = new Calculator();
            var actualResult = new CalcController().Calculate(calculator, val1, operation, val2);
            Assert.Equal(expected, actualResult);
        }
    }
}