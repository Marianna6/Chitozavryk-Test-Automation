using Microsoft.Playwright;

namespace Chitozavryk.Ui.Tests.Pages
{
	public abstract class BaseSwaggerComponent
	{
		protected readonly ILocator _root;

		protected BaseSwaggerComponent(ILocator root)
		{
			_root = root;
		}

		protected ILocator TryItOutBtn => _root.Locator(".try-out");
		protected ILocator ExecuteBtn => _root.Locator(" .execute");

		public async Task ExpandAsync()=> await TryItOutBtn.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 5000 });

		public async Task ClickTryItOutAsync()=> await TryItOutBtn.ClickAsync(new LocatorClickOptions { Force = true });

		public async Task ClickExecuteAsync()
		{
			await ExecuteBtn.ScrollIntoViewIfNeededAsync();
			await ExecuteBtn.ClickAsync(new LocatorClickOptions { Force = true });
		}
	}
}
