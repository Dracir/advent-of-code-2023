using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AocUtils;

public static class PointHelper
{
	public static readonly Vector2Int[] _8DirectionPoints = new Vector2Int[]{
		new Vector2Int(0,1),
		new Vector2Int(1,1),
		new Vector2Int(1,0),
		new Vector2Int(1,-1),
		new Vector2Int(0,-1),
		new Vector2Int(-1,-1),
		new Vector2Int(-1,0),
		new Vector2Int(-1,1),
	};
}