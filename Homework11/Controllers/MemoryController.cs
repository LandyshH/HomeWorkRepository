using System;
using Microsoft.AspNetCore.Mvc;

namespace Homework11.Controllers
{
    public class MemoryController : Controller
    {
        private static string str = "";

        public IActionResult Memory()
        {
            for (var i = 0; i < 1000; i++)
            {
                str += i.ToString();
            }

            return Ok();
        }
    }
}