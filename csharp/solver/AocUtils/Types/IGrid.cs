using System.Collections.Generic;

namespace AocUtils;

public interface IGrid<T>
{
	int UsedMinX { get; }
	int UsedMinY { get; }
	int UsedMaxX { get; }
	int UsedMaxY { get; }
	int MinX { get; }
	int MinY { get; }
	int MaxX { get; }
	int MaxY { get; }
	int UsedWidth { get; }
	int UsedHeight { get; }
	int FullWidth { get; }
	int FullHeight { get; }

	Point2Int TopLeft { get; }
	Point2Int TopRight { get; }
	Point2Int BottomLeft { get; }
	Point2Int BottomRight { get; }
	Point2Int Center { get; }

	T this[Point2Int key] { get; set; }
	T this[int x, int y] { get; set; }


	IEnumerable<Point2Int> Points();
	IEnumerable<Point2Int> AreaSquareAround(Point2Int pt, int radiusDistance);
	IEnumerable<Point2Int> AreaAround(Point2Int pt, int manhattanDistance);
	IEnumerable<int> ColumnIndexs();
	IEnumerable<int> RowIndexs();
	T[,] ToArray();

	void AddGrid(int leftX, int bottomY, T[,] grid, GridPlane plane);

	bool XInBound(int x);
	bool YInBound(int y);
	bool PointInBound(Point2Int pt);

}

public enum GridPlane { XY, YX };
public enum GridAxe { X, Y };