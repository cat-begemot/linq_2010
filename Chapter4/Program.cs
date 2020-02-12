using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chapter1;

namespace Chapter4
{
    class FounderNumberComparer : IEqualityComparer<int>
	{
		public bool Equals(int x, int y)
		{
			return IsFounder(x) == IsFounder(y);
		}

		public int GetHashCode(int i)
		{
			int founder = 1;
			int nonFounder = 100;

			return IsFounder(i) ? founder.GetHashCode() : nonFounder.GetHashCode();
		}

		public bool IsFounder(int Id) => Id < 100;
	}
	
	class Program
    {
	    private static string[] presIdents =
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
	        UseDefaultIfEmpty();
        }

        private static void Samples()
		{
			var employees = Employee.GetEmployeesArray();
			var empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

			var employeeOptions = empOptions
				.Join(employees,
					e => e.Id,
					o => o.Id,
					(e, o) => new
					{
						Id = e.Id,
						Name = string.Format($"{o.FirstName} {o.SecondName}"),
						Options = e.OptionsCount
					});

			foreach (var item in employeeOptions)
				Console.WriteLine(item);
		}

        private static void UseDefaultIfEmpty()
        {
	        ArrayList employeesAL = Employee.GetEmployeesArrayList();
	        employeesAL.Add(new Employee()
		        {Id = 102, FirstName = "Michael", SecondName = "Bolton"});

	        var employees = employeesAL.Cast<Employee>().ToArray();
	        var employeesOpt = EmployeeOptionEntry.GetEmployeeOptionEntries();

	        var employeeOptions = employees
		        .GroupJoin(
			        employeesOpt,
			        e => e.Id,
			        o => o.Id,
			        (e, os) => os.DefaultIfEmpty().Select(o => new
			        {
				        Id = e.Id,
				        Name = $"{e.FirstName} {e.SecondName}",
				        Options = o != null ? o.OptionsCount : 0
			        }))
		        .SelectMany(r => r);

			foreach(var item in employeeOptions)
				Console.WriteLine(item);
        }

        #region Conversion

        private static void UseOfType()
        {
	        ArrayList al = new ArrayList();
	        al.Add(new Employee { Id = 1, FirstName = "Joe", SecondName = "Rattz" });
	        al.Add(new Employee { Id = 2, FirstName = "William", SecondName = "Gates" });
	        al.Add(new EmployeeOptionEntry { Id = 1, OptionsCount = 0 });
	        al.Add(new EmployeeOptionEntry { Id = 2, OptionsCount = 99999999999 });
	        al.Add(new Employee { Id = 3, FirstName = "Anders", SecondName = "Hejlsberg" });
	        al.Add(new EmployeeOptionEntry { Id = 3, OptionsCount = 848475745 });

	        var items = al.Cast<Employee>();
	        Console.WriteLine("Attempting to use Cast() method...");
	        try
	        {
				foreach(var emp in items)
					Console.WriteLine($"{emp.FirstName} {emp.SecondName}");
			}
	        catch (Exception ex)
	        {
		        Console.WriteLine($"{ex.Message}{System.Environment.NewLine}");
	        }

	        var items2 = al.OfType<Employee>();
	        Console.WriteLine("Attempting to use OfType() method...");
	        foreach (var emp in items2)
		        Console.WriteLine($"{emp.FirstName} {emp.SecondName}");
		}

        private static void UseCast()
        {
	        ArrayList employees = Employee.GetEmployeesArrayList();
	        Console.WriteLine($"The data type of employees is {employees.GetType()}");

	        var seq = employees.Cast<Employee>();
	        Console.WriteLine($"The data type of seq is {seq.GetType()}");

	        var emps = seq.OrderBy(e => e.SecondName);

			foreach(Employee emp in emps)
				Console.WriteLine($"{emp.FirstName} {emp.SecondName}");
        }

        #endregion


		#region Set

		private static void UseUnion()
        {
	        IEnumerable<string> first = presIdents.Take(4);
	        IEnumerable<string> second = presIdents.Skip(2).Take(4);
	        IEnumerable<string> concat = first.Concat(second);
	        IEnumerable<string> union = first.Union(second);
	        IEnumerable<string> intersect = first.Intersect(second);

	        Console.WriteLine($"presIdent {presIdents.Count()}");
	        Console.WriteLine($"first {first.Count()}");
	        Console.WriteLine($"second {second.Count()}");
	        Console.WriteLine($"concat {concat.Count()}");
	        Console.WriteLine($"union {union.Count()}");
	        Console.WriteLine($"intersect {intersect.Count()}");

			foreach(string item in union)
				Console.WriteLine(item);
        }

