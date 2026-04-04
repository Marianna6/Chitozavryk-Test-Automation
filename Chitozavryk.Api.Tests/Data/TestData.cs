using Chitozavryk.Api.Data.Models;

namespace Chitozavryk.Api.Tests.Data
{
	public static class TestData
	{
		public static BookRequest ValidBook => new BookRequest
		{
			Title = "Test Book",
			Author = "Test Author"
		};
	}
}
