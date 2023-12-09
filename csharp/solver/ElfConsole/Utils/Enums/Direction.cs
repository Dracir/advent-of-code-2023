

namespace AocUtils;

public enum Direction { North = 0, Est = 1, South = 2, West = 3 }

public static class DirectionExtentions
{
	public static Direction Left(this Direction direction) => (Direction)(((int)direction + 3) % 4);
	public static Direction Right(this Direction direction) => (Direction)(((int)direction + 1) % 4);
	public static Point2Int ToPoint(this Direction direction) => direction switch
	{
		Direction.North => new Point2Int(0, -1),
		Direction.Est => new Point2Int(1, 0),
		Direction.South => new Point2Int(0, 1),
		Direction.West => new Point2Int(-1, 0),
		_ => new Point2Int(0, 0),
	};
}
