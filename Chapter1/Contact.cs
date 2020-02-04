using System;

namespace Chapter1
{
	public class Contact
	{
		public int Id;
		public string Name;

		public static void PublishContact(Contact[] contacts)
		{
			foreach(var contact in contacts)
				Console.WriteLine($"Contact Id: {contact.Id}, Name: {contact.Name}");
		}
	}
}