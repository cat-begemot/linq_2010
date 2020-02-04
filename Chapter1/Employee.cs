using System.Collections;
using System.Collections.Generic;

namespace Chapter1
{
	public class Employee
	{
		public int Id;
		public string FirstName;
		public string SecondName;

		public static ArrayList GetEmployees()
		{
			var employees = new ArrayList();

			employees.Add(new Employee() {Id=1, FirstName = "Joe", SecondName = "Rattz"});
			employees.Add(new Employee() {Id=2, FirstName = "William", SecondName = "Gats"});
			employees.Add(new Employee() {Id=3, FirstName = "Anders", SecondName = "Hejlsberg"});

			return employees;
		}
	}
}