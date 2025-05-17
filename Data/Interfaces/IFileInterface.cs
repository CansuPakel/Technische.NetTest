using Data.DTOs;

namespace Data.Interfaces
{
	public interface IFileInterface
	{
		HashSet<WordDTO> Words();
	}
}
