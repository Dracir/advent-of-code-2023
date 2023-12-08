
public static class Day6
{

	public static ulong Part1(string input)
	{
		var races = ParseInput(input);

		var product = 1ul;

		foreach (var race in races)
		{
			var winning = 0ul;
			for (ulong i = 1; i < race.Time - 1; i++)
			{
				var distanceDone = (race.Time - i) * i;
				if (distanceDone > race.Distance)
					winning++;
			}
			product *= winning;
		}

		return product;
	}

	public static ulong Part2(string input)
	{
		var (time, distance) = ParseInput2(input);


		var winning = 0ul;
		for (ulong i = 1; i < time - 1; i++)
		{
			var distanceDone = (time - i) * i;
			if (distanceDone > distance)
				winning++;
		}
		return winning;
	}

	public static ulong Part2Take2(string input)
	{
		var (time, distance) = ParseInput2(input);

		var firstWinner = 0ul;
		var lastWinner = 0ul;

		for (ulong i = 1; i < time - 1; i++)
		{
			var distanceDone = (time - i) * i;
			if (distanceDone > distance)
			{
				firstWinner = i;
				break;
			}
		}

		for (ulong i = time - 1; i > 1; i--)
		{
			var distanceDone = (time - i) * i;
			if (distanceDone > distance)
			{
				lastWinner = i;
				break;
			}
		}
		return lastWinner - firstWinner + 1;
	}

	public static List<(ulong Time, ulong Distance)> ParseInput(string input)
	{
		var lines = input.Split("\n");

		var times = lines[0].Split(":", StringSplitOptions.TrimEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToArray();
		var distances = lines[1].Split(":", StringSplitOptions.TrimEntries)[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(ulong.Parse).ToArray();

		return times.Zip(distances).ToList();
	}

	public static (ulong Time, ulong Distance) ParseInput2(string input)
	{
		var lines = input.Split("\n");
		//7  15   30
		var times = lines[0].Split(":", StringSplitOptions.TrimEntries)[1].Replace(" ", "");
		var distances = lines[1].Split(":", StringSplitOptions.TrimEntries)[1].Replace(" ", "");

		return (ulong.Parse(times), ulong.Parse(distances));
	}
}