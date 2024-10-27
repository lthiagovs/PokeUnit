using PokeUnit.Domain.GameMap.Model;
using PokeUnit.Domain.Map.Model;

namespace PokeUnit.Services.MapGenerator.Core
{
    public static class GameMapGenerator
    {

        private static int[][] GenerateEmptyData(int SizeX, int SizeY)
        {

            int[][] Data = new int[SizeY][];

            for(int y = 0; y < SizeY; y++)
            {

                Data[y] = new int[SizeX];

                for(int x = 0; x < SizeX; x++)
                {
                    Data[y][x] = 0;
                }

            }

            return Data;

        }

        private static List<GameMapElement> GenerateEmpytElements()
        {
            List<GameMapElement> Elements = new List<GameMapElement>();
            GameMapElement element1 = new GameMapElement()
            {
                ID = 0
            };

            Elements.Add(element1);
            return Elements;
            
        }

        private static List<GameMapElement> GenerateElementsByRange(int range)
        {
            List<GameMapElement> Elements = new List<GameMapElement>();

            for (int i = 0; i < range; i++)
            {
                GameMapElement element = new GameMapElement()
                {
                    ID = i
                };
                Elements.Add(element);
            }
            return Elements;
        }

        public static GameMap GenerateEmptyMap(int SizeX, int SizeY)
        {
            GameMap newMap = new GameMap()
            {
                Name = "Example_Map",
                Description = "This map is empty for testing purposes.",
                Elements = GenerateEmpytElements(),
                Data = GenerateEmptyData(SizeX, SizeY),
            };

            return newMap;

        }

        public static GameMap GenerateEmptyMap(int SizeX, int SizeY, int Range)
        {
            GameMap newMap = new GameMap()
            {
                Name = "Example_Map",
                Description = "This map is empty for testing purposes.",
                Elements = GenerateElementsByRange(Range),
                Data = GenerateEmptyData(SizeX, SizeY),
            };

            return newMap;

        }

    }

}
