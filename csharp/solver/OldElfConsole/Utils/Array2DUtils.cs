using System;
using System.Collections.Generic;
using System.Linq;

namespace AocUtils;

public static class Array2DUtils
{
	public static IEnumerable<Vector2Int> Range2D(int length0, int length1)
	{
		for (int i = 0; i < length0; i++)
		{
			for (int j = 0; j < length1; j++)
			{
				yield return new Vector2Int(i, j);
			}
		}
	}
}