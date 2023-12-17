namespace AocUtils;

using System;
using System.Collections.Generic;
using Console = ElfConsole;

public class GridRenderer<T>
{
	public RectInt DrawZone;
	public IGrid<T>? Grid;
	private readonly Func<T, char> _getTileCharacter;
	public Func<T, Vector2Int, ConsoleColor>? GetTileColorWithPosition;
	public char EmptyChar = ' ';

	private Vector2Int _offset;
	public Vector2Int Offset
	{
		get => _offset;
		set
		{
			OnOffsetChanged(_offset, value);
			_offset = value;
		}
	}

	private int GridUsedWidth => Grid == null ? 0 : Grid.UsedWidth;
	private int GridUsedHeight => Grid == null ? 0 : Grid.UsedHeight;

	private int GridPreviewWidth => Math.Min(GridUsedWidth, DrawZone.Width);
	private int GridPreviewHeight => Math.Min(GridUsedHeight, DrawZone.Height);

	private RenderingBuffer _renderingBuffer;

	public GridRenderer(Func<T, char> getTileCharacter, RectInt drawZone)
	{
		_getTileCharacter = getTileCharacter;
		DrawZone = drawZone;
		Offset = Vector2Int.ZERO;
		_renderingBuffer = new RenderingBuffer(drawZone, false);
	}


	// GridPreviewWidth : 3
	// GridUsedWidth : 5
	// when offset is more than 2, we need to remove the last columns
	//
	private void OnOffsetChanged(Vector2Int oldOffset, Vector2Int newOffset)
	{
		// remove pixels that are no longer in the draw zone
		if (oldOffset.X < newOffset.X)
		{
			var toRemove = newOffset.X + GridPreviewWidth - GridUsedWidth;
			for (int x = GridPreviewWidth - toRemove; x < GridPreviewWidth; x++)
				_renderingBuffer.SetCharOnCol(x, EmptyChar, ConsoleColor.Black);
		}
		else if (oldOffset.X > newOffset.X)
		{
			var toRemove = -newOffset.X;
			for (int x = 0; x < toRemove; x++)
				_renderingBuffer.SetCharOnCol(x, EmptyChar, ConsoleColor.Black);
		}

		if (oldOffset.Y < newOffset.Y)
		{
			var toRemove = newOffset.Y + GridPreviewHeight - GridUsedHeight;
			for (int y = GridPreviewHeight - toRemove; y < GridPreviewHeight; y++)
				_renderingBuffer.SetCharOnRow(y, EmptyChar, ConsoleColor.Black);
		}
		else if (oldOffset.Y > newOffset.Y)
		{
			var toRemove = -newOffset.Y;
			for (int y = 0; y < toRemove; y++)
				_renderingBuffer.SetCharOnRow(y, EmptyChar, ConsoleColor.Black);
		}
	}

	public void Update()
	{
		ElfConsole.StackCurrentColor();
		UpdateBuffer();
		_renderingBuffer.WriteToConsole();
		ElfConsole.UnStackCurrentColor();
	}

	private void UpdateBuffer()
	{
		if (Grid == null)
			return;

		for (int y = 0; y < GridPreviewHeight; y++)
		{
			if (!Grid.YInBound(y + Offset.Y))
				continue;
			for (int x = 0; x < GridPreviewWidth; x++)
			{
				if (!Grid.XInBound(x + Offset.X))
					continue;
				var gridPosition = new Vector2Int(x + Offset.X, y + Offset.Y);
				UpdateCacheForTile(y, x, gridPosition, Grid[gridPosition]);
			}
		}
	}

	private void UpdateCacheForTile(int y, int x, Vector2Int gridPosition, T tileValue)
	{
		var tileChar = _getTileCharacter(tileValue);
		var tileColor = ConsoleColor.White;
		if (GetTileColorWithPosition != null)
			tileColor = GetTileColorWithPosition(tileValue, gridPosition);
		_renderingBuffer.SetChar(x, y, tileChar, tileColor);
	}

}