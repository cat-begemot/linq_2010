using System;

namespace Chapter1
{
	public class EmployeeOptionEntry
	{
		public int Id;
		public long OptionsCount;
		public DateTime DateAwarded;

		public static EmployeeOptionEntry[] GetEmployeeOptionEntries()
		{
			var empOptions = new EmployeeOptionEntry[]
			{
				new EmployeeOptionEntry {
					Id = 1,
					OptionsCount = 2,
					DateAwarded = DateTime.Parse("1999/12/31") },
				new EmployeeOptionEntry {
					Id = 2,
					OptionsCount = 10000,
					DateAwarded = DateTime.Parse("1992/06/30")  },
				new EmployeeOptionEntry {
					Id = 2,
					OptionsCount = 10000,
					DateAwarded = DateTime.Parse("1994/01/01")  },
				new EmployeeOptionEntry {
					Id = 3,
					OptionsCount = 5000,
					DateAwarded = DateTime.Parse("1997/09/30") },
				new EmployeeOptionEntry {
					Id = 2,
					OptionsCount = 10000,
					DateAwarded = DateTime.Parse("2003/04/01")  },
				new EmployeeOptionEntry {
					Id = 3,
					OptionsCount = 7500,
					DateAwarded = DateTime.Parse("1998/09/30") },
				new EmployeeOptionEntry {
					Id = 3,
					OptionsCount = 7500,
					DateAwarded = DateTime.Parse("1998/09/30") },
				new EmployeeOptionEntry {
					Id = 4,
					OptionsCount = 1500,
					DateAwarded = DateTime.Parse("1997/12/31") },
				new EmployeeOptionEntry {
					Id = 101,
					OptionsCount = 2,
					DateAwarded = DateTime.Parse("1998/12/31") }
			};

			return empOptions;
		}
	}
}