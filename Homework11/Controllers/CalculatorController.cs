using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using Homework11.Calculator;
using Homework11.StringExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Homework11.Controllers
{
    public class CalculatorController : Controller
    {
        public CalculatorController(ICacheCalculator cacheCalculator, IExceptionHandler exceptionHandler)
        {
            CacheCalculator = cacheCalculator;
            _exceptionHandler = exceptionHandler;
        }

        private readonly IExceptionHandler _exceptionHandler;
        private ICacheCalculator CacheCalculator { get; }


        [HttpGet]
        public string Calculate(string expression)
        {
            try
            {
                var calculation = CacheCalculator.TryCalculateWithCache(expression);
                return calculation;
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
                return "Error";
            }
        }
    }
}