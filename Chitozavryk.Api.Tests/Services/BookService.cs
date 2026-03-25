using Chitozavryk.Api.Tests.Models;
using RestSharp;

namespace Chitozavryk.Api.Tests.Services
{
	public class BookService
	{

		private readonly RestClient _client;

		public BookService()
		{
			_client = new RestClient("https://petstore.swagger.io/v2");
		}

		public async Task<RestResponse<BookResponse>> CreateBook(BookRequest book, string token)
		{

			var request = new RestRequest("pet", Method.Post);

			request.AddHeader("Authorization", $"Bearer {token}");
			request.AddHeader("Content-Type", "application/json");

			request.AddJsonBody(book);

			return await _client.ExecuteAsync<BookResponse>(request);
		}

		public async Task<RestResponse<BookResponse>> GetBookById(long bookId, string token)
		{

			var request = new RestRequest($"pet/{bookId}", Method.Get);


			request.AddHeader("Authorization", $"Bearer {token}");

			return await _client.ExecuteAsync<BookResponse>(request);
		}

		public async Task<RestResponse> DeleteBook(long bookId, string token)
		{
			var request = new RestRequest($"pet/{bookId}", Method.Delete);
			request.AddHeader("Authorization", $"Bearer {token}");
			return await _client.ExecuteAsync(request);
		}

		public async Task<RestResponse<BookResponse>> UpdateBook(BookResponse book, string token)
		{

			var request = new RestRequest($"pet", Method.Put);
			request.AddHeader("Authorization", $"Bearer {token}");

			request.AddJsonBody(book);

			return await _client.ExecuteAsync<BookResponse>(request);
		}

		public async Task<RestResponse<BookResponse>> UpdateBookTitleOnly(long bookId, string newTitle)
		{
			// NOTE: PetStore API doesn't have a native PATCH method.
			// We use POST to pet/{bookId} with form parameters to simulate partial update
			var request = new RestRequest($"pet/{bookId}", Method.Post);

			request.AddParameter("name", newTitle);

			return await _client.ExecuteAsync<BookResponse>(request);
		}
	}
}
