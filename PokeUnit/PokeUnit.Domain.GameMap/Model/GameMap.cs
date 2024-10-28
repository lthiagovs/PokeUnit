using PokeUnit.Domain.Map.Event;
using PokeUnit.Domain.Map.Model;

namespace PokeUnit.Domain.GameMap.Model
{
    public class GameMap
    {

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public int SizeX {  get; set; }

        public int SizeY { get; set; }

        public int[][]? Data { get; set; }

        public List<GameMapElement>? Elements { get; set; }

        public List<GameEvent>? Events {  get; set; }

    }

}
