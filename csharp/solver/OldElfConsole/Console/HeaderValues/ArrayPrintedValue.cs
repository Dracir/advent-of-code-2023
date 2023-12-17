using System;
using System.IO;
using System.Collections.Generic;

namespace AocUtils;

public class ArrayPrintedValue
{
	private int _width;
	private FormatedPrintedValue[] _printedValues;

	public ArrayPrintedValue(Vector2Int position, int cellWidth, int nbCells, int cellSpacing, ConsoleColor color, string? format = null)
	{
		_width = cellWidth;
		_printedValues = new FormatedPrintedValue[nbCells];
		for (int i = 0; i < nbCells; i++)
			_printedValues[i] = new FormatedPrintedValue(position + new Vector2Int(i * (cellWidth + cellSpacing), 0), cellWidth, color, format);
	}

	public void SetColor(int i, ConsoleColor color)
	{
		_printedValues[i]._Color = color;
	}


	public void SetValue(int[] value)
	{
		for (int i = 0; i < MathF.Min(value.Length, _printedValues.Length); i++)
			_printedValues[i].SetValue(value[i]);
	}

	public void SetValue(float[] value)
	{
		for (int i = 0; i < MathF.Min(value.Length, _printedValues.Length); i++)
			_printedValues[i].SetValue(value[i]);
	}

	public void SetValue(string[] value)
	{
		for (int i = 0; i < MathF.Min(value.Length, _printedValues.Length); i++)
			_printedValues[i].SetValue(value[i]);
	}
}