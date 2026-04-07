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

		public static IEnumerable<object[]> GetBookData => new List<object[]>
		{
			new object[] { ValidBook },
			new object[] { new BookRequest{Title = "Another Book", Author = "Another Author"}}
		};
	}
}
