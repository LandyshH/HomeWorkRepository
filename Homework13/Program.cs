﻿using System;
using BenchmarkDotNet.Running;

namespace Homework13
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Tests>();
            Console.WriteLine("Hello World!");
        }
    }
}