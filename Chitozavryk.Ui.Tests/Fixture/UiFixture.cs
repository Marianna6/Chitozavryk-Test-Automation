using Chitozavryk.Ui.Tests.Pages;
using Microsoft.Playwright;

namespace Chitozavryk.Ui.Tests.UiFixtures
{
	public class UiFixture : IAsyncLifetime
	{
		public IPage Page { get; private set; }

		private IPlaywright _playwright;
		private IBrowser _browser;

		public async Task InitializeAsync()
		{
			_playwright = await Playwright.CreateAsync();

			_browser = await _playwright.Chromium.LaunchAsync();

			Page = await _browser.NewPageAsync();
		}

		public async Task DisposeAsync()
		{
			if (_browser != null) await _browser.CloseAsync();
			_playwright?.Dispose();
		}
	}
}
