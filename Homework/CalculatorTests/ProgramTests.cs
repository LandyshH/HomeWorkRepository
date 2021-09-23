using HomeWork;

using NUnit.Framework;

namespace CalculatorTests
{
    public class ProgramTests
    {
        [Test]
        public void Program_AllArgumentsCorrect_0Returned()
        {
            var args = new[]{"9", "-", "1"};
            var result = Program.Main(args);
            Assert.AreEqual(0, result);
        }
        
        [Test]
        public void Program_WrongOperation_1Returned()
        {
            var args = new[]{"9", "^", "2"};
            var result = Program.Main(args);
            Assert.AreEqual(1, result);
        }
    }
}