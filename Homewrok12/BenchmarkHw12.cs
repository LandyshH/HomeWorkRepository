using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Homewrok8;
using Homewrok8.Calculator;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;
namespace Homewrok12
{
    public class HostBuilderCSharp : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(x => x.UseStartup<Startup>().UseTestServer());
    }
    
    public class HostBuilderFSharp : WebApplicationFactory<Homework6.Program.Startup>
    {
        protected override IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(x => x.UseStartup<Startup>().UseTestServer());
    }

    public class BenchmarkHw12 : IClassFixture<HostBuilder>
    {
        private HttpClient _clientCSharp;
        private HttpClient _clientFSharp;
        public string CSharpURL = "https://localhost:5001/Calc/Calculate?";
        public string FSharpURL = "http://localhost:5000/calculate?";

        [GlobalSetup]
        public void Setup()
        {
            _clientCSharp = new HostBuilderCSharp().CreateClient();
            _clientFSharp = new HostBuilderFSharp().CreateClient();
        }

       [Benchmark]
        public async Task CSharpCalculateMethod() => 
            await _clientCSharp.GetAsync(CSharpURL + "val1=4&op=Plus&val2=6");

        [Benchmark]
        public async Task FSharpCalculateMethod() =>
            await _clientFSharp.GetAsync(FSharpURL + "v1=4&Operation=Plus&v2=6");

        [Benchmark]
        public void FSharp_TryParseOperationInput()
        {
            Homework6.Parser.TryParseOperationInput(new Homework6.InputProblem.InputProblem(132, "Minus", 12));
        }

        private readonly Calculator _calculator = new Calculator();
        
        [Benchmark]
        public void CSharp_Add()
        {
            _calculator.Add(568, 24);
        }

        [Benchmark]
        public void CSharp_Minus()
        {
            _calculator.Minus(5234, 789);
        }
        
        [Benchmark]
        public void CSharp_Multiply()
        {
            _calculator.Multiply(56, 4);
        }
        
        [Benchmark]
        public void CSharp_Divide()
        {
            _calculator.Divide(121, 11);
        } 
    }
}