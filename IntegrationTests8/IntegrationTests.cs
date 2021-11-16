using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Homewrok8;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;


namespace Tests8
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(x => x.UseStartup<Startup>().UseTestServer());
    }
    
    public class IntegrationTests8 : IClassFixture<HostBuilder>
    {
        private readonly HttpClient _client;
        public IntegrationTests8(HostBuilder server)
        {
            _client = server.CreateClient();
        }
        
        [Theory]
        [InlineData("9", "4", "Plus", "13")]
        [InlineData("1000", "7", "Minus",  "993")]
        [InlineData("63", "3", "Divide", "21")]
        [InlineData("56", "7", "Multiply", "392")]
        public async Task Calculate_CorrectArguments_CorrectResultReturned(string val1, string val2, string operation, string expected)
        {
            var response = await _client.GetAsync($"https://localhost:5001/Calc/Calculate?val1={val1}&op={operation}&val2={val2}");
            var actual = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("a", "4", "Plus", "Wrong parameter")]
        [InlineData("1000", "b", "Minus",  "Wrong parameter")]
        [InlineData("63", "3", "pepe", "Wrong operation")]
        [InlineData("63", "0", "Divide", "Infinity")]
        public async Task Calculate_IncorrectArguments_ExceptionStringReturned(string val1, string val2, string operation, string expected)
        {
            var response = await _client.GetAsync($"https://localhost:5001/Calc/Calculate?val1={val1}&op={operation}&val2={val2}");
            var actual = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected, actual);
        }
    }
}