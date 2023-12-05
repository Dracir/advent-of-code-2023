
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


var day3example1 = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";

// var day3answer = Day3.Part1(day3example1);
// var day3answer = Day3.Part1(File.ReadAllText("inputs/day3.txt"));
// var day3answer = Day3.Part2(day3example1);
var day3answer = Day3.Part2(File.ReadAllText("inputs/day3.txt"));
Console.WriteLine($"Day3 Part1: {day3answer}");