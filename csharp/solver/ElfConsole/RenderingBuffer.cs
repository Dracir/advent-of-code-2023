namespace AocUtils;


public class RenderingBuffer
{
	private char[,] _characters;
	private ConsoleColor[,] _colors;
	private bool[,] _changed;
	private RectInt drawZone;
	private readonly Vector2Int _topLeftCorner;
	private readonly bool _drawFromTopToBottom;

	public RenderingBuffer(int width, int height, Vector2Int topLeftCorner, bool drawFromTopToBottom = true)
	{
		_characters = new char[width, height];
		_colors = new ConsoleColor[width, height];
		_changed = new bool[width, height];
		_topLeftCorner = topLeftCorner;
		_drawFromTopToBottom = drawFromTopToBottom;
	}

	public RenderingBuffer(RectInt drawZone, bool drawFromTopToBottom = true)
	{
		this.drawZone = drawZone;
		_characters = new char[drawZone.Width, drawZone.Height];
		_colors = new ConsoleColor[drawZone.Width, drawZone.Height];
		_changed = new bool[drawZone.Width, drawZone.Height];
		_topLeftCorner = new Vector2Int(drawZone.X, drawZone.Y);
		_drawFromTopToBottom = drawFromTopToBottom;
	}

	public void SetChar(Vector2Int position, char character, ConsoleColor color)
	{
		_changed[position.X, position.Y] = _characters[position.X, position.Y] != character || _colors[position.X, position.Y] != color;
		_characters[position.X, position.Y] = character;
		_colors[position.X, position.Y] = color;
	}

	public void SetChar(int x, int y, char character, ConsoleColor color)
	{
		_changed[x, y] = _characters[x, y] != character || _colors[x, y] != color;
		_characters[x, y] = character;
		_colors[x, y] = color;
	}

	public void SetCharOnCol(int x, char character, ConsoleColor color)
	{
		for (int y = 0; y < drawZone.Height; y++)
		{
			_changed[x, y] = _characters[x, y] != character || _colors[x, y] != color;
			_characters[x, y] = character;
			_colors[x, y] = color;
		}
	}

	public void SetCharOnRow(int y, char character, ConsoleColor color)
	{
		for (int x = 0; x < drawZone.Width; x++)
		{
			_changed[x, y] = _characters[x, y] != character || _colors[x, y] != color;
			_characters[x, y] = character;
			_colors[x, y] = color;
		}
	}

	public void WriteToConsole()
	{
		//TODO : optimize this by grouping changes by color and writing them all at once
		for (int y = 0; y < _characters.GetLength(1); y++)
		{
			for (int x = 0; x < _characters.GetLength(0); x++)
			{
				if (!_changed[x, y])
					continue;

				var drawnY = _drawFromTopToBottom ? y : _characters.GetLength(1) - y - 1;
				Console.SetCursorPosition(_topLeftCorner.X + x, _topLeftCorner.Y + drawnY);
				Console.ForegroundColor = _colors[x, y];
				Console.Write(_characters[x, y]);
				_changed[x, y] = false;
			}
		}
	}

}