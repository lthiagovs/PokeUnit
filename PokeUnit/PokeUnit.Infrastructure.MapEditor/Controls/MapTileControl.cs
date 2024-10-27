using PokeUnit.Domain.Map.Model;
using PokeUnit.Infrastructure.MapEditor.Core;

namespace PokeUnit.Infrastructure.MapEditor.Controls
{
    public partial class MapTileControl : UserControl
    {

        public GameMapElement? _element { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        public MapTileControl()
        {
            InitializeComponent();
            this.BackColor = Color.CornflowerBlue;
        }

        public void SetImage(Image? img)
        {
            this.pbSprite.Image = img;
            this.pbSprite.SizeMode = PictureBoxSizeMode.StretchImage;
        }

    }
}
