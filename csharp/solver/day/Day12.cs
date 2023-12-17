using AocUtils;

public static class Day12
{
	public static int Part1(string input)
	{
		var inputs = ParseInput(input);

		// var sum = GetArrangements(inputs[0].springCondition.AsSpan(), inputs[0].contiguousDamaged.AsSpan());
		var sum = 0;

		foreach (var (springCondition, contiguousDamaged) in inputs)
		{
			var arrangements = GetArrangements(springCondition, contiguousDamaged);
			sum += arrangements;
			// Console.WriteLine($"Arrangements: {arrangements}");
		}

		return sum;
	}

	public static int GetArrangements(Span<bool?> springCondition, Span<int> contiguousDamaged)
	{
		if (contiguousDamaged.Length == 0)
			return 1;
		else if (springCondition.Length == 0)
			return 0;

		var nextBrokenIndexStart = -1;
		var nextUnknownOrBrokenSpringIndexStart = -1;
		var nextUnknownOrBrokenSpringIndexEnd = -1;

		for (int i = 0; i < springCondition.Length; i++)
		{
			if (nextBrokenIndexStart == -1 && springCondition[i] == false)
				nextBrokenIndexStart = i;

			if (nextUnknownOrBrokenSpringIndexStart == -1)
			{
				if (springCondition[i] == null || springCondition[i] == false)
					nextUnknownOrBrokenSpringIndexStart = i;
			}
			else
			{
				if (springCondition[i] != null && springCondition[i] == true)
				{
					nextUnknownOrBrokenSpringIndexEnd = i - 1;
					break;
				}
			}
		}

		if (nextUnknownOrBrokenSpringIndexStart == -1)
			return 0;
		else if (nextUnknownOrBrokenSpringIndexEnd == -1)
			nextUnknownOrBrokenSpringIndexEnd = springCondition.Length - 1;

		var unknownLength = nextUnknownOrBrokenSpringIndexEnd - nextUnknownOrBrokenSpringIndexStart + 1;
		var damagedSize = contiguousDamaged[0];

		//???.###????  			damagedSize = 4, skip the first 3
		if (unknownLength < damagedSize) // Too small to fit the amount required by the contiguousDamaged
		{
			if (nextUnknownOrBrokenSpringIndexEnd + damagedSize >= springCondition.Length)
				return 0;
			else
				return GetArrangements(springCondition[(nextUnknownOrBrokenSpringIndexEnd + 1)..], contiguousDamaged);
		}
		else
		{
			//??? 1
			var sum = 0;
			var maxIndex = nextUnknownOrBrokenSpringIndexEnd - damagedSize + 1;
			if (nextBrokenIndexStart != -1)
				maxIndex = Math.Min(nextBrokenIndexStart, maxIndex);

			for (int i = nextUnknownOrBrokenSpringIndexStart; i <= maxIndex; i++)
			{
				if (i + damagedSize < springCondition.Length && springCondition[i + damagedSize] == false)
					continue;

				var nextIndex = i + damagedSize + 1;
				if (nextIndex >= springCondition.Length)
				{
					if (contiguousDamaged.Length == 1)
						sum++;
				}
				else
					sum += GetArrangements(springCondition[nextIndex..], contiguousDamaged[1..]);
			}
			return sum;
		}
	}

	public static ulong Part2(string input)
	{
		return 0ul;
	}

	public static List<(bool?[] springCondition, int[] contiguousDamaged)> ParseInput(string input)
	{
		return input.Split("\n").Select(ParseInputLine).ToList();
	}

	public static (bool?[] springCondition, int[] contiguousDamaged) ParseInputLine(string line)
	{
		var parts = line.Split(" ");
		var springCondition = parts[0].ParseListOfOptionalBool('.', '#');
		var contiguousDamaged = parts[1].ParseListOfInt(',');
		return (springCondition, contiguousDamaged);
	}
}