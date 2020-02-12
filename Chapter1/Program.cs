using System;
using System.Collections;
using System.Linq;

namespace Chapter1
{
	class Program
    {
        static void Main(string[] args)
        {
	        UsingDataContextLog();
        }

        private static void UsingDataContextLog()
        {
			
        }

        private static void PrintContacts()
        {
	        var employees = Employee.GetEmployeesArrayList();
	        var contacts =
		        employees
			        .Cast<Employee>()
			        .Select(item => new Contact() {Id = item.Id, Name = $"{item.FirstName} {item.SecondName}"})
			        .ToArray<Contact>();

			Contact.PublishContact(contacts);
        }

        private static void ConvertResult()
        {
	        var numbers = new[] {"0042", "010", "9", "27"};

	        var nums =
		        numbers
			        .Select(num => Int32.Parse(num))
			        .OrderBy(num => num)
			        .ToArray();

            foreach(var num in nums)
	            Console.WriteLine(num);
        }
    }
}
