using Data.DTOs;

namespace Data.Interfaces
{
	public interface IWordInterface
	{
		Dictionary<string, WordDTO> Combinations(int lengthWord, int maxCombination);
	}
}
