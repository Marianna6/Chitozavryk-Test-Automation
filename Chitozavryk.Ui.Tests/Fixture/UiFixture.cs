using Chitozavryk.Ui.Tests.Pages;
using Microsoft.Playwright;

namespace Chitozavryk.Ui.Tests.UiFixtures
{
	public class UiFixture
	{
		public PetStorePage CreatePetPage(IPage page)
		{
			return new PetStorePage(page);
		}
	}
}
