using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PokeUnit.Domain.GameMap.Model;
using PokeUnit.Domain.Map.Model;
using PokeUnit.Infrastructure.MapEditor.Controls;
using PokeUnit.Infrastructure.MapEditor.Core;
using PokeUnit.Infrastructure.MapEditor.Dialogs;
using PokeUnit.Services.MapGenerator.Core;
using PokeUnit.Services.MapManager.Core;
using System.Drawing.Drawing2D;

namespace PokeUnit.Infrastructure.MapEditor.Forms
{
    public partial class EditorForm : Form
    {

        private float scale = 1f;
        private List<MapTile> tiles = new List<MapTile>();
        private readonly int tileSize = 48;
        private bool isPainting = false;

        private void LoadTiles(int SizeX, int SizeY)
        {

            for (int y = 0; y < SizeY; y++)
            {

                for (int x = 0; x < SizeX; x++)
                {

                    MapTile tile = new MapTile(x,y);
                    tile.LocationX = x * tileSize;
                    tile.LocationY = y * tileSize;
                    this.tiles.Add(tile);

                }

            }

        }

        private bool VerifyMap()
        {
            return EditorManager._loadedMap == null ? true : false;
        }

        private bool LoadElements()
        {

            if (VerifyMap())
            {
                MessageBox.Show("Nenhum mapa carregado...");
                return false;
            }

            if (EditorManager._loadedMap!.Elements == null)
            {
                MessageBox.Show("Nenhum elemento carregado...");
                return false;
            }

            int count = 0;

            foreach (GameMapElement element in EditorManager._loadedMap.Elements)
            {
                GameElementControl elementControl = new GameElementControl(element);
                elementControl.Location = new Point(elementControl.Location.X, elementControl.Height * count);
                this.pnElements.Controls.Add(elementControl);
                count++;
            }

            LoadImages();

            return true;
        }

        private bool LoadImages()
        {

            if (EditorManager._loadedMap == null || EditorManager._loadedMap.Elements == null)
                return false;

            EditorManager._loadedImages = new List<Image>();

            foreach (GameMapElement element in EditorManager._loadedMap.Elements)
            {
                Image? img = ElementManager.LoadElement(element.ID);
                if (img != null)
                    EditorManager._loadedImages.Add(img);
            }

            return true;

        }

        private void NewMap(int X, int Y)
        {
            tiles.Clear();
            this.pnContent.Invalidate();
            EditorManager._loadedMap = GameMapGenerator.GenerateEmptyMap(X, Y, 3);
            this.LoadElements();
            this.LoadTiles(X, Y);
        }

        private void LoadMap(GameMap map)
        {
            tiles.Clear();
            this.pnElements.Controls.Clear();
            EditorManager._loadedMap = map;
            this.LoadElements();
            this.LoadTiles(map.SizeX, map.SizeY);
            this.pnContent.Invalidate();
            this.pnElements.Invalidate();
        }

        public EditorForm()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.pnContent.BackColor = Color.Black;
            NewMap(20, 20);
        }

        private void btnNewMap_Click(object sender, EventArgs e)
        {
            NewMapDialog dialog = new NewMapDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int X = Convert.ToInt32(dialog.nSizeX.Value);
                int Y = Convert.ToInt32(dialog.nSizeY.Value);
                NewMap(X, Y);
            }

        }

        private void ZoomOut()
        {
            scale /= 2f;
            pnContent.Invalidate();
        }

        private void ZoomIn()
        {
            scale *= 2f;
            pnContent.Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            switch (keyData)
            {
                case Keys.Left:
                    ZoomOut();
                    break;
                case Keys.Right:
                    ZoomIn();
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pnContent_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            g.ScaleTransform(this.scale, this.scale);

            foreach (MapTile tile in tiles)
            {

                Rectangle rect = new Rectangle(
                    (int)(tile.PosX * tileSize * scale),
                    (int)(tile.PosY * tileSize * scale),
                    (int)(tileSize * scale),
                    (int)(tileSize * scale)
                );
                if (tile.Sprite != null)
                    g.DrawImage(tile.Sprite, rect);
                else
                    g.FillRectangle(Brushes.Gray, rect);
            }
        }

        private void PaintTile(int X, int Y)
        {
            float mouseX = X / this.scale;
            float mouseY = Y / this.scale;

            float scaledTileSize = tileSize * scale; // Pre-calcula o tamanho do tile escalado

            foreach (MapTile tile in tiles)
            {
                float tileX = tile.PosX * scaledTileSize;
                float tileY = tile.PosY * scaledTileSize;

                RectangleF tileRect = new RectangleF(tileX, tileY, scaledTileSize, scaledTileSize);

                if (tileRect.Contains(mouseX, mouseY))
                {
                    if (EditorManager._selectedElement != null && EditorManager._loadedImages != null)
                    {

                        EditorManager._loadedMap!.Data![tile.PosY][tile.PosX] = EditorManager._selectedElement.ID;
                        tile.ElementID = EditorManager._selectedElement.ID;
                        tile.Sprite = EditorManager._loadedImages[tile.ElementID];


                        using (Graphics g = pnContent.CreateGraphics())
                        {
                            g.InterpolationMode = InterpolationMode.NearestNeighbor;
                            g.DrawImage(tile.Sprite, tileRect);
                        }
                    }
                    break;
                }
            }
        }

        private void pnContent_MouseDown(object sender, MouseEventArgs e)
        {
            this.isPainting = true;
        }

        private void pnContent_MouseUp(object sender, MouseEventArgs e)
        {
            this.isPainting = false;
        }

        private void pnContent_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPainting)
                PaintTile(e.X, e.Y);
        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
            if (EditorManager._loadedMap != null)
            {
                SaveMapDialog dialog = new SaveMapDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    EditorManager._loadedMap.Name = dialog.txtName.Text;
                    EditorManager._loadedMap.Description = dialog.txtDescription.Text;
                    MapWriter.SaveMap(EditorManager._loadedMap);
                    MessageBox.Show("Map saved!");
                }
            }
            else
            {
                MessageBox.Show("Load a map first...");
            }
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    try
                    {
                        string jsonContent = File.ReadAllText(filePath);

                        GameMap? openMap = JsonConvert.DeserializeObject<GameMap>(jsonContent);

                        if (openMap != null)
                        {
                            MessageBox.Show("Map loaded!");
                            LoadMap(openMap);
                        }
                        else
                        {
                            MessageBox.Show("Error when loading map...");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error when opening the file: {ex.Message}", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
