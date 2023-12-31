using System;
using System.Collections.Generic;
using System.Linq;

public static class IEnumerableExtentions
{
	public static TAccumulate AggregateUntil<TSource, TAccumulate>(
		   this IEnumerable<TSource> source, TAccumulate seed,
		   Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, bool> predicate)
	{
		if (source == null)
			throw new ArgumentNullException(nameof(source));

		if (func == null)
			throw new ArgumentNullException(nameof(func));

		if (predicate == null)
			throw new ArgumentNullException(nameof(func));

		var accumulate = seed;
		foreach (var item in source)
		{
			accumulate = func(accumulate, item);
			if (predicate(accumulate)) break;
		}
		return accumulate;
	}

	public static IEnumerable<IEnumerable<T>> GroupWhile<T>(this IEnumerable<T> seq, Func<T, T, bool> condition)
	{
		T prev = seq.First();
		List<T> list = new List<T>() { prev };

		foreach (T item in seq.Skip(1))
		{
			if (condition(prev, item) == false)
			{
				yield return list;
				list = new List<T>();
			}
			list.Add(item);
			prev = item;
		}

		yield return list;
	}
	public static int Product(this IEnumerable<int> enumerable)
	{
		return enumerable.Aggregate(1, (mult, value) => mult * value);
	}

	public static int Product<T>(this IEnumerable<T> enumerable, Func<T, int> func)
	{
		return enumerable.Aggregate(1, (mult, value) => mult * func(value));
	}

	public static long Product<T>(this IEnumerable<T> enumerable, Func<T, long> func)
	{
		return enumerable.Aggregate(1L, (mult, value) => mult * func(value));
	}

	public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
	{
		foreach (T item in enumeration)
		{
			action(item);
			yield return item;
		}
	}

	public static (int Value, int Index) MaxBy(this IEnumerable<int> enumeration)
	{
		return enumeration.Select((value, index) => (value, index))
			.Aggregate((value: enumeration.First(), index: 0), (currMaxTupple, otherTupple) => currMaxTupple.value > otherTupple.value ? currMaxTupple : otherTupple);
	}

	public static (T Value, int Index) MaxBy<T>(this IEnumerable<T> enumeration, Func<T, int> selector)
	{
		return enumeration.Select((value, index) => (value, index))
			.Aggregate((value: enumeration.First(), index: 0), (currMaxTupple, otherTupple)
					=> selector(currMaxTupple.value) > selector(otherTupple.value) ? currMaxTupple : otherTupple);
	}

	public static T MaxBy<T>(this IEnumerable<T> enumeration, Func<T, long> selector)
	{
		return enumeration.Aggregate(enumeration.First(), (currMax, x) => selector(currMax) < selector(x) ? x : currMax);
	}

	public static (int Index, T Value) FirstBy<T>(this IEnumerable<T> enumeration, Func<T, bool> selector)
	{
		return enumeration.Select((x, i) => (i, x)).First(x => selector(x.x));

	}



	public static string JoinStr<T>(this IEnumerable<T> enumeration, Func<T, string> selector, char separator)
	{
		return enumeration.Aggregate("", (agg, x) => string.IsNullOrEmpty(agg) ? selector(x) : (agg + separator + selector(x)));
	}
	public static string JoinStr(this IEnumerable<string> enumeration, char separator)
	{
		return enumeration.Aggregate("", (agg, x) => string.IsNullOrEmpty(agg) ? x : (agg + separator + x));
	}
	public static string JoinStr(this IEnumerable<string> enumeration)
	{
		return enumeration.Aggregate("", (agg, x) => string.IsNullOrEmpty(agg) ? x : agg + x);
	}

	public static IEnumerable<T> Flatten<T>(this IEnumerable<T> e, Func<T, IEnumerable<T>> selector)
	{
		return e.SelectMany(c => Flatten(selector(c), selector));
	}


	public static IEnumerable<(T, T)> PairUpTriangle<T>(this IEnumerable<T> enumeration)
	{
		var enumerationToList = enumeration.ToArray();
		for (int i = 0; i < enumerationToList.Length; i++)
		{
			for (int j = i; j < enumerationToList.Length; j++)
			{
				yield return (enumerationToList[i], enumerationToList[j]);
			}
		}
	}

	// Doesnt pair up the same elements together
	public static IEnumerable<(T, T)> PairUpTriangleWithoutDiagonal<T>(this IEnumerable<T> enumeration)
	{
		var enumerationToList = enumeration.ToArray();
		for (int i = 0; i < enumerationToList.Length; i++)
		{
			for (int j = i + 1; j < enumerationToList.Length; j++)
			{
				yield return (enumerationToList[i], enumerationToList[j]);
			}
		}
	}

	public static List<(T, T)> PairUpSquare<T>(this IEnumerable<T> enumeration)
	{
		return enumeration.SelectMany(row => enumeration.Select(col => (row, col)))
			.ToList();
	}

	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		HashSet<TKey> seenKeys = new HashSet<TKey>();
		foreach (TSource element in source)
		{
			if (seenKeys.Add(keySelector(element)))
			{
				yield return element;
			}
		}
	}

	public static IEnumerable<char> AllCapsLetters()
	{
		for (int i = 0; i < 24; i++)
		{
			yield return (char)('A' + i);
		}
	}

	public static string GetPrintStr<T>(this IEnumerable<T> enumeration)
	{
		return $"[{string.Join(",", enumeration.Select(x => x == null ? "" : x.ToString()))}]";
	}


	//TODO
	private static (int indexStart, int indexEnd)? FindFirstConsecutivesNumbers(List<int> indexes)
	{
		for (int minI = 0; minI < indexes.Count - 1; minI++)
		{
			if (indexes[minI + 1] == indexes[minI] + 1)
			{
				for (int maxI = minI + 1; maxI < indexes.Count; maxI++)
				{
					if (indexes[maxI + 1] > indexes[maxI] + 1)
						return (minI, maxI - 1);
				}
				return (minI, indexes.Count);
			}
		}
		return null;
	}

	public static IEnumerable<int> CountCharPerCol(this IEnumerable<string> values, char charToCount)
	{
		var counts = new int[values.First().Length];

		foreach (var line in values)
		{
			for (int i = 0; i < line.Length; i++)
				if (line[i] == charToCount)
					counts[i]++;
		}
		return counts.Reverse();
	}

}