using Chitozavryk.Api.Data.Models;
using RestSharp;

namespace Chitozavryk.Api.Data.Services
{
	public class BookService
	{

		private readonly RestClient _client;

		public BookService(RestClient client)
		{
			_client = client;
		}

		public async Task<RestResponse<BookResponse>> CreateBook(BookRequest book, string token = null)
		{
			var request = new RestRequest("pet", Method.Post);
			request.AddJsonBody(book);

			if (token != null)
			{
				request.AddHeader("api_key", token);
			}

			return await _client.ExecuteAsync<BookResponse>(request);
		}

		public async Task<RestResponse<BookResponse>> GetBookById(long bookId)
		{
			var request = new RestRequest($"pet/{bookId}", Method.Get);

			return await _client.ExecuteAsync<BookResponse>(request);
		}

		public async Task<RestResponse> DeleteBook(long bookId)
		{
			var request = new RestRequest($"pet/{bookId}", Method.Delete);

			return await _client.ExecuteAsync(request);
		}

		public async Task<RestResponse<BookResponse>> UpdateBook(BookResponse book)
		{
			var request = new RestRequest($"pet", Method.Put);

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
