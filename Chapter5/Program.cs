using System;
using System.Collections.Generic;
using System.Linq;
using Chapter1;

namespace Chapter5
{
    class Program
    {
		private static string[] presidents =
		{
			"Adams", "Arthur", "Bush", "Bush", "Bush", "Cleveland",
			"Clinton", "CoolIdge", "Eisenhower", "Fillmore", "Ford", "Garfield",
			"Grant", "Harding", "Harrison", "Hayes", "Hoover", "Jackson",
			"Jefferson", "Johnson", "Kennedy", "Lincoln", "Madison", "McKinley",
			"Monroe", "Nixon", "Obama", "Pierce", "Polk", "Reagan", "Roosevelt",
			"Taft", "Taylor", "Truman", "Tyler", "Van Buren", "Washington", "Wilson"
		};

		static void Main(string[] args)
        {
	        UseAggregate();

	        Console.ReadLine();
        }

		private static void UseAggregate()
		{
			int n = 5;
			var intSeq = Enumerable.Range(1, n);

			foreach(var item in intSeq)
				Console.WriteLine(item);

			int agg = intSeq.Aggregate((av, e) => av + e);

			Console.WriteLine(agg);
		}

		private static void UseSingle()
		{
			var emp = Actor.GetActors().Where(actor => actor.birthYear == 1965).SingleOrDefault();

			Console.WriteLine(emp == null ? "Not found or mulriple elements" : $"{emp.firstName} {emp.lastName}");
		}

		#region Equality

		private static void UseSequenceEqual()
        {
	        string[] str1 = {"001", "49", "017", "0080", "00027", "2"};
	        string[] str2 = {"1", "0049", "17", "080", "27", "02"};

	        bool eq = str1.SequenceEqual(str2, new StringifiedNumberComparer());

	        Console.WriteLine(eq);
        }

        #endregion

        #region Conversion

        private static void UseToLookupFirst()
        {
	        ILookup<int, Actor> lookup = Actor.GetActors().ToLookup(key => key.birthYear);

	        IEnumerable<Actor> actors = lookup[1965];
			foreach(var actor in actors)
				Console.WriteLine($"{actor.firstName} {actor.lastName} - {actor.birthYear}");
        }

        private static void UseToLookupSecond()
        {
	        ILookup<string, Actor2> lookup =
		        Actor2.GetActors().ToLookup(key => key.birthYear, new StringifiedNumberComparer());

	        IEnumerable<Actor2> actors = lookup["00000001964"];
	        foreach (var actor in actors)
		        Console.WriteLine($"{actor.firstName} {actor.lastName} - {actor.birthYear}");
        }

        private static void UseToLookupThird()
        {
			ILookup<int, string> lookup =
				Actor.GetActors().ToLookup(
					key => key.birthYear,
					value => $"{value.firstName} {value.lastName} - {value.birthYear}");

			IEnumerable<string> actors = lookup[1964];
			foreach (var actor in actors)
				Console.WriteLine(actor);
		}

		private static void UseToLookupFourth()
		{
			ILookup<string, string> lookup =
				Actor2.GetActors().ToLookup(
					key => key.birthYear,
					value => $"{value.firstName} {value.lastName} - {value.birthYear}",
					new StringifiedNumberComparer());

			IEnumerable<string> actors = lookup["00000001964"];
			foreach (var actor in actors)
				Console.WriteLine(actor);
		}


		private static void UseToDictionaryFirst()
        {
	        Dictionary<int, Employee> eDictionary =
		        Employee.GetEmployeesArray().ToDictionary(key => key.Id);

	        Employee e = eDictionary[2];
	        Console.WriteLine($"Employee whose id == 2 is {e.FirstName} {e.SecondName}"); 
        }

        private static void UseToDictionarySecond()
        {
	        Dictionary<string, Employee2> eDictionary =
		        Employee2.GetEmployeesArray().ToDictionary(key => key.Id, new StringifiedNumberComparer());

	        Employee2 e = eDictionary["2"];
	        Console.WriteLine($"Employee whose id == 2 is {e.FirstName} {e.SecondName}");

			if (eDictionary.ContainsKey("0002"))
			{
				e = eDictionary["0002"];
				Console.WriteLine($"Employee whose id == 2 is {e.FirstName} {e.SecondName}");
			}
        }

        private static void UseToDictionaryThird()
        {
	        Dictionary<string, string> eDictionary =
		        Employee2.GetEmployeesArray()
			        .ToDictionary(key => key.Id, value => $"{value.FirstName} {value.SecondName}");

	        string e = eDictionary["2"];
	        Console.WriteLine($"Employee whose id == 2 is {e}");

	        if (eDictionary.ContainsKey("0002"))
	        {
		        e = eDictionary["0002"];
		        Console.WriteLine($"Employee whose id == 2 is {e}");
	        }
        }

        private static void UseToDictionaryFourth()
        {
	        Dictionary<string, string> eDictionary =
		        Employee2.GetEmployeesArray()
			        .ToDictionary(
				        key => key.Id,
				        value => $"{value.FirstName} {value.SecondName}",
				        new StringifiedNumberComparer());

	        string e = eDictionary["2"];
	        Console.WriteLine($"Employee whose id == 2 is {e}");

	        if (eDictionary.ContainsKey("0002"))
	        {
		        e = eDictionary["0002"];
		        Console.WriteLine($"Employee whose id == 2 is {e}");
	        }
        }

		#endregion
	}
}
