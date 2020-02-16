using System.Collections.Generic;

namespace Chapter1
{
	public class StringifiedNumberComparer : IEqualityComparer<string>
	{
		public bool Equals(string x, string y)
		{
			if (!int.TryParse(x, out int parsedX) ||
			    !int.TryParse(y, out var parsedY))
			{
				return false;
			}

			return parsedX == parsedY;
		}

		// todo: check this
		public int GetHashCode(string obj)
		{
			if (!int.TryParse(obj, out var parsedObj))
				return 0;

			return parsedObj.ToString().GetHashCode();
		}
	}
}