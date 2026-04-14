using Microsoft.Playwright;

namespace Chitozavryk.Ui.Tests.Pages
{
	public class PetStorePage
	{
		private readonly IPage _page;

		private ILocator CookiesBtn => _page.GetByRole(AriaRole.Button, new() { Name = "Allow all cookies" });
		private ILocator GetPetByIdSection => _page.GetByRole(AriaRole.Button, new() { Name = "GET /pet/{petId} Find pet by" });
		private ILocator TryItOutBtn => _page.GetByRole(AriaRole.Button, new() { Name = "Try it out" });
		private ILocator PetIdInput => _page.GetByRole(AriaRole.Textbox, new() { Name = "petId" });
		private ILocator ExecuteBtn => _page.GetByRole(AriaRole.Button, new() { Name = "Execute" });

		public ILocator ResponseResult => _page.GetByRole(AriaRole.Row, new() { Name = "200 successful operation" }).Locator("pre");

		public PetStorePage(IPage page) => _page = page;

		public async Task OpenAsync() => await _page.GotoAsync("https://petstore.swagger.io/");

		public async Task FindPetByIdAsync(string id)
		{
			if (await CookiesBtn.IsVisibleAsync())
			{
				await CookiesBtn.ClickAsync();
			}

			await GetPetByIdSection.ClickAsync();
			await TryItOutBtn.ClickAsync();
			await PetIdInput.FillAsync(id);
			await ExecuteBtn.ClickAsync();
		}

	}
}
