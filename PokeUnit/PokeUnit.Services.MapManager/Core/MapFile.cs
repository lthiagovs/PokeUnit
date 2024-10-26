using Newtonsoft.Json;
using PokeUnit.Domain.GameMap.Model;
using System.Text.Json.Serialization;

namespace PokeUnit.Services.MapManager.Core
{
    public static class MapFile
    {

        public static readonly string MapDirectory = "Maps";
        public static readonly string MapExtension = ".json";

        public static void VerifyMapDirectory()
        {
            if (!Directory.Exists(MapDirectory))
                Directory.CreateDirectory(MapDirectory);
        }
        
        public static string GetMapPath(GameMap map)
        {
            return Path.Combine(MapDirectory, (map.Name + MapExtension));
        }

        public static string GetMapPath(string mapName)
        {
            return Path.Combine(MapDirectory, (mapName + MapExtension));
        }

        public static GameMap? ConvertToMap(string json)
        {

            return JsonConvert.DeserializeObject<GameMap>(json);

        }

        public static string? ConvertToJson(GameMap map)
        {

            if(map == null)
                return null;

            string? json = JsonConvert.SerializeObject(map);

            return json;

        }

    }

}
