namespace Chapter1
{
	public class Actor
	{
		public int birthYear;
		public string firstName;
		public string lastName;

		public static Actor[] GetActors()
		{
			Actor[] actors = new Actor[] {
				new Actor { birthYear = 1964, firstName = "Keanu", lastName = "Reeves" },
				new Actor { birthYear = 1968, firstName = "Owen", lastName = "Wilson" },
				new Actor { birthYear = 1960, firstName = "James", lastName = "Spader" },
				new Actor { birthYear = 1964, firstName = "Sandra", lastName = "Bullock" },
			};

			return (actors);
		}
	}

	public class Actor2
	{
		public string birthYear;
		public string firstName;
		public string lastName;

		public static Actor2[] GetActors()
		{
			Actor2[] actors = new Actor2[] {
				new Actor2 { birthYear = "1964", firstName = "Keanu", lastName = "Reeves" },
				new Actor2 { birthYear = "1968", firstName = "Owen", lastName = "Wilson" },
				new Actor2 { birthYear = "1960", firstName = "James", lastName = "Spader" },
				new Actor2 { birthYear = "01964", firstName = "Sandra", lastName = "Bullock" },
			};

			return (actors);
		}
	}
}