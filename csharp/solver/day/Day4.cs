using System.Diagnostics;

public static class Day4
{
	public static ulong Part1(string input)
	{
		var totalScore = 0ul;
		foreach (var line in input.Split("\n"))
		{
			var (cardNumber, winners, mine) = ParseLine(line);
			var matching = winners.IntersectBy(mine, x => x).ToList();
			if (matching.Count == 0)
				continue;

			var score = 1;
			for (int i = 1; i < matching.Count; i++)
			{
				score *= 2;
			}
			totalScore += (ulong)score;

		}

		return totalScore;
	}

	private static (int CardNumber, List<int> Winners, List<int> Mine) ParseLine(string line)
	{
		var split = line.Split(":");
		var cardNumber = int.Parse(split[0].Split(" ").Last());

		var numbersSplit = split[1].Split("|");

		var winner = numbersSplit[0]
			.Split(" ")
			.Select(x => x.Trim())
			.Where(x => !string.IsNullOrWhiteSpace(x))
			.Select(int.Parse).ToList();

		var mine = numbersSplit[1]
			.Split(" ")
			.Select(x => x.Trim())
			.Where(x => !string.IsNullOrWhiteSpace(x))
			.Select(int.Parse).ToList();

		return (cardNumber, winner, mine);
	}

	public static ulong Part2(string input)
	{
		var numberOfScratchcards = Enumerable.Repeat(1, input.Split("\n").Length).ToArray();

		var splitedLines = input.Split("\n");
		for (int i = 0; i < splitedLines.Length; i++)
		{
			var (cardNumber, winners, mine) = ParseLine(splitedLines[i]);
			var matching = winners.IntersectBy(mine, x => x).ToList();
			if (matching.Count == 0)
				continue;

			for (int j = 1; j <= matching.Count; j++)
				for (int k = 0; k < numberOfScratchcards[i]; k++)
					numberOfScratchcards[i + j]++;
		}

		return (ulong)numberOfScratchcards.Sum();
	}
}