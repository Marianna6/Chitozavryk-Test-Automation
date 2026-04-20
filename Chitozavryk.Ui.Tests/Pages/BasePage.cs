using Microsoft.Playwright;
using Microsoft.Extensions.Configuration;

namespace Chitozavryk.Ui.Tests.Pages
{
	public abstract class BasePage
	{
		protected readonly IPage _page;
		protected readonly string _baseUrl;

		protected BasePage(IPage page)
		{
			_page = page;

			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			_baseUrl = config["UiBaseUrl"];
		}

		public async Task OpenAsync()
		{
			await _page.GotoAsync(_baseUrl);
		}

		public async Task AcceptCookiesIfVisibleAsync()
		{
			var cookiesBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Allow all cookies" });
			if (await cookiesBtn.IsVisibleAsync())
			{
				await cookiesBtn.ClickAsync();
			}
		}
	}
}
