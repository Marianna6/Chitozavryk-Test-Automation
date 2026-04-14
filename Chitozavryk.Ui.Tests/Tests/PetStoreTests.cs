using Chitozavryk.Ui.Tests.Pages;

using Microsoft.Playwright.Xunit;

namespace Chitozavryk.Ui.Tests.Tests
{
	public class PetStoreTests : PageTest
	{
		[Fact]
		public async Task ShouldFindPetById_WhenIdIsValid()
		{
			var petPage = new PetStorePage(Page);

			await petPage.OpenAsync();
			await petPage.FindPetByIdAsync("1");

			await Expect(petPage.ResponseResult).ToContainTextAsync("id");
		}
	}
}
