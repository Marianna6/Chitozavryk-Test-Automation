using Microsoft.Playwright;
using Chitozavryk.Ui.Tests.Data;

namespace Chitozavryk.Ui.Tests.Pages
{
	public class PetStorePage : BasePage
	{
		public PetStorePage(IPage page) : base(page) { }

		private ILocator GetPetByIdSection => _page.GetByRole(AriaRole.Button, new() { Name = PetTestData.SectionGetById });

		public async Task ClickExpandSectionAsync()
		{
			await GetPetByIdSection.ClickAsync();
		}

	}
}
