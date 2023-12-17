

namespace AocUtils;

public enum DiagonalDirection { NorthWest = 0, NorthEast = 1, SouthWest = 2, SouthEast = 3 }

public static class DiagonalDirectionExtentions
{
	//public static Direction Left(this Direction direction) => (Direction)(((int)direction + 3) % 4);
	//public static Direction Right(this Direction direction) => (Direction)(((int)direction + 1) % 4);
	public static Vector2Int ToPoint(this DiagonalDirection diagonalDirection) => diagonalDirection switch
	{
		DiagonalDirection.NorthWest => new Vector2Int(-1, -1),
		DiagonalDirection.NorthEast => new Vector2Int(1, 1),
		DiagonalDirection.SouthWest => new Vector2Int(-1, 1),
		DiagonalDirection.SouthEast => new Vector2Int(-1, 1),
		_ => new Vector2Int(0, 0),
	};
}
