using System;
using Homework11.Calculator;
using Homework11.Controllers;
using Microsoft.Extensions.Logging;

namespace Homework11.ExceptionHandler
{
    public sealed class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CalculatorController> _logger;
        public ExceptionHandler(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        public void Handle(Exception exception)
        {
            Handle((dynamic) exception);
        }

        private void Handle(NullReferenceException exception)
        {
            _logger.LogCritical(exception.Message);
        }

        private void Handle(ArgumentException exception)
        {
            _logger.LogError(exception.Message);
        }

        private void Handle(InvalidOperationException exception)
        {
            Console.Beep();
            _logger.LogInformation(exception.Message);
        }
       
    }
}