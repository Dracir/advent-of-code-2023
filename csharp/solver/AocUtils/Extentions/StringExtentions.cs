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

	public static bool[] ParseListOfBool(this string str, char trueValue = '#', char separator = ' ')
		=> str.Split(separator, StringSplitOptions.RemoveEmptyEntries)
		.Select(c => c[0] == trueValue).ToArray();

	public static int[] ParseListOfInt(this string str, char separator = ' ')
		=> str.Split(separator, StringSplitOptions.RemoveEmptyEntries)
		.Select(int.Parse).ToArray();

	public static string[] ParseListOfString(this string str, char separator = ' ')
		=> str.Split(separator, StringSplitOptions.RemoveEmptyEntries);

}
