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

			// Console.WriteLine($"Seed: {seed} -> Soil: {soil} -> Fertilizer: {fertilizer} -> Water: {water} -> Light: {light} -> Temperature: {temperature} -> Humidity: {humidity} -> Location: {location}");
		}

		return lowestSeedLocation;
	}

	public static ulong AToB(List<(ulong AStart, ulong BStart, ulong Range)> map, ulong a)
	{
		foreach (var (AStart, BStart, Range) in map)
		{
			if (a >= AStart && a < AStart + Range)
				return BStart + (a - AStart);
		}

		return a;
	}

	public static ulong Part2(string input)
	{
		var almanac = Parse(input);
		var lowestSeedLocation = ulong.MaxValue;

		for (int i = 0; i < almanac.Seeds.Length; i += 2)
			lowestSeedLocation = Math.Min(lowestSeedLocation, AToZ(ref almanac, almanac.Seeds[i], almanac.Seeds[i + 1], 0));

		return lowestSeedLocation;
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
			var currentRemeaning = startValue + valueRange - value - 1;
			var realRemainingRange = 1 + Math.Min(bRemainingAfter, currentRemeaning);

			// Console.WriteLine($"{tab}AtoZ: startValue:{startValue} Range:{valueRange} Index:{mapIndex} - value: {value} b: {b}, bRemainingRange:{bRemainingAfter}, currentRemeaning:{currentRemeaning} => realRemainingRange: {realRemainingRange}");

			value += realRemainingRange;

			if (mapIndex == 6)
				lowestSeedLocation = Math.Min(lowestSeedLocation, b);
			else
				lowestSeedLocation = Math.Min(lowestSeedLocation, AToZ(ref almanac, b, realRemainingRange, mapIndex + 1));
		}

		return lowestSeedLocation;
	}

	public static (ulong Start, ulong RemainingAfter) AToBWithRange(List<(ulong AStart, ulong BStart, ulong Range)> map, ulong a)
	{
		var minAfterA = ulong.MaxValue;
		foreach (var (AStart, BStart, Range) in map)
		{
			if (AStart > a && AStart < minAfterA)
				minAfterA = AStart;

			if (a >= AStart && a < AStart + Range)
			{
				var xLocation = a - AStart;
				var remaining = Range - xLocation - 1;
				return (BStart + xLocation, remaining);
			}
		}

		return (a, minAfterA - a - 1);
	}


	public static Almanac Parse(string input)
	{
		var groups = input.Split("\n\n");

		var seeds = groups[0].Split(": ")[1].Split(" ").Select(ulong.Parse).ToArray();

		var seedToSoilMap = groups[1].Split("\n").Skip(1).Select(x => x.Split(" ").Select(ulong.Parse).ToArray()).Select(x => (x[1], x[0], x[2])).ToList();
		var soilToFertilizerMap = groups[2].Split("\n").Skip(1).Select(x => x.Split(" ").Select(ulong.Parse).ToArray()).Select(x => (x[1], x[0], x[2])).ToList();
		var fertilizerToWaterMap = groups[3].Split("\n").Skip(1).Select(x => x.Split(" ").Select(ulong.Parse).ToArray()).Select(x => (x[1], x[0], x[2])).ToList();
		var waterToLightMap = groups[4].Split("\n").Skip(1).Select(x => x.Split(" ").Select(ulong.Parse).ToArray()).Select(x => (x[1], x[0], x[2])).ToList();
		var lightToTemperatureMap = groups[5].Split("\n").Skip(1).Select(x => x.Split(" ").Select(ulong.Parse).ToArray()).Select(x => (x[1], x[0], x[2])).ToList();
		var temperatureToHumidityMap = groups[6].Split("\n").Skip(1).Select(x => x.Split(" ").Select(ulong.Parse).ToArray()).Select(x => (x[1], x[0], x[2])).ToList();
		var humidityToLocationMap = groups[7].Split("\n").Skip(1).Select(x => x.Split(" ").Select(ulong.Parse).ToArray()).Select(x => (x[1], x[0], x[2])).ToList();

		return new Almanac
		{
			Seeds = seeds,
			SeedToSoilMap = seedToSoilMap,
			SoilToFertilizerMap = soilToFertilizerMap,
			FertilizerToWaterMap = fertilizerToWaterMap,
			WaterToLightMap = waterToLightMap,
			LightToTemperatureMap = lightToTemperatureMap,
			TemperatureToHumidityMap = temperatureToHumidityMap,
			HumidityToLocationMap = humidityToLocationMap
		};
	}

	public struct Almanac
	{
		public ulong[] Seeds;

		public List<(ulong SeedStart, ulong SoilStart, ulong Range)> SeedToSoilMap;
		public List<(ulong SoilStart, ulong FertilizerStart, ulong Range)> SoilToFertilizerMap;
		public List<(ulong FertilizerStart, ulong WaterStart, ulong Range)> FertilizerToWaterMap;
		public List<(ulong WaterStart, ulong LightStart, ulong Range)> WaterToLightMap;
		public List<(ulong LightStart, ulong TemperatureStart, ulong Range)> LightToTemperatureMap;
		public List<(ulong TemperatureStart, ulong HumidityStart, ulong Range)> TemperatureToHumidityMap;
		public List<(ulong HumidityStart, ulong LocationStart, ulong Range)> HumidityToLocationMap;

		public List<(ulong AStart, ulong BStart, ulong Range)> MapAtIndex(int index) => index switch
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