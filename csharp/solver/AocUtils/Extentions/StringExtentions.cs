namespace AocUtils;

using System;

public static class StringExtentions
{

	public static long[] ParseListOfLong(this string str, char separator = ' ')
		=> str.Split(separator, StringSplitOptions.RemoveEmptyEntries)
		.Select(long.Parse).ToArray();

	public static ulong[] ParseListOfUlong(this string str, char separator = ' ')
		=> str.Split(separator, StringSplitOptions.RemoveEmptyEntries)
		.Select(ulong.Parse).ToArray();

	


}
