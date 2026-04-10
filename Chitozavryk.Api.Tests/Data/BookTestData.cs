using Chitozavryk.Api.Data.Models;

namespace Chitozavryk.Api.Tests.Data
{
	public static class BookTestData
	{
		private static BookRequest ValidBook => new BookRequest
		{
			Title = "Test Book",
			Author = "Test Author"
		};

		public static IEnumerable<object[]> GetBookData => new List<object[]>
		{
			new object[] { ValidBook },
			new object[] { new BookRequest { Title = new string('s', 100), Author = "Long Title Author" } },
			new object[] { new BookRequest { Title = "X", Author = "Short Title Author" } }
		};

		public static IEnumerable<object[]> GetGuestAccessData => new List<object[]>
		{
			new object[] { ValidBook, "invalid_token_123" },
            new object[] { ValidBook, "" },
            new object[] { ValidBook, "   " }
        };

		public static IEnumerable<object[]> GetInvalidIdData => new List<object[]>
		{
			new object[] { 0 },
			new object[] { -1 },
			new object[] { long.MaxValue }
        };

		public static IEnumerable<object[]> GetUpdateBookData => new List<object[]>
		{
			new object[] { ValidBook, "New Title", "sold" },
			new object[] { ValidBook, "Only Title Changed", "available" }
		};
	}
}
