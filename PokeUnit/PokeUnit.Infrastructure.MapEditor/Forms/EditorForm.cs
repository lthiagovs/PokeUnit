using PokeUnit.Domain.GameMap.Model;
using PokeUnit.Domain.Map.Model;
using PokeUnit.Infrastructure.MapEditor.Controls;
using PokeUnit.Infrastructure.MapEditor.Core;
using PokeUnit.Infrastructure.MapEditor.Dialogs;
using PokeUnit.Services.MapGenerator.Core;

namespace PokeUnit.Infrastructure.MapEditor.Forms
{
    public partial class EditorForm : Form
    {

        private GameMap? GameMap {  get; set; }

        private void LoadTiles(int SizeX, int SizeY)
        {

            for (int y = 0; y < SizeY; y++)
            {

                for (int x = 0; x < SizeX; x++)
                {

                    MapTileControl tile = new MapTileControl();
                    tile.Location = new Point(x * tile.Size.Width, y * tile.Size.Height);
                    this.pnContent.Controls.Add(tile);

                }

            }

        }

        private bool VerifyMap()
        {
            return GameMap == null ? true : false;
        }

        private bool LoadElements()
        {

            if (VerifyMap())
            {
                MessageBox.Show("Nenhum mapa carregado...");
                return false;
            }

            if(GameMap!.Elements == null)
            {
                MessageBox.Show("Nenhum elemento carregado...");
                return false;
            }

            int count = 0;

            foreach(GameMapElement element in GameMap.Elements)
            {
                GameElementControl elementControl = new GameElementControl(element);
                elementControl.Location = new Point(elementControl.Location.X, elementControl.Height * count );
                this.pnElements.Controls.Add(elementControl);
                count++;
            }

            return true;
        }

        private void StartMapTiles()
        {

            


        }

        public EditorForm()
        {
            InitializeComponent();
            LoadTiles(50, 50);
        }

        private void btnNewMap_Click(object sender, EventArgs e)
        {
            NewMapDialog dialog = new NewMapDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                this.GameMap = GameMapGenerator.GenerateEmptyMap(50, 50);
                this.LoadElements();
            }

        }
    }
}
