using AocUtils;


public static class Day10
{
	public static int Part1(string input)
	{
		var grid = ParseGrid(input);

		var position = grid.StartingPosition;
		var directions = GridConnectionsUtils.ConnectionToDirections(grid.Grid[position]);
		var currentDirection = directions[0];

		var steps = 0;

		var inifgnintiniProjtectionThingy = 100000;
		while (inifgnintiniProjtectionThingy-- > 0)
		{
			var currentConnection = grid.Grid[position];

			var exitDirection = currentConnection.GetExitDirection(currentDirection);
			if (exitDirection == null)
				return steps / 2;

			position += exitDirection.Value.ToPoint();
			currentDirection = exitDirection.Value.Fliped();
			steps++;

			if (position == grid.StartingPosition)
				return steps / 2;
		}


		return steps / 2;
	}

	private static (Grid<GridConnections> Grid, Point2Int StartingPosition) ParseGrid(string input)
	{
		var values = input.ParseListOfString('\n');
		var grid = new Grid<GridConnections>(GridConnections.None, values[0].Length, values.Length);
		Point2Int startingPosition = new Point2Int(0, 0);
		for (int y = 0; y < values.Length; y++)
		{
			for (int x = 0; x < values[y].Length; x++)
			{
				if (values[y][x] == 'S')
					startingPosition = new Point2Int(x, values.Length - y - 1);
				else
					grid[x, values.Length - y - 1] = CharToStarDirection(values[y][x]);
			}
		}

		var entryFromNorth = false;
		var entryFromEast = false;
		var entryFromSouth = false;
		var entryFromWest = false;

		if (grid.TryGet(startingPosition + Point2Int.UpDirection, out var northNeighbor))
			entryFromNorth = northNeighbor.GoesSouth();
		if (grid.TryGet(startingPosition + Point2Int.RightDirection, out var eastNeighbor))
			entryFromEast = eastNeighbor.GoesWest();
		if (grid.TryGet(startingPosition + Point2Int.DownDirection, out var southNeighbor))
			entryFromSouth = southNeighbor.GoesNorth();
		if (grid.TryGet(startingPosition + Point2Int.LeftDirection, out var westNeighbor))
			entryFromWest = westNeighbor.GoesEast();

		grid[startingPosition] = GridConnectionsUtils.GetConnectionFor(entryFromNorth, entryFromEast, entryFromSouth, entryFromWest);

		return (grid, startingPosition);
	}


	private static GridConnections CharToStarDirection(char character) => character switch
	{
		'.' => GridConnections.None,
		'-' => GridConnections.Horizontal,
		'|' => GridConnections.Vertical,
		'L' => GridConnections.NorthToEast,
		'F' => GridConnections.EastToSouth,
		'7' => GridConnections.SouthToWest,
		'J' => GridConnections.WestToNorth,
		_ => throw new Exception($"Unknown character {character}")
	};

	public static ulong Part2(string input)
	{
		return 0ul;
	}
}