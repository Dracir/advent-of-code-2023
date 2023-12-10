using AocUtils;


public static class Day8
{
	public static int Part1(string input)
	{
		var (moves, map, _, _) = ParseInput(input);
		var steps = 0;
		var currentIndex = 0;

		while (steps < 9999999 && currentIndex != map.Length - 1)
		{
			var (leftJump, rightJump) = map[currentIndex];
			var move = moves[steps % moves.Length];
			currentIndex = move ? rightJump : leftJump;
			steps++;
		}

		return steps;
	}

	public static ulong Part2(string input)
	{
		var (moves, map, startingIndex, endingIndex) = ParseInput(input);

		var loops = startingIndex.Select(x => FindLoop(moves, map, x, endingIndex)).ToArray();

		var step = (ulong)loops[0];
		for (int i = 1; i < loops.Length; i++)
		{
			step = lcm(step, (ulong)loops[i]);
		}

		return step;
	}

	static ulong gcf(ulong a, ulong b)
	{
		while (b != 0ul)
		{
			ulong temp = b;
			b = a % b;
			a = temp;
		}
		return a;
	}

	static ulong lcm(ulong a, ulong b)
	{
		return (a / gcf(a, b)) * b;
	}

	private static int FindLoop(bool[] moves, (int leftJump, int rightJump)[] map, int startingIndex, int[] endingIndex)
	{
		var steps = 0;
		var endingIndexList = endingIndex.ToList();

		var currentIndex = startingIndex;

		do
		{
			var move = moves[steps % moves.Length];
			var (leftJump, rightJump) = map[currentIndex];
			currentIndex = move ? rightJump : leftJump;
			steps++;

			var currentNodeEndingIndex = endingIndexList.IndexOf(currentIndex);
			if (currentNodeEndingIndex != -1)
			{
				return steps;
			}

		} while (steps < 99999999);

		return -1;
	}

	private static (bool[] moves, (int leftJump, int rightJump)[] map, int[] startingIndex, int[] endingIndex) ParseInput(string input)
	{
		var superSplit = input.Split("\n\n");

		var moves = superSplit[0].Select(x => x == 'R').ToArray();
		//AAA = (BBB, CCC)
		var jumps = superSplit[1].Split("\n").Select(line => line.Split(" = "))
			.Select(parts => (key: parts[0], jumps: parts[1][1..^1].Split(", ").ToArray()))
			.OrderBy(x => x.key)
			.ToList();

		var startingIndex = jumps.Select((x, i) => (x.key, i)).Where(x => x.key[2] == 'A').Select(x => x.i).ToArray();
		var endingIndex = jumps.Select((x, i) => (x.key, i)).Where(x => x.key[2] == 'Z').Select(x => x.i).ToArray();

		var map = new (int leftJump, int rightJump)[jumps.Count];
		for (int i = 0; i < jumps.Count; i++)
		{
			var (from, to) = jumps[i];
			var leftIndex = jumps.FirstBy(x => x.key == to[0]).Index;
			var rightIndex = jumps.FirstBy(x => x.key == to[1]).Index;
			map[i] = (leftIndex, rightIndex);
		}

		return (moves, map, startingIndex, endingIndex);
	}
}