        private static void UseDistinct()
		{
			Console.WriteLine($"Initial presIdents count: {presIdents.Count()}");

			IEnumerable<string> doublePresIdents = presIdents.Concat(presIdents);
			Console.WriteLine($"Double presIdents count: {doublePresIdents.Count()}");

			IEnumerable<string> backPresIdents = doublePresIdents.Distinct();
			Console.WriteLine($"Back presIdents count: {backPresIdents.Count()}");

			//			foreach(var item in doublePresIdents)
			//				Console.WriteLine(item);
		}

        #endregion

        #region Grouping

        private static void UsingGroupingThird()
        {
	        var empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
	        var outerSequence =
		        empOptions
			        .GroupBy(emp => emp.Id, src => new {Id = src.Id, Count = src.OptionsCount}, new FounderNumberComparer());

	        foreach (var keyGroup in outerSequence)
	        {
		        Console.WriteLine($"Options records for employee {keyGroup.Key}");

		        foreach (var item in keyGroup)
			        Console.WriteLine(item);
	        }
        }

		private static void UsingGroupingSecond()
        {
			var comparer = new FounderNumberComparer();
			var empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
			IEnumerable<IGrouping<int, EmployeeOptionEntry>> optionsDistribution =
				empOptions.GroupBy(o => o.Id, comparer);

			foreach (IGrouping<int, EmployeeOptionEntry> keyGroup in optionsDistribution)
			{
				Console.WriteLine($"Option record for: {(comparer.IsFounder(keyGroup.Key) ? "Founders" : "Non founders")}");

				foreach(EmployeeOptionEntry item in keyGroup)
					Console.WriteLine($"\t--> Id: {item.Id}, Count: {item.OptionsCount}, Date: {item.DateAwarded}");
			}
		}


		private static void UsingGroupingFirst()
        {
	        var empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
	        IEnumerable<IGrouping<int, EmployeeOptionEntry>> outerSequence = empOptions.GroupBy(emp => emp.Id);

	        foreach (var keyGroup in outerSequence)
	        {
		        Console.WriteLine($"Options records for employee {keyGroup.Key}");

				foreach(var item in keyGroup)
					Console.WriteLine($"\t--> Id: {item.Id}, Count: {item.OptionsCount}, Date: {item.DateAwarded}");
	        }
        }

		#endregion

		private static void WorkingWithGroupJoin()
		{
			var employees = Employee.GetEmployeesArray();
			var empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

			var employeeOptions = employees
				.GroupJoin(empOptions, e => e.Id, o => o.Id,
					(e, os) => new
					{
						Id = e.Id,
						Name = string.Format($"{e.FirstName} {e.SecondName}"),
						Options = os.Sum(item => item.OptionsCount)
					});

			foreach(var item in employeeOptions)
				Console.WriteLine(item);
		}

        private static void WorkingWithJoin()
        {
	        var employees = Employee.GetEmployeesArray();
	        var empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

	        var employeeOptions = employees
		        .Join(empOptions,
			        e => e.Id,
			        o => o.Id,
			        (e, o) => new
			        {
				        Id = e.Id,
				        Name = string.Format($"{e.FirstName} {e.SecondName}"),
				        Options = o.OptionsCount
			        });

			foreach(var item in employeeOptions)
				Console.WriteLine(item);
        }

        private static void SortWithVowelConsonantRatioComparer()
        {
	        IOrderedEnumerable<string> namesByRatio = presIdents
		        .OrderBy(p => p, new VowelToConsonantRatioComparer())
		        .ThenByDescending(p => p);

			foreach(var presIdent in namesByRatio)
			{
				double vCount = 0;
				double cCount = 0;

				VowelToConsonantRatioComparer.GetVowelConsonantCount(presIdent, ref vCount, ref cCount);
				var ratio = Math.Round((double)(cCount != 0 ? vCount / cCount : 0), 5);

				Console.WriteLine($"{presIdent} - {ratio} - {vCount}:{cCount}");
			}
        }

        private static void SelectManyPrototype()
        {
	        var employees = Employee.GetEmployeesArray();
	        var empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();

	        var employeeOptions = employees
			        .SelectMany(e => empOptions
					        .Where(eo => eo.Id == e.Id)
					        .Select(eo => new {Id = eo.Id, OptionsCount = eo.OptionsCount}));

			foreach(var item in employeeOptions)
				Console.WriteLine(item);
        }
    }
}
