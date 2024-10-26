using PokeUnit.Domain.GameMap.Model;

namespace PokeUnit.Services.MapManager.Core
{
    public class MapWriter
    {

        public static bool SaveMap(GameMap map)
        {

            MapFile.VerifyMapDirectory();

            if (map == null) 
                return false;

            string? json = MapFile.ConvertToJson(map);
            string path = MapFile.GetMapPath(map);

            if(json == null) 
                return false;

            File.WriteAllText(path, json);

            return true;

        }

    }

}
