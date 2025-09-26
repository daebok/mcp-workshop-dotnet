
using System;
using System.Collections.Generic;

class Program
{
	static readonly List<string> AsciiArts = new List<string>
	{
		@"  (o o)   ",
		@" ( . . )  ",
		@" (='.'=)  ",
	@" (._.)    ",
		@" (o^.^o)   ",
		@" (>'-'<)   "
	};

	static void Main()
	{
		// MCP 서버에서 받은 원숭이 데이터 샘플 (실제 연동 시 MonkeyHelper.LoadMonkeys 호출)
		var monkeys = new List<Monkey>
		{
			new Monkey { Name = "Baboon", Location = "Africa & Asia", Population = 10000, Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio, part of the subfamily Cercopithecinae." },
			new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Population = 23000, Details = "The capuchin monkeys are New World monkeys of the subfamily Cebinae." },
			new Monkey { Name = "Blue Monkey", Location = "Central and East Africa", Population = 12000, Details = "The blue monkey or diademed monkey is a species of Old World monkey native to Central and East Africa." },
			new Monkey { Name = "Squirrel Monkey", Location = "Central & South America", Population = 11000, Details = "The squirrel monkeys are the New World monkeys of the genus Saimiri." },
			new Monkey { Name = "Golden Lion Tamarin", Location = "Brazil", Population = 19000, Details = "The golden lion tamarin also known as the golden marmoset, is a small New World monkey of the family Callitrichidae." }
		};
		MonkeyHelper.LoadMonkeys(monkeys);

		var random = new Random();
		while (true)
		{
			Console.Clear();
			// 랜덤 ASCII 아트 출력
			Console.WriteLine(AsciiArts[random.Next(AsciiArts.Count)]);
			Console.WriteLine("============================");
			Console.WriteLine(" Monkey Console Application ");
			Console.WriteLine("============================");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");
			var input = Console.ReadLine();
			Console.WriteLine();

			switch (input)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					GetMonkeyByName();
					break;
				case "3":
					GetRandomMonkey();
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}
	}

	static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		Console.WriteLine("| Name                | Location                | Population |");
		Console.WriteLine("-------------------------------------------------------------");
		foreach (var m in monkeys)
		{
			Console.WriteLine($"| {m.Name,-19} | {m.Location,-22} | {m.Population,9} |");
		}
	}

	static void GetMonkeyByName()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);
		if (monkey != null)
		{
			Console.WriteLine($"Name: {monkey.Name}");
			Console.WriteLine($"Location: {monkey.Location}");
			Console.WriteLine($"Population: {monkey.Population}");
			Console.WriteLine($"Details: {monkey.Details}");
		}
		else
		{
			Console.WriteLine("Monkey not found.");
		}
	}

	static void GetRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		if (monkey != null)
		{
			Console.WriteLine($"Random Monkey: {monkey.Name}");
			Console.WriteLine($"Location: {monkey.Location}");
			Console.WriteLine($"Population: {monkey.Population}");
			Console.WriteLine($"Details: {monkey.Details}");
			Console.WriteLine($"(Random pick count: {MonkeyHelper.GetRandomPickCount()})");
		}
		else
		{
			Console.WriteLine("No monkeys available.");
		}
	}
}
