namespace AocUtils;

public static class GridScene<T>
{
	public static void PreviewGrid(IGrid<T> grid, Func<T, char> getTileCharacter, Func<T, Vector2Int, ConsoleColor> getTileColor, Vector2Int startingCenter)
	{
		// var renderer = new GridRenderer<T>(getTileCharacter, new RectInt(0, 0, 100, 50));
		System.Console.CursorVisible = false;
		ElfConsole.Clear();
		Console.CursorLeft = 1;

		Console.CursorTop = ElfConsole.Height - 1;
		// Console.WriteLine("  ");
		ElfConsole.SetTitle(10, "Pipe Maze", 1);

		var w = Math.Min(ElfConsole.Width, grid.UsedWidth);
		var h = Math.Min(ElfConsole.Height - 4, grid.UsedHeight);
		var renderer = new GridRenderer<T>(getTileCharacter, new RectInt(1, 3, w, h));
		renderer.Grid = grid;
		renderer.Offset = startingCenter;
		renderer.GetTileColorWithPosition = getTileColor;
		renderer.Update();

		while (true)
		{
			var input = ElfConsole.ReadKey();
			if (input.Key == ConsoleKey.UpArrow)
				renderer.Offset += new Vector2Int(0, 1);
			else if (input.Key == ConsoleKey.DownArrow)
				renderer.Offset += new Vector2Int(0, -1);
			else if (input.Key == ConsoleKey.LeftArrow)
				renderer.Offset += new Vector2Int(-1, 0);
			else if (input.Key == ConsoleKey.RightArrow)
				renderer.Offset += new Vector2Int(1, 0);
			else if (input.Key == ConsoleKey.Escape)
				break;
			else if (input.Key == ConsoleKey.Home)
				renderer.Offset = new Vector2Int(0, renderer.Offset.Y);
			else if (input.Key == ConsoleKey.End)
				renderer.Offset = new Vector2Int(grid.UsedWidth - renderer.DrawZone.Width, renderer.Offset.Y);
			else if (input.Key == ConsoleKey.PageUp)
				renderer.Offset = new Vector2Int(renderer.Offset.X, grid.UsedHeight - renderer.DrawZone.Height);
			else if (input.Key == ConsoleKey.PageDown)
				renderer.Offset = new Vector2Int(renderer.Offset.X, 0);

			renderer.Update();
		}

		Console.CursorTop = ElfConsole.Height - 1;
		System.Console.CursorVisible = true;
	}
}