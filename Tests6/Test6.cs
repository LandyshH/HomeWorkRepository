using System.Net.Http;
using System.Threading.Tasks;
using Homework6;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;


namespace Tests6
{
	public class HostBuilder : WebApplicationFactory<Program.Startup>
	{
		protected override IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
			.ConfigureWebHostDefaults(x => x.UseStartup<Program.Startup>().UseTestServer());
	}
	public class Tests6 : IClassFixture<HostBuilder>
	{
		private readonly HttpClient _client;
		public Tests6(HostBuilder server)
		{
			_client = server.CreateClient();
		}
		
		[Theory]
		[InlineData("9.9", "3.1", "Plus", "13.0")]
		[InlineData("9.31", "2.56", "Minus",  "6.75")]
		[InlineData("9.6", "3", "Divide", "3.2")]
		[InlineData("56.64", "7.8", "Multiply", "441.792")]
		public async Task Program_CalculateProblem_ResultReturned(string val1, string val2, string operation, string expected)
		{
			var response = await _client.GetAsync($"http://localhost:5000/calculate?v1={val1}&Operation={operation}&v2={val2}");
			var actual = await response.Content.ReadAsStringAsync();
			Assert.Equal(expected, actual);
		}
		
		[Theory]
		[InlineData("a", "3.1", "Plus", "\"Could not parse value 'a' to type System.Decimal.\"")]
		[InlineData("9.31", "b", "Minus",  "\"Could not parse value 'b' to type System.Decimal.\"")]
		[InlineData("56.64", "7.8", "Not operation",  "\"Wrong operation.\"")]
		public async Task Program_WrongCalculateProblem_ErrorReturned(string val1, string val2, string operation, string expected)
		{
			var response = await _client.GetAsync($"http://localhost:5000/calculate?v1={val1}&Operation={operation}&v2={val2}");
			var actual = await response.Content.ReadAsStringAsync();
			Assert.Equal(expected, actual);
		}
	}
}