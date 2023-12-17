﻿
using static DayRunner;


// var day1example1 = @"1abc2
// pqr3stu8vwx
// a1b2c3d4e5f
// treb7uchet";

// var day1example2 = @"two1nine
// eightwothree
// abcone2threexyz
// xtwone3four
// 4nineeightseven2
// zoneight234
// 7pqrstsixteen";

// var day1Input = File.ReadAllText("inputs/day1.txt");

// // Day1.Part1(day1example1);
// // Day1.Part1(day1Input);
// // Day1.Part2(day1example2);
// Day1.Part2(day1Input);

// var day2example1 = @"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
// Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
// Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
// Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
// Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";


// // var day2Answer = Day2.Part1(day2example1);
// var day2Answer = Day2.Part2(File.ReadAllText("inputs/day2.txt"));
// Console.WriteLine($"Day2 Part2: {day2Answer}");


// var day3example1 = @"467..114..
// ...*......
// ..35..633.
// ......#...
// 617*......
// .....+.58.
// ..592.....
// ......755.
// ...$.*....
// .664.598..";

// // var day3answer = Day3.Part1(day3example1);
// // var day3answer = Day3.Part1(File.ReadAllText("inputs/day3.txt"));
// // var day3answer = Day3.Part2(day3example1);
// var day3answer = Day3.Part2(File.ReadAllText("inputs/day3.txt"));
// Console.WriteLine($"Day3 Part1: {day3answer}");


// var day4Example1 = @"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
// Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
// Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
// Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
// Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
// Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";


// var stopwatch = new Stopwatch();
// stopwatch.Start();

// // var day4Answer = Day4.Part2(day4Example1);
// var day4Answer = Day4.Part2(File.ReadAllText("inputs/day4.txt"));
// stopwatch.Stop();
// Console.WriteLine($"Day4 Part2: {day4Answer} in {stopwatch.ElapsedMilliseconds}ms");
// // var day4Answer = Day4.Part1(File.ReadAllText("inputs/day4.txt"));


// var day5Example1 = @"seeds: 79 14 55 13

// seed-to-soil map:
// 50 98 2
// 52 50 48

// soil-to-fertilizer map:
// 0 15 37
// 37 52 2
// 39 0 15

// fertilizer-to-water map:
// 49 53 8
// 0 11 42
// 42 0 7
// 57 7 4

// water-to-light map:
// 88 18 7
// 18 25 70

// light-to-temperature map:
// 45 77 23
// 81 45 19
// 68 64 13

// temperature-to-humidity map:
// 0 69 1
// 1 0 69

// humidity-to-location map:
// 60 56 37
// 56 93 4";
// var stopwatch = new Stopwatch();
// stopwatch.Start();
// // var day5answer = Day5.Part2(day5Example1);

// // var day5answerPart1 = Day5.Part1(day5Example1);
// var day5answerPart1 = Day5.Part1(File.ReadAllText("inputs/day5.txt"));
// var day5answerPart2 = Day5.Part2(File.ReadAllText("inputs/day5.txt"));
// // var day5answerPart2 = Day5.Part2(day5Example1);

// stopwatch.Stop();
// var day5myAnswerPart1 = 214922730ul;
// var day5myAnswerPart2 = 148041808ul;

// Console.WriteLine($"Day5 Part1: {day5answerPart1} in {stopwatch.ElapsedMilliseconds}ms");
// Console.WriteLine($"Day5 Part2: {day5answerPart2} in {stopwatch.ElapsedMilliseconds}ms");
// Console.WriteLine($"Day5 Part1: {day5answerPart1 == day5myAnswerPart1}");
// Console.WriteLine($"Day5 Part2: {day5answerPart2 == day5myAnswerPart2}");

// var stopwatch = new Stopwatch();
// stopwatch.Start();
// var example = @"Time:      7  15   30
// Distance:  9  40  200";

// // var day6answer = Day6.Part2(example);
// var day6answer = Day6.Part2Take2(File.ReadAllText("inputs/day6.txt"));
// stopwatch.Stop();
// Console.WriteLine($"Day6 Part2: {day6answer} in {stopwatch.ElapsedMilliseconds}ms");



// var day7example1 = @"32T3K 765
// T55J5 684
// KK677 28
// KTJJT 220
// QQQJA 483";


// var stopwatch = new Stopwatch();
// stopwatch.Start();
// // var day7answerPart1 = Day7.Part1(day7example1);
// // var day7answerPart1 = Day7.Part1(day7example2);
// // var day7answerPart1 = Day7.Part1(File.ReadAllText("inputs/day7.txt"));
// var day7answerPart2 = Day7.Part2(File.ReadAllText("inputs/day7.txt"));
// // var day7answerPart2 = Day7.Part2(day7example1);

// stopwatch.Stop();
// Console.WriteLine($"Day7 Part2: {day7answerPart2} in {stopwatch.ElapsedMilliseconds}ms");
// Console.WriteLine($"Day7 Part1: {day7answerPart1} in {stopwatch.ElapsedMilliseconds}ms");

//{(1,2),(4,5),}
// var day8example1 = @"RL

// AAA = (BBB, CCC)
// CCC = (ZZZ, GGG)
// BBB = (DDD, EEE)
// DDD = (DDD, DDD)
// EEE = (EEE, EEE)
// GGG = (GGG, GGG)
// ZZZ = (ZZZ, ZZZ)";

// var day8example2 = @"LLR

// AAA = (BBB, BBB)
// BBB = (AAA, ZZZ)
// ZZZ = (ZZZ, ZZZ)";

// var day8example3 = @"LR

// 11A = (11B, XXX)
// 11B = (XXX, 11Z)
// 11Z = (11B, XXX)
// 22A = (22B, XXX)
// 22B = (22C, 22C)
// 22C = (22Z, 22Z)
// 22Z = (22B, 22B)
// XXX = (XXX, XXX)";

// var stopwatch = new Stopwatch();
// stopwatch.Start();

// // var day8answerPart2 = Day8.Part2(day8example3);
// var day8answerPart2 = Day8.Part2(File.ReadAllText("inputs/day8.txt")); //13385272668829

// stopwatch.Stop();
// Console.WriteLine($"Day8 Part2: {day8answerPart2} in {stopwatch.ElapsedMilliseconds}ms");


// Run(Day9.Part1, "day9example1");
// Run(Day9.Part1, "day9");
// Run(Day9.Part2, "day9example1");
// Run(Day9.Part2, "day9");


// Run(Day10.Part1, "day10example1");
// Run(Day10.Part1, "day10");
// Run(Day10.Part2, "day10example2");
// Run(Day10.Part2, "day10");


// Run(Day11.Part1, "day11example1");
// Run(Day11.Part2, "day11");

// Run(Day12.Part1, "day12exampleX");
// Run(Day12.Part1, "day12example1");
// Run(Day12.Part1, "day12");   //6035 Too low

// Run(Day13.Part1, "day13test");
// Run(Day13.Part1, "day13easy");
// Run(Day13.Part1, "day13example1");
// Run(Day13.Part1, "day13example2");
// Run(Day13.Part1, "day13both");
// Run(Day13.Part1, "day13"); 

// Run(Day13.Part2, "day13easy");
// Run(Day13.Part2, "day13example1");
Run(Day13.Part2, "day13example2");