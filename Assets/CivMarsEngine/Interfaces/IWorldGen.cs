
using BasicUtility.TileMap;

namespace CivMarsEngine
{
	public interface IWorldGen
	{
		void Generate(System.Random r, TileMap map);
	}
}