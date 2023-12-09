using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AocUtils;

public static class PointHelper
{
	public static readonly Point2Int[] _8DirectionPoints = new Point2Int[]{
		new Point2Int(0,1),
		new Point2Int(1,1),
		new Point2Int(1,0),
		new Point2Int(1,-1),
		new Point2Int(0,-1),
		new Point2Int(-1,-1),
		new Point2Int(-1,0),
		new Point2Int(-1,1),
	};
}