namespace test;
using Shouldly;

public class Day12Tests
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void Example1_ShouldReturn1()
	{
		var line = "???.### 1,1,3";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(1);
	}

	[Test]
	public void Example2_ShouldReturn4()
	{
		var line = ".??..??...?##. 1,1,3";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(4);
	}

	[Test]
	public void Example3_ShouldReturn1()
	{
		var line = "?#?#?#?#?#?#?#? 1,3,1,6";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(1);
	}

	[Test]
	public void Example4_ShouldReturn1()
	{
		var line = "????.#...#... 4,1,1";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(1);
	}

	[Test]
	public void Example5_ShouldReturn4()
	{
		var line = "????.######..#####. 1,6,5";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(4);
	}

	[Test]
	public void Example6_ShouldReturn10()
	{
		var line = "?###???????? 3,2,1";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(10);
	}



	[Test]
	public void Test1()
	{
		var line = "?#??#?#???#????#??#? 13,4";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(2);
	}

	[Test]
	public void TestWith1BrokenInMiddle_AndSizeOf1And1()
	{
		var line = ".??#??? 1,1";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(3);
	}

	[Test]
	public void TestWith3BrokenInMiddle_AndSizeOf3()
	{
		var line = "?###? 3";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(1);
	}

	[Test]
	public void EndingSizeOf3()
	{
		var line = ".??## 3";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(1);
	}

	[Test]
	public void BOB()
	{
		var line = ".???## 1,3";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(1);
	}

	[Test]
	public void BOB2()
	{
		var line = ".???#? 1,3";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(1);
	}

	[Test]
	public void BOB3()
	{
		var line = ".????#? 2,2";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(3);
	}

	[Test]
	public void Test3()
	{
		var line = "#.???#???.????#???# 1,5,1,1,2,1";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(9);
	}


	[Test]
	public void Test3_WithoutFirst1()
	{
		var line = "???#???.????#???# 5,1,1,2,1";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(9);
	}
	[Test]
	public void Test3_Subtest()
	{
		var line = "???#?.?.????#???# 5,1,1,2,1";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(7);
	}


	[Test]
	public void Test3_LeftPart()
	{
		var line = "#.???#??? 1,5";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(3);
	}


	[Test]
	public void Test3_RightPart()
	{
		var line = "????#???# 1,1,2,1";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(1);
	}


	[Test]
	public void Test4()
	{
		var line = "?#.???.???.##?#?. 1,1,1,1,5";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(5);
	}

	[Test]
	public void Test5()
	{
		var line = "????#???????? 5,1,1";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(5);
	}

	[Test]
	public void Test5_FirstFives()
	{
		var line = "#####.??????? 5,1,1";
		var (springCondition, contiguousDamaged) = Day12.ParseInputLine(line);
		var result = Day12.GetArrangements(springCondition, contiguousDamaged);
		result.ShouldBe(15);
	}

}