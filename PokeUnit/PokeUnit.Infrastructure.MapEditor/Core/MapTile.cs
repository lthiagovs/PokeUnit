namespace PokeUnit.Infrastructure.MapEditor.Core
{
    public class MapTile
    {

        public int PosX {  get; set; }

        public int PosY { get; set; }

        public int LocationX {  get; set; }

        public int LocationY {  get; set; }

        public int Width {  get; set; }

        public int Height { get; set; }

        public int ElementID {  get; set; }

        public Image? Sprite {  get; set; }

        public MapTile(int PosX, int PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            if (EditorManager._loadedMap != null && EditorManager._loadedMap.Data != null)
            {
                this.ElementID =  EditorManager._loadedMap.Data[this.PosY][this.PosX];
                this.Sprite = ElementManager.LoadElement(this.ElementID);
            }
        }

    }
}
