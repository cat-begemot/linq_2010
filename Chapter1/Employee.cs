﻿using System.Collections;
using System.Linq;
using System.Net.Http.Headers;

namespace Chapter1
{
	public class Employee
	{
		public int Id;
		public string FirstName;
		public string SecondName;

		public static ArrayList GetEmployeesArrayList()
		{
			var employees = new ArrayList();

			employees.Add(new Employee() { Id = 1, FirstName = "Joe", SecondName = "Rattz" });
			employees.Add(new Employee() { Id = 2, FirstName = "William", SecondName = "Gats" });
			employees.Add(new Employee() { Id = 3, FirstName = "Anders", SecondName = "Hejlsberg" });
			employees.Add(new Employee() { Id = 4, FirstName = "David", SecondName = "Lightman" });
			employees.Add(new Employee() { Id = 101, FirstName = "Kevin", SecondName = "Flynn" });

			return employees;
		}

		public static Employee[] GetEmployeesArray()
		{
			var employees = GetEmployeesArrayList().ToArray();

			return employees.OfType<Employee>().ToArray();
		}
	}

	public class Employee2
	{
		public string Id;
		public string FirstName;
		public string SecondName;

		public static ArrayList GetEmployeesArrayList()
		{
			var employees = new ArrayList();

			employees.Add(new Employee2() { Id = "1", FirstName = "Joe", SecondName = "Rattz" });
			employees.Add(new Employee2() { Id = "2", FirstName = "William", SecondName = "Gates" });
			employees.Add(new Employee2() { Id = "3", FirstName = "Anders", SecondName = "Hejlsberg" });
			employees.Add(new Employee2() { Id = "4", FirstName = "David", SecondName = "Lightman" });
			employees.Add(new Employee2() { Id = "101", FirstName = "Kevin", SecondName = "Flynn" });

			return employees;
		}

		public static Employee2[] GetEmployeesArray()
		{
			var employees = GetEmployeesArrayList().ToArray();

			return employees.OfType<Employee2>().ToArray();
		}
	}
}