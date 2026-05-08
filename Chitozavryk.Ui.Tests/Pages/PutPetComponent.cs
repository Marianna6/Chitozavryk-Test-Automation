using Microsoft.Playwright;

namespace Chitozavryk.Ui.Tests.Pages
{
	public class PutPetComponent : BaseSwaggerComponent
	{
		public PutPetComponent(ILocator root) : base(root) { }

		private ILocator JsonInput => _root.GetByLabel("Edit Value");

		public async Task UpdatePetAsync(string json)
		{
			await ExpandAsync();
			await ClickTryItOutAsync();
			await JsonInput.FillAsync(json);
			await ClickExecuteAsync();
		}
	}
}
