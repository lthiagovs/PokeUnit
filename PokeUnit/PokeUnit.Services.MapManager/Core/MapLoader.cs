using PokeUnit.Domain.GameMap.Model;

namespace PokeUnit.Services.MapManager.Core
{
    public static class MapLoader
    {

        public static GameMap? LoadMap(string mapName)
        {
            MapFile.VerifyMapDirectory();

            GameMap? map = null;
            string path = MapFile.GetMapPath(mapName);
            
            string? json = File.ReadAllText(path);

            if (json != null)
                map = MapFile.ConvertToMap(json);

            return map;

        }

    }

}
