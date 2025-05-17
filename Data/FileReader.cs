using Data.DTOs;
using Data.Interfaces;

namespace Data
{
	public class FileReader : IFileInterface
	{
		private readonly string _filePath;

		public FileReader(string filePath)
		{
			if (!File.Exists(@$"{filePath}")) throw new FileNotFoundException($"File not found: {filePath}");
			_filePath = filePath;
		}

		public HashSet<WordDTO> Words()
		{
			try
			{

				return [.. File.ReadAllLines(_filePath)
					   .Where(line => !string.IsNullOrWhiteSpace(line))
					   .Select(line => new WordDTO{ Word = line.Trim().ToLower() })];
			}
			catch
			{
				throw;
			}
		}
	}
}
