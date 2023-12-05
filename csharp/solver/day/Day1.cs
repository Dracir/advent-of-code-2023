public static class Day1
{

	public static ulong Part1(string input)
	{
		var lines = input.Split('\n');

		var sum = 0ul;

		foreach (var line in lines)
		{
			var (first, second) = ParseLine(line);
			sum += (ulong)(first * 10 + second);
			Console.WriteLine($"First: {first}, Second: {second} , superNumber: {sum}");
		}

		return sum;
	}

	public static ulong Part2(string input)
	{
		var lines = input.Split('\n');

		var sum = 0ul;

		foreach (var line in lines)
		{
			var (first, second) = ParseLinePart2(line);
			sum += (ulong)(first * 10 + second);
			Console.WriteLine($"First: {first}, Second: {second} , superNumber: {sum}");
		}

		return sum;
	}


	public static (int First, int Second) ParseLine(string line)
	{
		var first = line.First(x => char.IsDigit(x)) - '0';
		var last = line.Last(x => char.IsDigit(x)) - '0';

		return (first, last);
	}


	private static string[] numbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

	public static (int First, int Second) ParseLinePart2(string line)
	{
		var firstInNumber = -1;
		var firstInNumberMinIndex = int.MaxValue;
		for (int i = 0; i < numbers.Length; i++)
		{
			var index = line.IndexOf(numbers[i]);
			if (index != -1 && index < firstInNumberMinIndex)
			{
				firstInNumberMinIndex = index;
				firstInNumber = i % 10;
			}
		}

		var lastInNumber = -1;
		var lastInNumberIndex = -1;
		for (int i = 0; i < numbers.Length; i++)
		{
			var index = line.LastIndexOf(numbers[i]);
			if (index != -1 && (index > lastInNumberIndex))
			{
				lastInNumberIndex = index;
				lastInNumber = i % 10;
			}
		}

		return (firstInNumber, lastInNumber);
	}
}