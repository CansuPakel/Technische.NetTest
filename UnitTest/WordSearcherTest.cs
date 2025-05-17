using Data;
using Data.DTOs;

namespace UnitTest
{
	public class WordSearcherTest
	{
		[Fact]
		public void CombinationTest()
		{
			var words = new HashSet<WordDTO>
			{
				new() { Word = "rij" },
				new() { Word = "ie" },
				new() { Word = "ab" },
				new() { Word = "den" },
				new() { Word = "koffie" },
				new() { Word = "sen" },
				new() { Word ="rijden" },
				new() { Word = "dansen" },
				new() { Word = "kof" },
				new() { Word = "mensen" },
				new() { Word = "men" },
				new() { Word = "spelen" },
			};

			var searcher = new WordSearcher(words);
			Dictionary<string, WordDTO> results = searcher.Combinations(6, 2);
			Assert.Contains(results, r => r.Value.Word == "rijden");
			Assert.Contains(results, r => r.Value.Word == "mensen");
		}
	}
}
