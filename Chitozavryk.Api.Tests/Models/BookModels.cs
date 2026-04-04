using System.Text.Json.Serialization;

namespace Chitozavryk.Api.Data.Models
{

	public class BookRequest
	{
		// PetStore API uses 'name' for the book title.
		// We map it here to keep 'Title' clear.
		[JsonPropertyName("name")]
		public string Title { get; set; }

		// This field is for internal logic only.
		// We hide it because PetStore API doesn't support it.
		[JsonIgnore]
		public string Author { get; set; }

	}

	public class BookResponse : BookRequest

	{
		// We use lowercase 'id' to match exactly what the PetStore server expects.
		[JsonPropertyName("id")]
		public long Id { get; set; }

		// This field is added to demonstrate the difference between PUT
		// and PATCH methods in the test suite.
		[JsonPropertyName("status")]
		public string Status { get; set; }

	}

}
