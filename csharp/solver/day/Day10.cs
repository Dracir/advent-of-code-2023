using AocUtils;


public static class Day10
{


	public static int Part1(string input)
	{
		var grid = ParseGrid(input);

		// GridScene<GridConnections>.PreviewGrid(grid.Grid, GridConnectionsUtils.ConnectionToChar,
		//  (connection, point) => ConnectionToColor(connection, point, grid),
		//  new Point2Int(0, 0)
		//  );

		var position = grid.StartingPosition;
		var directions = GridConnectionsUtils.ConnectionToDirections(grid.Grid[position]);
		var currentDirection = directions[0];

		var steps = 0;

		var inifgnintiniProjtectionThingy = 100000;
		while (inifgnintiniProjtectionThingy-- > 0)
		{
			var currentConnection = grid.Grid[position];

			var exitDirection = currentConnection.EnterFrom(currentDirection);
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

	private static ConsoleColor ConnectionToColor(GridConnections connections, Vector2Int position, Grid<GridConnections> grid, Vector2Int startingPosition)
	{
		if (position == startingPosition)
			return ConsoleColor.Red;
		if (connections == GridConnections.None)
			return ConsoleColor.Blue;

		return ConsoleColor.White;
	}

	private static ConsoleColor ConnectionToColor(GridConnections connections, Vector2Int position, Grid<GridConnections> grid, Grid<bool?> enclosedGrid)
	{
		if (connections == GridConnections.None)
		{
			if (enclosedGrid[position] == null)
				return ConsoleColor.Red;
			else if (enclosedGrid[position] == true)
				return ConsoleColor.Blue;
			else if (enclosedGrid[position] == false)
				return ConsoleColor.Yellow;
		}

		return ConsoleColor.White;
	}

	private static (Grid<GridConnections> Grid, Vector2Int StartingPosition) ParseGrid(string input)
	{
		var values = input.ParseListOfString('\n');
		var grid = new Grid<GridConnections>(GridConnections.None, values[0].Length, values.Length);
		Vector2Int startingPosition = new Vector2Int(0, 0);
		for (int y = 0; y < values.Length; y++)
		{
			for (int x = 0; x < values[y].Length; x++)
			{
				if (values[y][x] == 'S')
					startingPosition = new Vector2Int(x, values.Length - y - 1);
				else
					grid[x, values.Length - y - 1] = CharToStarDirection(values[y][x]);
			}
		}

		var entryFromNorth = false;
		var entryFromEast = false;
		var entryFromSouth = false;
		var entryFromWest = false;

		if (grid.TryGet(startingPosition + Vector2Int.UpDirection, out var northNeighbor))
			entryFromNorth = northNeighbor.GoesSouth();
		if (grid.TryGet(startingPosition + Vector2Int.RightDirection, out var eastNeighbor))
			entryFromEast = eastNeighbor.GoesWest();
		if (grid.TryGet(startingPosition + Vector2Int.DownDirection, out var southNeighbor))
			entryFromSouth = southNeighbor.GoesNorth();
		if (grid.TryGet(startingPosition + Vector2Int.LeftDirection, out var westNeighbor))
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

	public static int Part2(string input)
	{
		var (grid, startingPosition) = ParseGrid(input);

		var position = startingPosition;
		var directions = GridConnectionsUtils.ConnectionToDirections(grid[position]);
		var currentDirection = directions[0];

		var steps = 0;

		var inifgnintiniProjtectionThingy = 100000;
		var pointInPath = new List<Vector2Int>();
		pointInPath.Add(position);

		while (inifgnintiniProjtectionThingy-- > 0)
		{
			var currentConnection = grid[position];

			var exitDirection = currentConnection.EnterFrom(currentDirection);
			if (exitDirection == null)
				return -1;

			position += exitDirection.Value.ToPoint();
			pointInPath.Add(position);

			currentDirection = exitDirection.Value.Fliped();
			steps++;

			if (position == startingPosition)
				break;
		}

		foreach (var pt in grid.Points())
		{
			if (pointInPath.Contains(pt))
				continue;

			grid[pt] = GridConnections.None;
		}

		// GridScene<GridConnections>.PreviewGrid(grid, GridConnectionsUtils.ConnectionToChar,
		//  	(connection, point) => ConnectionToColor(connection, point, grid, startingPosition),
		//  	new Point2Int(0, 0)
		//  );

		var zoomedInGrid = new Grid<GridConnections>(GridConnections.None, grid.UsedWidth * 2, grid.UsedHeight * 2);
		var enclosedGrid = new Grid<bool?>(null, grid.UsedWidth * 2, grid.UsedHeight * 2);
		foreach (var pt in grid.Points())
		{
			zoomedInGrid[pt * 2] = grid[pt];
			if (grid[pt] != GridConnections.None)
				enclosedGrid[pt * 2] = false;
			var rightPt = pt.Right;
			if (grid.TryGet(rightPt, out var rightConnection) && grid[pt].GoesEast() && rightConnection.GoesWest())
			{
				zoomedInGrid[pt * 2 + Vector2Int.RightDirection] = GridConnections.Horizontal;
				enclosedGrid[pt * 2 + Vector2Int.RightDirection] = false;
			}

			var upPt = pt.Up;
			if (grid.TryGet(upPt, out var upConnection) && grid[pt].GoesNorth() && upConnection.GoesSouth())
			{
				zoomedInGrid[pt * 2 + Vector2Int.UpDirection] = GridConnections.Vertical;
				enclosedGrid[pt * 2 + Vector2Int.UpDirection] = false;
			}
		}

		foreach (var pointsOnBorder in zoomedInGrid.PointsOnBorder())
		{
			if (zoomedInGrid[pointsOnBorder] == GridConnections.None)
				enclosedGrid[pointsOnBorder] = true;
		}

		Propagation2(zoomedInGrid, enclosedGrid);

		// GridScene<GridConnections>.PreviewGrid(zoomedInGrid, GridConnectionsUtils.ConnectionToChar,
		// 	 (connection, point) => ConnectionToColor(connection, point, zoomedInGrid, enclosedGrid),
		// 	 new Point2Int(0, 0)
		//  );

		var evenDotThatAreRed = zoomedInGrid.PointsAndValues()
			.Where(pt => pt.Value == GridConnections.None && enclosedGrid[pt.Point] == null)
			.Where(pt => pt.Point.X % 2 == 0 && pt.Point.Y % 2 == 0)
			.Count();

		return evenDotThatAreRed;
	}

	private static void Propagation2(Grid<GridConnections> zoomedInGrid, Grid<bool?> enclosedGrid)
	{
		var toVisit = zoomedInGrid.PointsOnBorder().ToList();
		var visitedList = new List<Vector2Int>();
		while (toVisit.Count != 0)
		{
			var pt = toVisit[0];
			toVisit.RemoveAt(0);

			visitedList.Add(pt);

			if (enclosedGrid.PointInBound(pt.Right) && enclosedGrid[pt.Right] != null && zoomedInGrid[pt.Right] == GridConnections.None)
				enclosedGrid[pt] = enclosedGrid[pt.Right];
			else if (enclosedGrid.PointInBound(pt.Up) && enclosedGrid[pt.Up] != null && zoomedInGrid[pt.Up] == GridConnections.None)
				enclosedGrid[pt] = enclosedGrid[pt.Up];
			else if (enclosedGrid.PointInBound(pt.Left) && enclosedGrid[pt.Left] != null && zoomedInGrid[pt.Left] == GridConnections.None)
				enclosedGrid[pt] = enclosedGrid[pt.Left];
			else if (enclosedGrid.PointInBound(pt.Down) && enclosedGrid[pt.Down] != null && zoomedInGrid[pt.Down] == GridConnections.None)
				enclosedGrid[pt] = enclosedGrid[pt.Down];

			AddIfUsefull(pt.Right, toVisit, visitedList, zoomedInGrid, enclosedGrid);
			AddIfUsefull(pt.Up, toVisit, visitedList, zoomedInGrid, enclosedGrid);
			AddIfUsefull(pt.Left, toVisit, visitedList, zoomedInGrid, enclosedGrid);
			AddIfUsefull(pt.Down, toVisit, visitedList, zoomedInGrid, enclosedGrid);
		}
	}

	private static void AddIfUsefull(Vector2Int pt, List<Vector2Int> toVisit, List<Vector2Int> visitedList, Grid<GridConnections> zoomedInGrid, Grid<bool?> enclosedGrid)
	{
		if (!zoomedInGrid.PointInBound(pt) || enclosedGrid[pt] != null)
			return;
		if (zoomedInGrid[pt] != GridConnections.None)
			return;
		if (toVisit.Contains(pt))
			return;
		if (visitedList.Contains(pt))
			return;
		toVisit.Add(pt);
	}
}