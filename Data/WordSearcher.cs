using Data.DTOs;
using Data.Interfaces;

namespace Data
{
	public class WordSearcher : IWordInterface
	{
		private Dictionary<string, WordDTO> _results = [];
		private List<WordDTO> _words;
		private HashSet<string> _wordsSet;
		private Dictionary<int, List<WordDTO>> _wordsByLength;
		private int _targetLength;
		private int _maxCombination;

		public WordSearcher(HashSet<WordDTO> words)
		{
			_words = [.. words];
			_wordsSet = [.. words.Select(w => w.Word)];
		}


		public Dictionary<string, WordDTO> Combinations(int targetLength, int maxCombination)
		{
			var filteredWords = _words.Where(w => w.Word.Length <= targetLength).ToList();
			_wordsByLength = filteredWords.GroupBy(w => w.Word.Length).ToDictionary(g => g.Key, g => g.ToList());
			_targetLength = targetLength;
			_maxCombination = maxCombination;
			FindCombinations([], 0);
			return _results;
		}

		private void FindCombinations(List<WordDTO> currentCombo, int currentLength)
		{
			try
			{

				if (_results.Count >= _maxCombination) return;
				if (currentLength > _targetLength) return;
				if (currentLength == _targetLength)
				{
					string combined = string.Concat(currentCombo.Select(w => w.Word));
					if (_wordsSet.Contains(combined))
					{
						string key = string.Join("+", currentCombo.Select(w => w.Word));
						if (!_results.ContainsKey(key))
						{
							_results[key] = new WordDTO { Word = combined };
							if (_results.Count >= _maxCombination) return;
						}
					}
					return;
				}

				foreach (var perWordLength in _wordsByLength)
				{
					int wordLength = perWordLength.Key;
					if (currentLength + wordLength > _targetLength) continue;

					foreach (var word in perWordLength.Value)
					{
						if (currentCombo.Any(w => w.Word == word.Word)) continue;
						currentCombo.Add(word);
						FindCombinations(currentCombo, currentLength + wordLength);
						currentCombo.RemoveAt(currentCombo.Count - 1);
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}