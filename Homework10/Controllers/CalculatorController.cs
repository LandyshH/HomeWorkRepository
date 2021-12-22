using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Homework10.Calculator;
using Homework10.ParallelCalculator;
using Homework10.StringExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Homework10.Controllers
{
    public class CalculatorController : Controller
    {
        public CalculatorController(ICacheCalculator cacheCalculator)
        {
            CacheCalculator = cacheCalculator;
        }

        private ICacheCalculator CacheCalculator { get; }


        [HttpGet]
        public string Calculate(string expression)
        { 
           var calculation = CacheCalculator.TryCalculateWithCache(expression);
           return calculation;
        }
    }
}