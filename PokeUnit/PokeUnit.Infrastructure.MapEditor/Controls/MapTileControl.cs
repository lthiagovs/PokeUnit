using PokeUnit.Domain.Map.Model;
using PokeUnit.Infrastructure.MapEditor.Core;

namespace PokeUnit.Infrastructure.MapEditor.Controls
{
    public partial class MapTileControl : UserControl
    {

        private GameMapElement? _element { get; set; }

        public MapTileControl()
        {
            InitializeComponent();
            this.BackColor = Color.CornflowerBlue;
        }

        private void SetImage(Image? img)
        {
            this.pbSprite.Image = img;
            this.pbSprite.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSprite_MouseEnter(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.None;
            if (EditorManager._selectedElement != null)
                SetImage(ElementManager.LoadElement(EditorManager._selectedElement.ID));
        }

        private void pbSprite_MouseLeave(object sender, EventArgs e)
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            if(this._element == null)
                SetImage(null);
            else
                SetImage(ElementManager.LoadElement(this._element.ID));
        }

        private void pbSprite_Click(object sender, EventArgs e)
        {
            if (EditorManager._selectedElement != null)
            {
                this._element = EditorManager._selectedElement;
                SetImage(ElementManager.LoadElement(this._element.ID));
            }
                
        }
    }
}
