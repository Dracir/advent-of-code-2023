﻿
using System.Diagnostics;

Console.WriteLine("Hello, World!");


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
// var day5answer = Day5.Part2(File.ReadAllText("inputs/day5.txt"));

// stopwatch.Stop();
// Console.WriteLine($"Day5 Part2: {day5answer} in {stopwatch.ElapsedMilliseconds}ms");


var stopwatch = new Stopwatch();
stopwatch.Start();
var example = @"Time:      7  15   30
Distance:  9  40  200";

// var day6answer = Day6.Part2(example);
var day6answer = Day6.Part2Take2(File.ReadAllText("inputs/day6.txt"));
stopwatch.Stop();
Console.WriteLine($"Day6 Part2: {day6answer} in {stopwatch.ElapsedMilliseconds}ms");

