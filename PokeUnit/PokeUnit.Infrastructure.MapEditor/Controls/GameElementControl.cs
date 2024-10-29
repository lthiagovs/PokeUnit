using PokeUnit.Domain.Map.Model;
using PokeUnit.Infrastructure.MapEditor.Core;

namespace PokeUnit.Infrastructure.MapEditor.Controls
{
    public partial class GameElementControl : UserControl
    {

        private readonly GameMapElement _element;

        public GameElementControl(GameMapElement element)
        {
            InitializeComponent();
            this._element = element;
            this.pbSprite.Image = ElementManager.LoadElement(this._element.ID);
            this.pbSprite.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbSprite_MouseEnter(object sender, EventArgs e)
        {
            this.pbSprite.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbSprite_MouseLeave(object sender, EventArgs e)
        {
            this.pbSprite.BorderStyle = BorderStyle.None;
        }

        private void pbSprite_Click(object sender, EventArgs e)
        {
            EditorManager._selectedElement = this._element;
        }
    }
}
