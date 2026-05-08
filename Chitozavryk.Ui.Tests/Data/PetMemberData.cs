namespace Chitozavryk.Ui.Tests.Data
{
	public static class PetMemberData
	{

		public static IEnumerable<object[]> UpsertPetData => new List<object[]>
		{
			new object[] { "{\"id\": 777, \"name\": \"Chitozavryk\", \"status\": \"available\"}", "Chitozavryk" },
			new object[] { "{\"id\": 888, \"name\": \"Rex\", \"status\": \"pending\"}", "Rex" }
		};

		public static IEnumerable<object[]> SuccessPetIdData => new List<object[]>
		{
			new object[] { "1", "doggie" },
			new object[] { "777", "Chitozavryk" }
		};

		public static IEnumerable<object[]> InvalidPetIdData => new List<object[]>
		{
			new object[] { "99999999" },
            new object[] { "invalid_id" },
            new object[] { "0" },
            new object[] { "-5" }
        };

		public static IEnumerable<object[]> UpdatePetData => new List<object[]>
        {
            new object[] { "{\"id\": 777, \"name\": \"Chitozavryk\", \"status\": \"sold\"}", "Chitozavryk", "sold" }
        };
	}
}
