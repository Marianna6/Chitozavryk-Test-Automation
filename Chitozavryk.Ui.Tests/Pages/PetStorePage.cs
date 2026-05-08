using Microsoft.Playwright;
using Chitozavryk.Ui.Tests.Data;

namespace Chitozavryk.Ui.Tests.Pages
{
	public class PetStorePage : BasePage
	{
		public PetStorePage(IPage page) : base(page) { }

		public PostPetComponent PostPet => new(_page.Locator("#operations-pet-addPet"));

		public GetPetComponent GetPet => new(_page.Locator("#operations-pet-getPetById"));

		public PutPetComponent PutPet => new(_page.Locator("#operations-pet-updatePet"));

		public DeletePetComponent DeletePet => new(_page.Locator("#operations-pet-deletePet"));

		private ILocator ResponseBlock => _page.Locator(".responses-inner");

		public async Task<string> GetActualResponseAsync() => await ResponseBlock.InnerTextAsync();

	}
}
