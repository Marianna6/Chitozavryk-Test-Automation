using Chitozavryk.Api.Tests.Models;
using Chitozavryk.Api.Tests.Services;

namespace Chitozavryk.Api.Tests.Fixtures
{
	public class ApiFixture
	{
		public BookService BookService { get; } = new BookService();

		public string AdminToken => "admin_token";
		public string InvalidToken => "invalid_token";

		public BookRequest ValidBook => new BookRequest
		{
			Title = "Test Book",
			Author = "Test Author"
		};

	}
}
