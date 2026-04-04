using Chitozavryk.Api.Data.Services;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Chitozavryk.Api.Data.Fixtures
{
	public class ApiFixture
	{
		public BookService BookService { get; }
		public IConfiguration Configuration { get; }

		public ApiFixture()
		{

			Configuration = new ConfigurationBuilder()
			  .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			  .AddJsonFile("appsettings.json")
			  .Build();

			var baseUrl = Configuration["BaseUrl"] ?? "https://petstore.swagger.io/v2";
			var token = Configuration["AdminToken"] ?? "admin_token";

			var options = new RestClientOptions(baseUrl);
			var client = new RestClient(options);

			client.AddDefaultHeader("Authorization", $"Bearer {token}");

			BookService = new BookService(client);
		}

		public string AdminToken => Configuration["AdminToken"] ?? "admin_token";
		public string InvalidToken => Configuration["InvalidToken"] ?? "invalid_token";

	}
}
