using Data;
using Data.DTOs;

try
{
	Console.WriteLine("Technische test");
	Console.Write("Give the path to the inputfile, just enter if you want the default one.");
	var filePath = string.IsNullOrWhiteSpace(Console.ReadLine()?.Trim()) ? Path.Combine(AppContext.BaseDirectory,"files", "input.txt") : Console.ReadLine()?.Trim();
	if (string.IsNullOrEmpty(filePath)) throw new FileNotFoundException();
	Console.Write("Give the length of the word, just enter for default one '6'");
	if (!int.TryParse(Console.ReadLine(), out var lengthWord))
	{
		lengthWord = 6;
	}

	Console.Write("Give the maximum combination length, just enter for default one '3'");
	if (!int.TryParse(Console.ReadLine(), out var maxCombination))
	{
		maxCombination = 3;
	}

	HashSet<WordDTO> wordDTOs = new FileReader(filePath).Words();
	var result = new WordSearcher(wordDTOs);
	Dictionary<string, WordDTO> combinations = result.Combinations(lengthWord, maxCombination);
	Console.WriteLine("Result of 3 combinations");
	foreach(var combination in combinations)
	{
		Console.WriteLine($"{combination.Key}={combination.Value.Word}");
	}
}
catch (Exception)
{
	throw;
}