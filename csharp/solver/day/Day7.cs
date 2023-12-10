using AocUtils;


public static class Day7
{
	class HandComparer : IComparer<((int[] Cards, ulong Bid) hand, HandType handType)>
	{
		public int Compare(((int[] Cards, ulong Bid) hand, HandType handType) hand1, ((int[] Cards, ulong Bid) hand, HandType handType) hand2)
		{
			if (hand1.handType > hand2.handType)
				return 1;
			else if (hand1.handType < hand2.handType)
				return -1;
			else
			{
				var h1AsSpan = hand1.hand.Cards.AsSpan();
				var h2AsSpan = hand2.hand.Cards.AsSpan();

				var commonLength = h1AsSpan.CommonPrefixLength(h2AsSpan);
				if (commonLength == 5)
					return 0;
				else if (hand1.hand.Cards[commonLength] > hand2.hand.Cards[commonLength])
					return 1;
				else
					return -1;
			}
		}
	}

	public static ulong Part1(string input)
	{
		return input
			.Split("\n")
			.Select(x => ParseHand(x, CardNameToValue))
			.Select(hand => (hand, ScoreHand(hand)))
			.OrderBy(scoredHand => scoredHand, new HandComparer())
			.ForEach(PrintMyHand)
			.Select((scoredHand, index) => (ulong)(index + 1) * scoredHand.hand.Bid)
			.Sum();
	}

	private static void PrintMyHand(((int[] Cards, ulong Bid) hand, HandType) scoredHand)
	{
		Console.WriteLine($"{scoredHand.hand.Cards.GetPrintStr()} - {scoredHand.hand.Bid} - {scoredHand.Item2}");
	}

	private static HandType ScoreHand((int[] Cards, ulong Bid) hand)
	{
		var groupedByCardNumber = hand.Cards.GroupBy(x => x).ToList();
		var maxCount = groupedByCardNumber.Max(x => x.Count());
		return (groupedByCardNumber.Count, maxCount) switch
		{
			(1, 5) => HandType.FiveOfAKind,
			(2, 4) => HandType.FourOfAKind,
			(2, 3) => HandType.FullHouse,
			(3, 3) => HandType.ThreeOfAKind,
			(3, 2) => HandType.TwoPair,
			(4, 2) => HandType.Pair,
			(5, 1) => HandType.HighCard,
			_ => throw new Exception("Invalid hand")
		};
	}

	private static (int[] Cards, ulong Bid) ParseHand(string arg1, Func<char, int> nameToValue)
	{
		var split = arg1.Split(" ");

		var cards = split[0].Select(nameToValue).ToArray();
		var bid = ulong.Parse(split[1]);

		return (cards, bid);
	}

	private static int CardNameToValue(char name) => name switch
	{
		'T' => 10,
		'J' => 11,
		'Q' => 12,
		'K' => 13,
		'A' => 14,
		_ => name - '0'
	};

	private static int CardNameToValuePart2(char name) => name switch
	{
		'T' => 10,
		'J' => 1,
		'Q' => 12,
		'K' => 13,
		'A' => 14,
		_ => name - '0'
	};

	public static ulong Part2(string input)
	{
		return input
			.Split("\n")
			.Select(x => ParseHand(x, CardNameToValuePart2))
			.Select(hand => (hand, ScoreHandPart2(hand)))
			.OrderBy(scoredHand => scoredHand, new HandComparer())
			.ForEach(PrintMyHand)
			.Select((scoredHand, index) => (ulong)(index + 1) * scoredHand.hand.Bid)
			.Sum();
	}

	private static HandType ScoreHandPart2((int[] Cards, ulong Bid) hand)
	{
		var nonWild = hand.Cards.Where(x => x != 1).ToArray();
		var nbJokers = hand.Cards.Length - nonWild.Length;

		if (nbJokers == 5)
			return HandType.FiveOfAKind;

		var groupedByCardNumber = nonWild.GroupBy(x => x).Select(x => (value: x.Key, count: x.Count())).ToList();
		var bigestgroup = groupedByCardNumber.MaxBy(x => x.count);
		groupedByCardNumber[bigestgroup.Index] = (groupedByCardNumber[bigestgroup.Index].value, groupedByCardNumber[bigestgroup.Index].count + nbJokers);

		var maxCount = groupedByCardNumber.Max(x => x.count);
		return (groupedByCardNumber.Count, maxCount) switch
		{
			(1, 5) => HandType.FiveOfAKind,
			(2, 4) => HandType.FourOfAKind,
			(2, 3) => HandType.FullHouse,
			(3, 3) => HandType.ThreeOfAKind,
			(3, 2) => HandType.TwoPair,
			(4, 2) => HandType.Pair,
			(5, 1) => HandType.HighCard,
			_ => throw new Exception("Invalid hand")
		};
	}


	public enum HandType
	{
		HighCard = 1,
		Pair = 2,
		TwoPair = 3,
		ThreeOfAKind = 4,
		FullHouse = 5,
		FourOfAKind = 6,
		FiveOfAKind = 7,
	}
}