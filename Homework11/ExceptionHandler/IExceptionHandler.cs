using System;
using Microsoft.Extensions.Logging;

namespace Homework11.Calculator
{
    public interface IExceptionHandler 
    {
        void Handle(Exception exception);
    }
}