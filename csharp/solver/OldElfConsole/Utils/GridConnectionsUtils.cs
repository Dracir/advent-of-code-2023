namespace AocUtils;


public static class GridConnectionsUtils
{

	public static GridConnections GetConnectionFor(bool fromNorth, bool fromEast, bool fromSouth, bool fromWest) => (fromNorth, fromEast, fromSouth, fromWest) switch
	{
		(true, true, false, false) => GridConnections.NorthToEast,
		(false, true, true, false) => GridConnections.EastToSouth,
		(false, false, true, true) => GridConnections.SouthToWest,
		(true, false, false, true) => GridConnections.WestToNorth,
		(true, false, true, false) => GridConnections.Vertical,
		(false, true, false, true) => GridConnections.Horizontal,
		_ => throw new Exception("Invalid connection")
	};

	public static Direction[] ConnectionToDirections(GridConnections connection) => connection switch
	{
		GridConnections.NorthToEast => new[] { Direction.North, Direction.Est },
		GridConnections.EastToSouth => new[] { Direction.Est, Direction.South },
		GridConnections.SouthToWest => new[] { Direction.South, Direction.West },
		GridConnections.WestToNorth => new[] { Direction.West, Direction.North },
		GridConnections.Vertical => new[] { Direction.North, Direction.South },
		GridConnections.Horizontal => new[] { Direction.Est, Direction.West },
		_ => Array.Empty<Direction>(),
	};

	public static char ConnectionToChar(GridConnections connections) => connections switch
	{
		GridConnections.None => '.',
		GridConnections.Horizontal => '-',
		GridConnections.Vertical => '|',
		GridConnections.NorthToEast => '└',
		GridConnections.EastToSouth => '┌',
		GridConnections.SouthToWest => '┐',
		GridConnections.WestToNorth => '┘',
		_ => throw new Exception("Invalid connection")
	};
}