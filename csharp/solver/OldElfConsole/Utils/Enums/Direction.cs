

namespace AocUtils;

public enum Direction { North = 0, Est = 1, South = 2, West = 3 }

public static class DirectionExtentions
{
	public static Direction Left(this Direction direction) => (Direction)(((int)direction + 3) % 4);
	public static Direction Right(this Direction direction) => (Direction)(((int)direction + 1) % 4);
	public static Vector2Int ToPoint(this Direction direction) => direction switch
	{
		Direction.North => new Vector2Int(0, 1),
		Direction.Est => new Vector2Int(1, 0),
		Direction.South => new Vector2Int(0, -1),
		Direction.West => new Vector2Int(-1, 0),
		_ => new Vector2Int(0, 0),
	};

	public static Direction Fliped(this Direction direction) => direction switch
	{
		Direction.North => Direction.South,
		Direction.Est => Direction.West,
		Direction.South => Direction.North,
		Direction.West => Direction.Est,
		_ => Direction.North,
	};
}
