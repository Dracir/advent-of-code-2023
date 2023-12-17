using System.Diagnostics;

public static class DayRunner
{
	public static void Main()
	{
		Console.WriteLine("Hello, World!");
	}

	public static void Run(Func<string, ulong> solver, string filename)
	{
		var solverToString = new Func<string, string>(s => solver(s).ToString());
		Run(solverToString, filename);
	}

	public static void Run(Func<string, int> solver, string filename)
	{
		var solverToString = new Func<string, string>(s => solver(s).ToString());
		Run(solverToString, filename);
	}
	public static void Run(Func<string, long> solver, string filename)
	{
		var solverToString = new Func<string, string>(s => solver(s).ToString());
		Run(solverToString, filename);
	}


	public static void Run(Func<string, string> solver, string filename)
	{
		var input = File.ReadAllText($"inputs/{filename}.txt");
		var stopwatch = new Stopwatch();
		stopwatch.Start();

		var answer = solver(input);

		stopwatch.Stop();
		Console.WriteLine($"Answer: {answer} in {stopwatch.ElapsedMilliseconds}ms");
	}
}