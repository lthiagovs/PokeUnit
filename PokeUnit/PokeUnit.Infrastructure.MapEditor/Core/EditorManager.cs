using PokeUnit.Domain.GameMap.Model;
using PokeUnit.Domain.Map.Model;

namespace PokeUnit.Infrastructure.MapEditor.Core
{
    public static class EditorManager
    {

        public static GameMap? _loadedMap {  get; set; }

        public static GameMapElement? _selectedElement {  get; set; }

    }

}
