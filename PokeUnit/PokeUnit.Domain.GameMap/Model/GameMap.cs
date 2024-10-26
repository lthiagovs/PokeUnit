﻿using PokeUnit.Domain.Map.Model;

namespace PokeUnit.Domain.GameMap.Model
{
    public class GameMap
    {

        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public int[][]? Data { get; set; }

        public List<GameMapElement>? Elements { get; set; }

    }

}
