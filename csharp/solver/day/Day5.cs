using AocUtils;

public static class Day5
{
	public static ulong Part1(string input)
	{
		var almanac = Parse(input);
		var lowestSeedLocation = ulong.MaxValue;

		foreach (var seed in almanac.Seeds)
		{
			var soil = AToB(almanac.SeedToSoilMap, seed);
			var fertilizer = AToB(almanac.SoilToFertilizerMap, soil);
			var water = AToB(almanac.FertilizerToWaterMap, fertilizer);
			var light = AToB(almanac.WaterToLightMap, water);
			var temperature = AToB(almanac.LightToTemperatureMap, light);
			var humidity = AToB(almanac.TemperatureToHumidityMap, temperature);
			var location = AToB(almanac.HumidityToLocationMap, humidity);

			lowestSeedLocation = Math.Min(lowestSeedLocation, location);
		}

		return lowestSeedLocation;
	}

	public static ulong AToB(List<(RangeUlong FromRange, ulong To)> map, ulong a)
	{
		foreach ((RangeUlong fromRange, ulong to) in map)
		{
			if (fromRange.Contains(a))
				return to + a - fromRange.Min;
		}

		return a;
	}

	public static ulong Part2(string input)
	{
		var almanac = Parse(input);

		return almanac.Seeds
			.Chunk(2)
			.Select(x => AToZ(ref almanac, x[0], x[1], 0))
			.Min();
	}

	public static ulong AToZ(ref Almanac almanac, ulong startValue, ulong valueRange, int mapIndex)
	{
		// var tab = mapIndex == 0 ? "" : Enumerable.Repeat("\t", mapIndex).Aggregate((a, b) => a + b);
		// Console.WriteLine($"{tab}AtoZ: {startValue} {valueRange} {mapIndex}");
		var map = almanac.MapAtIndex(mapIndex);

		var lowestSeedLocation = ulong.MaxValue;
		var value = startValue;
		while (value < startValue + valueRange)
		{
			var (b, bRemainingAfter) = AToBWithRange(map, value);
			var currentRemeaning = startValue + valueRange - value - 1ul;
			var realRemainingRange = Math.Min(bRemainingAfter, currentRemeaning);

			// Console.WriteLine($"{tab}AtoZ: startValue:{startValue} Range:{valueRange} Index:{mapIndex} - value: {value} b: {b}, bRemainingRange:{bRemainingAfter}, currentRemeaning:{currentRemeaning} => realRemainingRange: {realRemainingRange}");

			if (realRemainingRange == 0)
				realRemainingRange = 1;

			value += realRemainingRange;

			if (mapIndex == 6)
				lowestSeedLocation = Math.Min(lowestSeedLocation, b);
			else
				lowestSeedLocation = Math.Min(lowestSeedLocation, AToZ(ref almanac, b, realRemainingRange, mapIndex + 1));
		}

		return lowestSeedLocation;
	}

	public static (ulong Start, ulong RemainingAfter) AToBWithRange(List<(RangeUlong FromRange, ulong To)> map, ulong a)
	{
		var firstRangeStartAfterA = ulong.MaxValue;
		foreach ((RangeUlong fromRange, ulong to) in map)
		{
			if (fromRange.Min > a && fromRange.Min < firstRangeStartAfterA)
				firstRangeStartAfterA = fromRange.Min;

			if (fromRange.Contains(a))
			{
				var xLocation = a - fromRange.Min;
				var remaining = fromRange.MaxExclusive - a;
				return (to + xLocation, remaining);
			}
		}

		return (a, firstRangeStartAfterA - a);
	}


	public static Almanac Parse(string input)
	{
		var groups = input.Split("\n\n");

		return new Almanac
		{
			Seeds = groups[0].Split(": ")[1].ParseListOfUlong(),
			SeedToSoilMap = ParseMap(groups[1]),
			SoilToFertilizerMap = ParseMap(groups[2]),
			FertilizerToWaterMap = ParseMap(groups[3]),
			WaterToLightMap = ParseMap(groups[4]),
			LightToTemperatureMap = ParseMap(groups[5]),
			TemperatureToHumidityMap = ParseMap(groups[6]),
			HumidityToLocationMap = ParseMap(groups[7]),
		};
	}

	private static List<(RangeUlong, ulong)> ParseMap(string group)
	{
		return group.Split("\n").Skip(1)
		.Select(x => x.ParseListOfUlong()).Select(x => (new RangeUlong(x[1], x[1] + x[2]), x[0]))
		.ToList();
	}

	public struct Almanac
	{
		public ulong[] Seeds;

		public List<(RangeUlong FromRange, ulong To)> SeedToSoilMap;
		public List<(RangeUlong FromRange, ulong To)> SoilToFertilizerMap;
		public List<(RangeUlong FromRange, ulong To)> FertilizerToWaterMap;
		public List<(RangeUlong FromRange, ulong To)> WaterToLightMap;
		public List<(RangeUlong FromRange, ulong To)> LightToTemperatureMap;
		public List<(RangeUlong FromRange, ulong To)> TemperatureToHumidityMap;
		public List<(RangeUlong FromRange, ulong To)> HumidityToLocationMap;


		public readonly List<(RangeUlong FromRange, ulong To)> MapAtIndex(int index) => index switch
		{
			0 => SeedToSoilMap,
			1 => SoilToFertilizerMap,
			2 => FertilizerToWaterMap,
			3 => WaterToLightMap,
			4 => LightToTemperatureMap,
			5 => TemperatureToHumidityMap,
			6 => HumidityToLocationMap,
			_ => HumidityToLocationMap
		};
	}

}