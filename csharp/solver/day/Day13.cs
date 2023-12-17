using System.Diagnostics;
using AocUtils;


public static class Day13
{

	public static Stopwatch stopwatch = new Stopwatch();

	public static int Part1(string input)
	{
		var patterns = input.Split("\n\n").Select(ParsePattern).ToArray();

		var answer = 0;
		foreach (var (horizontalPattern, verticalPattern) in patterns)
		{
			var verticalLines = FindMirrorLine(horizontalPattern, verticalPattern.Length).ToArray();
			var horizontalLines = FindMirrorLine(verticalPattern, horizontalPattern.Length).ToArray();

			foreach (var lines in verticalLines)
				answer += lines;

			foreach (var col in horizontalLines)
				answer += 100 * col;

			var verticalLinesToString = string.Join(", ", verticalLines.Select(x => x.ToString()).ToArray());
			var horizontalLinesToString = string.Join(", ", horizontalLines.Select(x => x.ToString()).ToArray());
			Console.WriteLine($"verticalLines: {verticalLinesToString}, horizontalLines: {horizontalLinesToString}");
		}

		Console.WriteLine($"stopwatch: {stopwatch.ElapsedMilliseconds}ms");
		return answer;
	}

	private static IEnumerable<int> FindMirrorLine(int[] pattern, int length)
	{
		for (int i = 1; i < length; i++)
		{
			if (Enumerable.Range(0, pattern.Length).All(j => Mirrors(pattern[j], i, length)))
				yield return i;
		}

	}

	private static IEnumerable<int> FindMirrorLine(List<int> pattern, int length)
	{
		for (int i = 1; i < length; i++)
		{
			if (Enumerable.Range(0, pattern.Count).All(j => Mirrors(pattern[j], i, length)))
				yield return i;
		}

	}

	private static bool Mirrors(int line, int mirrorPoint, int totalLength)
	{
		var left = 0;
		var right = 0;

		//	><
		//110100101
		if (mirrorPoint < totalLength / 2f)
		{
			// ><  
			//.##..
			//#.#.#
			//#..#.
			left = line >> (totalLength - mirrorPoint);
			right = BitFlip(line >> (totalLength - 2 * mirrorPoint) & ((1 << mirrorPoint) - 1), mirrorPoint);
		}
		else if (mirrorPoint == totalLength / 2f)
		{
			// >< 
			//.##.
			//#.#.
			//#..#
			left = line >> mirrorPoint;
			right = BitFlip(line & ((1 << mirrorPoint) - 1), mirrorPoint);
		}
		else
		{
			//  ><  
			//.##..
			//#.#.#
			//#..#.
			var bitmask = (1 << (totalLength - mirrorPoint)) - 1;
			left = line >> (totalLength - mirrorPoint) & bitmask;
			right = BitFlip(line & bitmask, totalLength - mirrorPoint);
		}
		return left == right;
	}

	//##....
	// ......
	// ...##.

	private static int BitFlip(int value, int flippingSize)
	{
		if (flippingSize == 1)
			return value;

		var flipped = 0;
		for (int j = 0; j < flippingSize; j++)
		{
			if ((value & (1 << j)) != 0)
			{
				flipped |= 1 << (flippingSize - 1 - j);
			}
		}
		return flipped;
	}

	public static int Part2(string input)
	{
		var patterns = input.Split("\n\n").Select(ParsePattern).ToArray();

		var answer = 0;
		foreach (var (horizontalPattern, verticalPattern) in patterns)
		{
			var verticalLines = FindMirrorLine(horizontalPattern, verticalPattern.Length).ToArray();
			var horizontalLines = FindMirrorLine(verticalPattern, horizontalPattern.Length).ToArray();

			var horizontalPatternAsList = horizontalPattern.ToList();
			var verticalPatternAsList = verticalPattern.ToList();
			// var allVerticalLinesSmudgeVariation = Smudgify(horizontalPatternAsList, verticalPattern.Length);

			foreach (var smudgeStep in Smudgify(horizontalPatternAsList, verticalPattern.Length))
			{
				var verticalLinesWithSmudge = FindMirrorLine(horizontalPatternAsList.ToArray(), verticalPattern.Length).ToArray();
				var distinct = HasNewReflection(verticalLinesWithSmudge, verticalLines);
				Console.WriteLine($"verticalLinesWithSmudge: {smudgeStep} - {string.Join(", ", verticalLinesWithSmudge.Select(x => x.ToString()).ToArray())} - distinct:{distinct}");
			}

			foreach (var smudgeStep in Smudgify(verticalPatternAsList, horizontalPattern.Length))
			{
				var horizontalLinesWithSmudge = FindMirrorLine(verticalPatternAsList.ToArray(), horizontalPattern.Length).ToArray();
				var distinct = HasNewReflection(horizontalLinesWithSmudge, horizontalLines);
				Console.WriteLine($"horizontalLinesWithSmudge: {smudgeStep} - {string.Join(", ", horizontalLinesWithSmudge.Select(x => x.ToString()).ToArray())} - distinct:{distinct}");
			}

			// foreach (var lines in verticalLines)
			// 	answer += lines;

			// foreach (var col in horizontalLines)
			// 	answer += 100 * col;

			var verticalLinesToString = string.Join(", ", verticalLines.Select(x => x.ToString()).ToArray());
			var horizontalLinesToString = string.Join(", ", horizontalLines.Select(x => x.ToString()).ToArray());
			Console.WriteLine($"verticalLines: {verticalLinesToString}, horizontalLines: {horizontalLinesToString}");
		}

		Console.WriteLine($"stopwatch: {stopwatch.ElapsedMilliseconds}ms");
		return answer;
	}

	private static bool HasNewReflection(int[] verticalLinesWithSmudge, int[] verticalLines)
	{
		foreach (var line in verticalLinesWithSmudge)
		{
			if (!verticalLines.Contains(line))
				return true;
		}
		return false;
	}

	private static IEnumerable<(int, int)> Smudgify(List<int> pattern, int length)
	{
		for (int i = 0; i < pattern.Count; i++)
		{
			for (int j = 0; j < length; j++)
			{
				var beforeSmudged = pattern[i];
				var smudged = pattern[i] ^ (1 << j);
				pattern[i] = smudged;
				yield return (i, j);
				pattern[i] = beforeSmudged;
			}
		}
	}

	/*
	#.##..##.
	..#.##.#.
	##......#
	##......#
	..#.##.#.
	..##..##.
	#.#.##.#.
	*/
	public static (int[] HorizontalPattern, int[] VerticalPattern) ParsePattern(string input)
	{
		var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
		var horizontalPattern = new int[lines.Length];
		var verticalPattern = new int[lines[0].Length];
		for (int y = 0; y < lines.Length; y++)
		{
			for (int x = 0; x < lines[y].Length; x++)
			{
				if (lines[y][x] == '#')
				{
					horizontalPattern[y] |= 1 << (lines[y].Length - x - 1);
					verticalPattern[x] |= 1 << (lines.Length - y - 1);
				}
			}
		}
		return (horizontalPattern, verticalPattern);
	}
}