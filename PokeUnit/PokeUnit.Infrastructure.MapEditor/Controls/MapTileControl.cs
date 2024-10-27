using PokeUnit.Domain.Map.Model;
using PokeUnit.Infrastructure.MapEditor.Core;

namespace PokeUnit.Infrastructure.MapEditor.Controls
{
    public partial class MapTileControl : UserControl
    {

        public GameMapElement? _element { get; set; }
        public int PosX { get; set; }

        public int PosY { get; set; }

        public MapTileControl(int PosX, int PosY)
        {
            InitializeComponent();
            this.BackColor = Color.CornflowerBlue;
            this.PosX = PosX;
            this.PosY = PosY;
            if (EditorManager._loadedMap != null)
            {
                int elementIndex = EditorManager._loadedMap.Data[this.PosY][this.PosX];
                this._element = EditorManager._loadedMap.Elements![elementIndex];
                SetImage(ElementManager.LoadElement(elementIndex));
            }
        }

        public void SetImage(Image? img)
        {
            this.pbSprite.Image = img;
            this.pbSprite.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
