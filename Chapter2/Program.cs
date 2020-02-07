using System;
using System.Collections;

namespace Chapter2
{
	public class Common
	{
		public delegate bool IntFilter(int number);

		public static int[] FilterArrayOfInts(int[] ints, IntFilter filter)
		{
			var result = new ArrayList();

			foreach(var i in ints)
				if (filter(i))
					result.Add(i);

			return (int[])result.ToArray(typeof(int));
		}
	}
	
	class Program
    {
        static void Main(string[] args)
        {
	        UsingAnonymousMethod();
        }

        private static void UsingAnonymousMethod()
        {
	        var nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
	        var oddNums = Common.FilterArrayOfInts(nums, delegate(int i) { return ((i & 1) == 1);});

	        foreach (var oddNum in oddNums)
		        Console.WriteLine(oddNum);
        }

		private static void UsingNamedMethod()
		{
			var nums = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
			var oddNums = Common.FilterArrayOfInts(nums, IsOdd);

			foreach(var oddNum in oddNums)
				Console.WriteLine(oddNum);
		}

        private static bool IsOdd(int i) =>
	        (i & 1) == 1;
    }
}
