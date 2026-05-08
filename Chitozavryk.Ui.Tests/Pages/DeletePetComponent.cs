using Microsoft.Playwright;

namespace Chitozavryk.Ui.Tests.Pages
{
	public class DeletePetComponent : BaseSwaggerComponent
	{
		public DeletePetComponent(ILocator root) : base(root) { }

		private ILocator IdInput => _root.GetByRole(AriaRole.Textbox, new() { Name = "petId" });

		public async Task DeleteByIdAsync(string id)
		{
			await ExpandAsync();
			await ClickTryItOutAsync();
			await IdInput.FillAsync(id);
			await ClickExecuteAsync();
		}
	}
}