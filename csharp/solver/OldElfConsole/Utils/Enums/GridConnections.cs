using System.ComponentModel;

namespace AocUtils;


public enum GridConnections
{
	None,
	Vertical,
	Horizontal,
	NorthToEast,
	EastToSouth,
	SouthToWest,
	WestToNorth
}

public static class GridConnectionsExtentions
{
	public static bool GoesSouth(this GridConnections connection) => connection == GridConnections.Vertical || connection == GridConnections.SouthToWest || connection == GridConnections.EastToSouth;
	public static bool GoesNorth(this GridConnections connection) => connection == GridConnections.Vertical || connection == GridConnections.NorthToEast || connection == GridConnections.WestToNorth;
	public static bool GoesEast(this GridConnections connection) => connection == GridConnections.Horizontal || connection == GridConnections.NorthToEast || connection == GridConnections.EastToSouth;
	public static bool GoesWest(this GridConnections connection) => connection == GridConnections.Horizontal || connection == GridConnections.SouthToWest || connection == GridConnections.WestToNorth;

	public static Direction? EnterFrom(this GridConnections connection, Direction direction) => connection switch
	{
		GridConnections.NorthToEast => direction switch
		{
			Direction.North => Direction.Est,
			Direction.Est => Direction.North,
			_ => null
		},
		GridConnections.EastToSouth => direction switch
		{
			Direction.Est => Direction.South,
			Direction.South => Direction.Est,
			_ => null
		},
		GridConnections.SouthToWest => direction switch
		{
			Direction.South => Direction.West,
			Direction.West => Direction.South,
			_ => null
		},
		GridConnections.WestToNorth => direction switch
		{
			Direction.West => Direction.North,
			Direction.North => Direction.West,
			_ => null
		},
		GridConnections.Vertical => direction switch
		{
			Direction.North => Direction.South,
			Direction.South => Direction.North,
			_ => null
		},
		GridConnections.Horizontal => direction switch
		{
			Direction.Est => Direction.West,
			Direction.West => Direction.Est,
			_ => null
		},
		_ => null
	};

}