using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace RegalApi.Tests
{
	public class Class1
	{
		[Fact]
		public async Task MyTest()
		{
			var server = new TestServer(new WebHostBuilder()
				.UseContentRoot(Directory.GetCurrentDirectory())
				//.UseConfiguration(configBuilder.Build())
				.UseEnvironment("Development")
				//.ConfigureLogging(logging =>
				//{
				//	logging.AddConsole();
				//	logging.SetMinimumLevel(LogLevel.Warning);
				//	//For when things are really hard to track down:
				//	//logging.SetMinimumLevel(LogLevel.Trace);
				//
				//	//For tests that shouldn't log errors
				//	logging.Services.AddSingleton<ILoggerProvider, ExceptionOnErrorLoggerProvider>();
				//})
				.UseStartup(typeof(Startup)));

			var client = server.CreateClient();

			var res = await client.GetAsync("/api/values");

			res.EnsureSuccessStatusCode();
		}
	}
}
