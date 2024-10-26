using PokeUnit.Domain.GameMap.Model;
using PokeUnit.Services.MapGenerator.Core;
using PokeUnit.Services.MapManager.Core;

GameMap map = GameMapGenerator.GenerateEmptyMap(50, 50);
MapWriter.SaveMap(map);
Console.WriteLine("Map 50x50 created!");