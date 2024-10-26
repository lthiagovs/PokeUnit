using System.Runtime.CompilerServices;

namespace PokeUnit.Infrastructure.MapEditor.Controls
{
    public partial class MapTileControl : UserControl
    {

        public MapTileControl()
        {
            InitializeComponent();
            this.BackColor = Color.CornflowerBlue;
        }

        private void MapTileControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGreen;
        }

        private void MapTileControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.CornflowerBlue;
        }

        private void MapTileControl_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
