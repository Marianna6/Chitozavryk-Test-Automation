using Microsoft.Playwright;

namespace Chitozavryk.Ui.Tests.Pages
{
	public class PostPetComponent : BaseSwaggerComponent
	{
		public PostPetComponent(ILocator root) : base(root) { }

		private ILocator JsonInput => _root.GetByLabel("Edit Value");

		public async Task CreatePetAsync(string json)
		{
			await ExpandAsync();
			await ClickTryItOutAsync();
			await JsonInput.FillAsync(json);
			await ClickExecuteAsync();
		}
	}
}
