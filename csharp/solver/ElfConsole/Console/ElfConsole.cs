
using System;

namespace AocUtils;

public static class ElfConsole
{
	public static int Width { get { return Console.WindowWidth; } }
	public static int Height { get { return Console.WindowHeight - 1; } }
	public static int Right { get { return Console.WindowWidth - 1; } }
	public static int Bottom { get { return Console.WindowHeight - 2; } }

	private static int WriteLeft { get { return 0; } }
	private static int WriteRight { get { return Width - 0; } }
	private static int WriteTop { get { return 0; } }
	private static int WriteBottom { get { return Height - 0; } }
	private static int WriteHeight { get { return Height - WriteTop; } }
	private static int WriteWidth { get { return Width; } }

	public static Point2Int Position
	{
		get { return new Point2Int(Console.CursorLeft, Console.CursorTop); }
		set
		{
			Console.CursorLeft = Math.Clamp(value.X, 0, Right);
			Console.CursorTop = Math.Clamp(value.Y, 0, Bottom);
		}
	}

	private static ConsoleColor _currentForegroundColor;
	public static ConsoleColor ForegroundColor
	{
		get => Console.ForegroundColor;
		set
		{
			if (_currentForegroundColor == value)
				return;
			Console.ForegroundColor = value;
			_currentForegroundColor = value;
		}
	}


	private static ConsoleColor _currentBackgroundColor;
	public static ConsoleColor BackgroundColor
	{
		get => Console.BackgroundColor;
		set
		{
			if (_currentBackgroundColor == value)
				return;
			Console.BackgroundColor = value;
			_currentBackgroundColor = value;
		}
	}

	public static void ResetColor()
	{
		BackgroundColor = ConsoleColor.Black;
		ForegroundColor = ConsoleColor.White;
	}


	private static Stack<ConsoleColor> _backgroundColorStack = new Stack<ConsoleColor>();
	private static Stack<ConsoleColor> _foregroundColorStack = new Stack<ConsoleColor>();
	public static void StackCurrentColor()
	{
		_backgroundColorStack.Push(_currentBackgroundColor);
		_foregroundColorStack.Push(_currentForegroundColor);
	}

	public static void UnStackCurrentColor()
	{
		if (_backgroundColorStack.Count == 0)
			return;
		BackgroundColor = _backgroundColorStack.Pop();
		ForegroundColor = _foregroundColorStack.Pop();
	}


	public static void WriteLineAtLine(string value, int line, int linesWidth = 0) => WriteLinesAt(value, 0, line, linesWidth);

	public static void WriteLinesAt(string value, int x, int y, int linesWidth = 0)
	{
		if (value.Contains("\n"))
		{
			foreach (var line in value.Split("\n"))
			{
				var lineStr = line;
				if (linesWidth != 0)
					lineStr = lineStr.PadRight(linesWidth);
				WriteLineAt(lineStr, x, y++);
			}
		}
		else
		{
			if (linesWidth != 0)
				WriteLineAt(value.PadRight(linesWidth), x, y);
			else
				WriteLineAt(value, x, y);
		}
	}

	public static void WriteCharAt(char value, int x, int y)
	{
		if (x >= WriteRight || y >= WriteBottom || x < 0 || y < 0)
			return;
		Position = new Point2Int(WriteLeft + x, WriteTop + y);
		File.AppendAllText("drawn.txt", $"({x},{y}) : {value}\n");
		Console.Write(value);
	}

	public static void WriteLineAt(string value, int x, int y)
	{
		var text = value;
		if (x >= WriteRight)
			return;
		if (y >= WriteBottom)
			return;
		if (x + text.Length > WriteRight)
			text = text.Substring(WriteRight - x - 1) + '…';
		File.AppendAllText("drawn.txt", $"({x},{y}) : {value}\n");

		Position = new Point2Int(x, y);
		Console.WriteLine(text);

	}
	public static ConsoleKeyInfo ReadKey() => Console.ReadKey();
	public static void Clear() => Console.Clear();

	public static void SetTitle(int day, string title, int part)
	{
		//Console.ForegroundColor = ConsoleManager.Skin.FramesColor;
		var line = new String('═', Width - 2); // ═ slow

		ForegroundColor = ConsoleColor.Gray;
		WriteLineAtLine($"╔{line}╗", Height - 3);
		for (int y = Height - 2; y < Height; y++)
		{
			WriteLinesAt("║", 0, y);
			WriteLinesAt("║", Width - 1, y);

		}

		ForegroundColor = ConsoleColor.White;
		var titleText = $" Day {day}: {title} - Part {part} ";
		WriteLinesAt(titleText, 2, Height - 3);

		Console.ResetColor();
	}
}