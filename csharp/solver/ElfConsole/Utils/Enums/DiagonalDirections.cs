
public enum DiagonalDirection { NorthWest = 0, NorthEast = 1, SouthWest = 2, SouthEast = 3 }

public static class DiagonalDirectionExtentions
{
	//public static Direction Left(this Direction direction) => (Direction)(((int)direction + 3) % 4);
	//public static Direction Right(this Direction direction) => (Direction)(((int)direction + 1) % 4);
	public static Point2Int ToPoint(this DiagonalDirection direction) => direction switch
	{
		DiagonalDirection.NorthWest => new Point2Int(-1, -1),
		DiagonalDirection.NorthEast => new Point2Int(1, 1),
		DiagonalDirection.SouthWest => new Point2Int(-1, 1),
		DiagonalDirection.SouthEast => new Point2Int(-1, 1),
		_ => new Point2Int(0, 0),
	};
}
