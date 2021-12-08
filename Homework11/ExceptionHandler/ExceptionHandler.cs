using System;
using Homework11.Controllers;
using Microsoft.Extensions.Logging;

namespace Homework11.Calculator
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

        public void Handle(NullReferenceException exception)
        {
            _logger.LogInformation(exception.Message);
        }
        public void Handle(ArgumentException exception)
        {
            _logger.LogInformation(exception.Message);
        }
        public void Handle(InvalidOperationException exception)
        {
            _logger.LogInformation(exception.Message);
        }
       
    }
}