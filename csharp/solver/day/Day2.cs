

public static class Day2
{
	public static ulong Part1(string input)
	{
		return (ulong)input.Split("\n")
			.Select(ParseLine)
			.Select(ReturnIdIfValid)
			.Sum();
	}

	public static int ReturnIdIfValid((int GameId, List<(int Red, int Green, int Blue)> Draws) game)
	{
		var validGame = true;
		foreach (var item in game.Draws)
		{
			if (item.Red > 12)
				validGame = false;
			if (item.Green > 13)
				validGame = false;
			if (item.Blue > 14)
				validGame = false;
		}

		if (validGame)
			return game.GameId;
		else
			return 0;
	}


	public static ulong Part2(string input)
	{
		return (ulong)input.Split("\n")
			.Select(ParseLine)
			.Select(x => GiveMeBig(x.Draws))
			.Select(x => (int)x.Item1 * (int)x.Item2 * (int)x.Item3)
			.Sum();
	}

	public static (int, int, int) GiveMeBig(List<(int Red, int Green, int Blue)> draws)
	{
		var maxRed = draws.Max(x => x.Red);
		var maxGreen = draws.Max(x => x.Green);
		var maxBlue = draws.Max(x => x.Blue);

		return (maxRed, maxGreen, maxBlue);
	}

	private static (int GameId, List<(int Red, int Green, int Blue)> Draws) ParseLine(string input)
	{
		var splitted = input.Split(":");

		var gameId = int.Parse(splitted[0].Split(" ")[1]);

		var gameValues = new List<(int Red, int Green, int Blue)>();
		foreach (var draw in splitted[1].Split(";"))
		{
			var red = 0;
			var green = 0;
			var blue = 0;
			var drawCubes = draw.Split(",").Select(x => x.Trim());

			foreach (var cube in drawCubes)
			{
				var moreSplit = cube.Split(" ");
				var color = moreSplit[1];
				if (moreSplit[1] == "red")
					red += int.Parse(moreSplit[0]);
				else if (moreSplit[1] == "green")
					green += int.Parse(moreSplit[0]);
				else if (moreSplit[1] == "blue")
					blue += int.Parse(moreSplit[0]);
			}

			gameValues.Add((red, green, blue));
		}

		return (gameId, gameValues);
	}
}