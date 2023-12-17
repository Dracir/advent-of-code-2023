using AocUtils;


public static class Day11
{
	public static ulong Part1(string input)
	{
		var grid = ParseGrid(input);

		// 	 (_, _) => ConsoleColor.White,
		// 	 new Point2Int(0, 0)
		//  );

		var emptyRows = grid.RowIndexs().Where(y => grid.Row(y).All(x => !x)).ToArray();
		var emptyCols = grid.ColIndexs().Where(x => grid.Col(x).All(y => !y)).ToArray();

		var expendedUniverse = new Grid<bool>(false, grid.FullWidth + emptyCols.Length * 2, grid.FullHeight + emptyRows.Length * 2);

		foreach (var oldGridPoint in grid.PointsAndValues())
		{
			if (!oldGridPoint.Value)
				continue;
			var x = oldGridPoint.Point.X + emptyCols.Where(col => col < oldGridPoint.Point.X).Count();
			var y = oldGridPoint.Point.Y + emptyRows.Where(row => row < oldGridPoint.Point.Y).Count();
			expendedUniverse[x, y] = true;
		}

		// GridScene<bool>.PreviewGrid(expendedUniverse, GetGridRenderingCharacter,
		// 	 (_, _) => ConsoleColor.White,
		// 	 new Point2Int(0, 0)
		//  );

		var galaxies = expendedUniverse.PointsAndValues().Where(x => x.Value).Select(x => x.Point).ToArray();

		return (ulong)galaxies.PairUpTriangleWithoutDiagonal()
			.Select(x => x.Item1.DistanceManhattan(x.Item2))
			.Sum();
	}

	private static char GetGridRenderingCharacter(bool arg) => arg ? '#' : '.';

	private static Grid<bool> ParseGrid(string input)
	{
		var gridAsBool = InputParser.ParseBool2DArray(input, '\n', '#', true);
		var grid = new Grid<bool>(false, new RangeInt(0, gridAsBool.GetLength(0) - 1), new RangeInt(0, gridAsBool.GetLength(1) - 1));
		grid.AddGrid(0, 0, gridAsBool, GridPlane.XY);
		return grid;
	}

	public static ulong Part2(string input)
	{
		var grid = ParseGrid(input);

		var emptyRows = grid.RowIndexs().Where(y => grid.Row(y).All(x => !x)).ToArray();
		var emptyCols = grid.ColIndexs().Where(x => grid.Col(x).All(y => !y)).ToArray();

		var galaxies = grid.PointsAndValues()
			.Where(x => x.Value)
			.Select(x => GetGalaxyExpendedPosition(x.Point, emptyRows, emptyCols))
			.ToArray();

		return (ulong)galaxies.PairUpTriangleWithoutDiagonal()
			.Select(x => x.Item1.DistanceManhattan(x.Item2))
			.Sum();
	}

	private static Vector2Long GetGalaxyExpendedPosition(Vector2Int point, int[] emptyRows, int[] emptyCols)
	{
		var x = point.X + emptyCols.Where(col => col < point.X).Count() * (1000000 - 1);
		var y = point.Y + emptyRows.Where(row => row < point.Y).Count() * (1000000 - 1);
		return new Vector2Long((long)x, (long)y);
	}
}