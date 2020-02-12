using System.Collections.Generic;

namespace Chapter1
{
	public class VowelToConsonantRatioComparer : IComparer<string>
	{
		public int Compare(string str1, string str2)
		{
			double vowelCount1 = 0;
			double consonantCount1 = 0;

			double vowelCount2 = 0;
			double consonantCount2 = 0;

			GetVowelConsonantCount(str1, ref vowelCount1, ref consonantCount1);
			GetVowelConsonantCount(str2, ref vowelCount2, ref consonantCount2);

			double ratio1 = vowelCount1 / consonantCount1;
			double ratio2 = vowelCount2 / consonantCount2;

			if (ratio1 < ratio2)
				return -1;
			else if (ratio1 > ratio2)
				return 1;
			else
				return 0;
		}

		public static void GetVowelConsonantCount(string str, ref double vowelCount, ref double consonantCount)
		{
			string vowels = "AEIOUY";

			vowelCount = 0;
			consonantCount = 0;

			string strUpper = str.ToUpper();

			foreach(char ch in strUpper)
				if (vowels.IndexOf(ch) < 0)
					consonantCount++;
				else
					vowelCount++;
		}
	}
}