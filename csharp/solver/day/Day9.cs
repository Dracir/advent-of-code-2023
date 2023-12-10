using AocUtils;


public static class Day9
{
	public static long Part1(string input)
	{
		var awesome = 0L;
		var histories = input.Split("\n").Select(x => x.ParseListOfLong());
		foreach (var reading in histories)
		{
			var differences = new List<long[]> { reading };
			var prediction = reading.Last();
			for (int i = reading.Length - 1; i >= 0; i--)
			{
				var diff = new long[i];
				var allZeros = true;
				for (int j = 0; j < i; j++)
				{
					diff[j] = differences.Last()[j + 1] - differences.Last()[j];
					if (diff[j] != 0) allZeros = false;
				}
				prediction += diff[i - 1];
				differences.Add(diff);
				if (allZeros) break;
			}
			awesome += prediction;
		}
		return awesome;
	}

	public static long Part2(string input)
	{
		var awesome = 0L;
		var histories = input.Split("\n").Select(x => x.ParseListOfLong());
		foreach (var reading in histories)
		{
			var differences = new List<long[]> { reading };
			for (int i = reading.Length - 1; i >= 0; i--)
			{
				var diff = new long[i];
				var allZeros = true;
				for (int j = 0; j < i; j++)
				{
					diff[j] = differences.Last()[j + 1] - differences.Last()[j];
					if (diff[j] != 0) allZeros = false;
				}
				differences.Add(diff);
				if (allZeros) break;
			}

			var prediction = 0L;
			for (int i = differences.Count - 2; i >= 0; i--)
			{
				prediction = differences[i][0] - prediction;
			}
			awesome += prediction;
		}
		return awesome;
	}
}