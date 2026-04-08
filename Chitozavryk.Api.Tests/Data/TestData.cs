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
			new object[] { new BookRequest { Title = new string('s', 100), Author = "Long Title Author" } },
			new object[] { new BookRequest { Title = "X", Author = "Short Title Author" } }
		};

		public static IEnumerable<object[]> UpdateBookData => new List<object[]>
		{
			new object[] { "New Title", "sold" },
			new object[] { "Only Title Changed", "available" }
		};
	}
}
