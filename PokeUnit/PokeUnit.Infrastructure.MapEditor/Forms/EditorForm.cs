using PokeUnit.Infrastructure.MapEditor.Controls;

namespace PokeUnit.Infrastructure.MapEditor.Forms
{
    public partial class EditorForm : Form
    {

        private void LoadTiles(int SizeX, int SizeY)
        {
            
            for(int y = 0;y<SizeY;y++)
            {

                for(int x = 0;x<SizeX;x++)
                {

                    MapTileControl tile = new MapTileControl();
                    tile.Location = new Point(x * tile.Size.Width, y * tile.Size.Height);
                    this.pnContent.Controls.Add(tile);

                }

            }

        }

        public EditorForm()
        {
            InitializeComponent();
            LoadTiles(50,50);
        }



    }
}
