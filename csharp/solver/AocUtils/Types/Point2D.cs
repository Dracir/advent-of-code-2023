namespace AocUtils;

public struct Point2Int
{
	public static Point2Int ZERO = new(0, 0);
	public int X;
	public int Y;

	public readonly Point2Int Up => new(X, Y + 1);
	public readonly Point2Int Down => new(X, Y - 1);
	public readonly Point2Int Left => new(X - 1, Y);
	public readonly Point2Int Right => new(X + 1, Y);
	public readonly Point2Int UpLeft => new(X - 1, Y + 1);
	public readonly Point2Int UpRight => new(X + 1, Y + 1);
	public readonly Point2Int DownLeft => new(X - 1, Y - 1);
	public readonly Point2Int DownRight => new(X + 1, Y - 1);

	public readonly Point2Int[] Ortogonal => new Point2Int[] { Up, Down, Left, Right };
	public readonly Point2Int[] Diagonal => new Point2Int[] { UpLeft, UpRight, DownLeft, DownRight };

	public static Point2Int UpDirection => new(0, 1);
	public static Point2Int DownDirection => new(0, -1);
	public static Point2Int LeftDirection => new(-1, 0);
	public static Point2Int RightDirection => new(1, 0);
	public static Point2Int UpLeftDirection => new(-1, 1);
	public static Point2Int UpRightDirection => new(1, 1);
	public static Point2Int DownLeftDirection => new(-1, -1);
	public static Point2Int DownRightDirection => new(1, -1);

	public static Point2Int[] OrtogonalDirections => new Point2Int[] { UpDirection, DownDirection, LeftDirection, RightDirection };
	public static Point2Int[] DiagonalDirections => new Point2Int[] { UpLeftDirection, UpRightDirection, DownLeftDirection, DownRightDirection };

	public Point2Int(int x, int y)
	{
		X = x;
		Y = y;
	}

	public readonly void Deconstruct(out int x, out int y)
	{
		x = X;
		y = Y;
	}

	public static Point2Int operator *(Point2Int other, int multiplier) => new(other.X * multiplier, other.Y * multiplier);

	public static Point2Int operator +(Point2Int a, Point2Int b) => new(a.X + b.X, a.Y + b.Y);

	public readonly int DistanceManhattan(Point2Int other)
	{
		return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
	}



	public readonly Point2Int RotateLeft() => new(-Y, X);
	public readonly Point2Int RotateRight() => new(Y, -X);

	public readonly override int GetHashCode() => HashCode.Combine(X, Y);

	public readonly override string ToString() => $"({X}, {Y})";

	public readonly override bool Equals(object? obj)
	{
		return obj is Point2Int point &&
			   X == point.X && Y == point.Y;
	}

	public static bool operator ==(Point2Int left, Point2Int right) => left.X == right.X && left.Y == right.Y;

	public static bool operator !=(Point2Int left, Point2Int right) => left.X != right.X || left.Y != right.Y;
}