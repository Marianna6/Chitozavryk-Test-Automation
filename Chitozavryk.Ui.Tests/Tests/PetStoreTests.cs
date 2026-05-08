using Chitozavryk.Ui.Tests.Data;
using Chitozavryk.Ui.Tests.Pages;
using Chitozavryk.Ui.Tests.UiFixtures;

using Microsoft.Playwright.Xunit;

using Shouldly;

public class PetSearchTests : UiFixture
{
	[Theory]
	[MemberData(nameof(PetMemberData.UpsertPetData), MemberType = typeof(PetMemberData))]
	public async Task CreatePet_ShouldShowCorrectName_InResponse(string json, string expectedName)
	{
		var petPage = new PetStorePage(Page);
		await petPage.OpenAsync();

		await petPage.PostPet.CreatePetAsync(json);

		var responseText = await petPage.GetActualResponseAsync();

		responseText.ShouldContain(expectedName);
		responseText.ShouldContain(PetTestData.SuccessCode);
	}

	[Theory]
	[MemberData(nameof(PetMemberData.SuccessPetIdData), MemberType = typeof(PetMemberData))]
	public async Task GetPet_ShouldFindPet_WhenIdIsValid(string id, string expectedName)
	{
		var petPage = new PetStorePage(Page);
		await petPage.OpenAsync();

		await petPage.GetPet.SearchByIdAsync(id);

		var responseText = await petPage.GetActualResponseAsync();

		responseText.ShouldContain(id);
		responseText.ShouldContain(expectedName);
		responseText.ShouldContain(PetTestData.SuccessCode);
	}

	[Theory]
	[MemberData(nameof(PetMemberData.SuccessPetIdData), MemberType = typeof(PetMemberData))]
	public async Task DeletePet_ShouldDeletePet(string id, string expectedName)
	{
		var petPage = new PetStorePage(Page);
		await petPage.OpenAsync();

		await petPage.DeletePet.DeleteByIdAsync(id);
		var deleteResponse = await petPage.GetActualResponseAsync();

		deleteResponse.ShouldContain(PetTestData.SuccessCode);

		await petPage.GetPet.SearchByIdAsync(id);
		var getResponse = await petPage.GetActualResponseAsync();

		getResponse.ShouldContain(PetTestData.NotFoundCode);
		getResponse.ShouldContain(PetTestData.NotFoundMessage);

	}

	[Theory]
	[MemberData(nameof(PetMemberData.UpdatePetData), MemberType = typeof(PetMemberData))]
	public async Task UpdatePet_ShouldChangePetStatus(string json, string expectedName, string expectedStatus)
	{
		var petPage = new PetStorePage(Page);
		await petPage.OpenAsync();

		await petPage.PutPet.UpdatePetAsync(json);
		var responseText = await petPage.GetActualResponseAsync();

		responseText.ShouldContain(expectedName);
		responseText.ShouldContain(expectedStatus);
		responseText.ShouldContain(PetTestData.SuccessCode);

	}

	[Theory]
	[MemberData(nameof(PetMemberData.InvalidPetIdData), MemberType = typeof(PetMemberData))]
	public async Task GetPet_WhenIdIsInvalid_ShouldReturnNotFound(string id)
	{
		var petPage = new PetStorePage(Page);
		await petPage.OpenAsync();

		await petPage.GetPet.SearchByIdAsync(id);

		var responseText = await petPage.GetActualResponseAsync();

		responseText.ShouldContain(id);
		responseText.ShouldContain(PetTestData.NotFoundMessage);
	}

	[Theory]
	[MemberData(nameof(PetMemberData.InvalidPetIdData), MemberType = typeof(PetMemberData))]
	public async Task DeletePet_WhenIdIsInvalid_ShouldReturnError(string id)
	{
		var petPage = new PetStorePage(Page);
		await petPage.OpenAsync();

		await petPage.DeletePet.DeleteByIdAsync(id);

		var responseText = await petPage.GetActualResponseAsync();

		responseText.ShouldContain(PetTestData.NotFoundCode);
	}

}