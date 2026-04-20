using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chitozavryk.Ui.Tests.Data
{
	public static class PetTestData
	{
		public const string DefaultPetId = "1";
		public const string NewPetId = "777";
		public const string NewPetName = "Chitozavryk";

		public const string DefaultPetName = "doggie";
		public const string SuccessCode = "200";
		public const string NotFoundCode = "404";
		public const string NotFoundMessage = "Pet not found";

		public const string SectionGetById = "GET /pet/{petId}";
		public const string SectionPostPet = "POST /pet";
		public const string SectionPutPet = "PUT /pet";
		public const string SectionDeletePet = "DELETE /pet/{petId}";
	}
}
