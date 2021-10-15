using Homework4;
using NUnit.Framework;

namespace Tests4
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
        public void Program_WrongOperation_ExceptionReturned()
        {
            var args = new[]{"9", "^", "2"};
            Assert.Throws<HundledExceptions.WrongOperation>(() => Program.Main(args));
        }
    }
}