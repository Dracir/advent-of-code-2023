using System;
using System.Collections.Generic;
using System.Linq;

public static class Day3
{
	public static char[] NUMBERS = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

	public static int Part1(string input)
	{
		var other = input
			.Distinct()
			.Where(x => !NUMBERS.Contains(x) && x != '\n')
			.ToList();
		var otherArray = other.ToArray();
		var symbol = other.Where(x => x != '.').ToArray();

		var answer = 0;

		var lines = input.Split("\n");
		for (int line = 0; line < lines.Length; line++)
		{
			var currentPoint = 0;
			while (true)
			{
				var nextNumber = lines[line].IndexOfAny(NUMBERS, currentPoint);
				if (nextNumber == -1)
					break;

				var numberEndIndex = lines[line].IndexOfAny(otherArray, nextNumber);
				if (numberEndIndex == -1)
					numberEndIndex = lines[line].Length;

				var isValid = false;

				if (line > 0)
				{
					for (int y = nextNumber - 1; y < numberEndIndex + 1; y++)
					{
						if (y >= 0 && y < lines[line - 1].Length && symbol.Contains(lines[line - 1][y]))
							isValid = true;
					}
				}
				if (line < lines.Length - 1)
				{
					for (int y = nextNumber - 1; y < numberEndIndex + 1; y++)
					{
						if (y >= 0 && y < lines[line + 1].Length && symbol.Contains(lines[line + 1][y]))
							isValid = true;
					}
				}
				if (nextNumber > 0 && symbol.Contains(lines[line][nextNumber - 1]))
					isValid = true;

				if (numberEndIndex < lines[line].Length - 1 && symbol.Contains(lines[line][numberEndIndex]))
					isValid = true;

				string number = lines[line].Substring(nextNumber, numberEndIndex - nextNumber);

				if (isValid)
					answer += int.Parse(number);

				Console.WriteLine($"Line {line} {number} {isValid} {answer} endOfNumber:{numberEndIndex}");

				//541535
				//Line 4 617 False 1135 
				currentPoint = nextNumber + number.Length;

			}

		}
		return answer;
	}


	public static int Part2(string input)
	{
		var gearTouchingNumbers = new List<((int line, int col), int number)>();
		var other = input.Distinct().ToList();
		other.RemoveAll(x => NUMBERS.Contains(x));
		other.Remove('\n');
		var otherArray = other.ToArray();
		var symbol = other.Where(x => x != '.').ToArray();


		var lines = input.Split("\n");
		for (int line = 0; line < lines.Length; line++)
		{
			var currentPoint = 0;
			while (true)
			{
				var nextNumber = lines[line].IndexOfAny(NUMBERS, currentPoint);
				if (nextNumber == -1)
					break;

				var numberEndIndex = lines[line].IndexOfAny(otherArray, nextNumber);
				if (numberEndIndex == -1)
					numberEndIndex = lines[line].Length;

				var number = int.Parse(lines[line].Substring(nextNumber, numberEndIndex - nextNumber));

				if (line > 0)
				{
					for (int y = nextNumber - 1; y < numberEndIndex + 1; y++)
					{
						if (y >= 0 && y < lines[line - 1].Length && lines[line - 1][y] == '*')
							gearTouchingNumbers.Add(((line - 1, y), number));

					}
				}
				if (line < lines.Length - 1)
				{
					for (int y = nextNumber - 1; y < numberEndIndex + 1; y++)
					{
						if (y >= 0 && y < lines[line + 1].Length && lines[line + 1][y] == '*')
							gearTouchingNumbers.Add(((line + 1, y), number));
					}
				}

				if (nextNumber > 0 && symbol.Contains(lines[line][nextNumber - 1]))
					gearTouchingNumbers.Add(((line, nextNumber - 1), number));

				if (numberEndIndex < lines[line].Length - 1 && lines[line][numberEndIndex] == '*')
					gearTouchingNumbers.Add(((line, numberEndIndex), number));

				Console.WriteLine($"Line {line} {number} endOfNumber:{gearTouchingNumbers.Count}");

				//541535
				//Line 4 617 False 1135 
				currentPoint = nextNumber + numberEndIndex - nextNumber;

			}
		}

		var bob = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

		var answer = gearTouchingNumbers
			.GroupBy(x => x.Item1)
			.Where(x => x.Count() == 2)
			.Select(x => x.Product(y => y.number))
			.Sum();
		return answer;
	}
}