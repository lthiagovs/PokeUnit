using Newtonsoft.Json;
using PokeUnit.Domain.GameMap.Model;
using PokeUnit.Domain.Map.Event;
using PokeUnit.Domain.Map.Model;
using PokeUnit.Infrastructure.MapEditor.Controls;
using PokeUnit.Infrastructure.MapEditor.Core;
using PokeUnit.Infrastructure.MapEditor.Dialogs;
using PokeUnit.Infrastructure.MapEditor.Services;
using PokeUnit.Services.MapGenerator.Core;
using PokeUnit.Services.MapManager.Core;
using System.Drawing.Drawing2D;

namespace PokeUnit.Infrastructure.MapEditor.Forms
{
    public partial class EditorForm : Form
    {
        private BufferedGraphicsContext? tilesBufferedContext;
        private BufferedGraphics? tilesBufferedGraphics;
        private BufferedGraphicsContext? mapBufferedContext;
        private BufferedGraphics? mapBufferedGraphics;
        private float scale = 1f;
        private int offsetX = 0;
        private int offsetY = 0;
        private List<MapTile> tiles = new List<MapTile>();
        private readonly int tileSize = 48;
        private bool isPainting = false;
        private readonly Color EventColor = Color.FromArgb(50, 0, 0, 255);
        private int range = 2;

        private void LoadTiles(int SizeX, int SizeY)
        {

            for (int y = 0; y < SizeY; y++)
            {

                for (int x = 0; x < SizeX; x++)
                {

                    MapTile tile = new MapTile(x, y);
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

        private bool IsMapLoaded()
        {
            return EditorManager._loadedMap != null ? true : false;
        }

        private bool IsEventsLoaded()
        {
            if (IsMapLoaded())
                return EditorManager._loadedMap!.Events != null ? true : false;
            return false;
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
            ResetSettings();
            tiles.Clear();
            EditorManager._loadedMap = GameMapGenerator.GenerateEmptyMap(X, Y, range);
            this.LoadElements();
            this.LoadTiles(X, Y);
            this.pnContent.Invalidate();
        }

        private void LoadMap(GameMap map)
        {
            ResetSettings();
            tiles.Clear();
            this.pnElements.Controls.Clear();
            EditorManager._loadedMap = map;
            this.LoadElements();
            this.LoadTiles(map.SizeX, map.SizeY);
            this.pnContent.Invalidate();
            this.pnElements.Invalidate();
            this.Cursor = Cursors.Default;
        }

        private void ResetSettings()
        {
            scale = 1f;
            offsetX = 0;
            offsetY = 0;
            InitializeMapBufferedGraphics();
            pnMap.Invalidate();
        }

        private void InitializeTilesBufferedGraphics()
        {
            tilesBufferedContext = BufferedGraphicsManager.Current;
            tilesBufferedGraphics?.Dispose();
            tilesBufferedGraphics = tilesBufferedContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }

        private void InitializeMapBufferedGraphics()
        {
            mapBufferedContext = BufferedGraphicsManager.Current;
            mapBufferedGraphics?.Dispose();
            mapBufferedGraphics = mapBufferedContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }

        public EditorForm()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.pnContent.BackColor = Color.Black;
            NewMap(20, 20);
            InitializeTilesBufferedGraphics();
        }

        private void btnNewMap_Click(object sender, EventArgs e)
        {
            NewMapDialog dialog = new NewMapDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                int X = Convert.ToInt32(dialog.nSizeX.Value);
                int Y = Convert.ToInt32(dialog.nSizeX.Value);
                NewMap(X, Y);
            }
            this.Cursor = Cursors.Default;
        }

        private void ZoomOut()
        {
            scale /= 2f;
            InitializeTilesBufferedGraphics();
            pnContent.Invalidate();
            this.ActiveControl = null;
        }

        private void ZoomIn()
        {
            scale *= 2f;
            InitializeTilesBufferedGraphics();
            pnContent.Invalidate();
            this.ActiveControl = null;
        }

        private void MoveTiles(GameDirection direction)
        {
            switch (direction)
            {
                case GameDirection.Left:
                    this.offsetX += tileSize;
                    break;
                case GameDirection.Right:
                    this.offsetX -= tileSize;
                    break;
                case GameDirection.Up:
                    this.offsetY += tileSize;
                    break;
                case GameDirection.Down:
                    this.offsetY -= tileSize;
                    break;
                default:
                    break;
            }
            InitializeTilesBufferedGraphics();
            pnContent.Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            switch (keyData)
            {
                case Keys.Left:
                    MoveTiles(GameDirection.Left);
                    break;
                case Keys.Right:
                    MoveTiles(GameDirection.Right);
                    break;
                case Keys.Up:
                    MoveTiles(GameDirection.Up);
                    break;
                case Keys.Down:
                    MoveTiles(GameDirection.Down);
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pnContent_Paint(object sender, PaintEventArgs e)
        {
            if (tilesBufferedGraphics == null) return;

            if (!IsEventsLoaded()) return;

            Graphics g = tilesBufferedGraphics.Graphics;
            g.Clear(Color.Black);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.ScaleTransform(this.scale, this.scale);

            foreach (MapTile tile in tiles)
            {
                Rectangle rect = new Rectangle(
                    (int)((tile.PosX * tileSize * scale) + offsetX),
                    (int)((tile.PosY * tileSize * scale) + offsetY),
                    (int)(tileSize * scale),
                    (int)(tileSize * scale)
                );

                GameEvent? findEvent = IsEvent(tile.PosX, tile.PosY);

                if (tile.Sprite != null)
                {
                    g.DrawImage(tile.Sprite, rect);
                }
                else
                {
                    g.FillRectangle(Brushes.Gray, rect);
                }

                if (findEvent != null)
                {
                    g.FillRectangle(new SolidBrush(EventColor), rect);
                }

            }
            tilesBufferedGraphics.Render(e.Graphics);
        }

        private void PaintTile(int X, int Y)
        {
            float mouseX = X / this.scale;
            float mouseY = Y / this.scale;

            float scaledTileSize = tileSize * scale;

            foreach (MapTile tile in tiles)
            {
                float tileX = tile.PosX * scaledTileSize + offsetX;
                float tileY = tile.PosY * scaledTileSize + offsetY;

                RectangleF tileRect = new RectangleF(tileX, tileY, scaledTileSize, scaledTileSize);

                if (tileRect.Contains(mouseX, mouseY))
                {
                    if (EditorManager._selectedElement != null && EditorManager._loadedImages != null)
                    {


                        RectangleF tileRegion = new RectangleF(tileX * scale, tileY * scale, scaledTileSize * scale, scaledTileSize * scale);
                        RectangleF mapRegion = new RectangleF(tile.PosX, tile.PosY, 1, 1);

                        EditorManager._loadedMap!.Data![tile.PosY][tile.PosX] = EditorManager._selectedElement.ID;
                        tile.ElementID = EditorManager._selectedElement.ID;
                        tile.Sprite = EditorManager._loadedImages[tile.ElementID];

                        GameEvent? isEvent = IsEvent(tile.PosX, tile.PosY);

                        //TEST
                        Image? brush = ElementManager.CheckBrush(EditorManager._selectedElement.ID, tile.PosX, tile.PosY);
                        if (brush != null)
                            tile.Sprite = brush;
                        //TEST

                        using (Graphics g = pnContent.CreateGraphics())
                        {
                            g.InterpolationMode = InterpolationMode.NearestNeighbor;
                            g.DrawImage(tile.Sprite, tileRegion);
                            if (isEvent != null)
                                g.FillRectangle(new SolidBrush(EventColor), mapRegion);
                        }

                        using (Graphics g = pnMap.CreateGraphics())
                        {
                            g.InterpolationMode = InterpolationMode.NearestNeighbor;
                            g.FillRectangle(GetBrush(tile.Sprite), mapRegion);
                        }


                    }
                    break;
                }
            }
        }

        private GameEvent? IsEvent(int X, int Y)
        {
            if (!IsEventsLoaded())
                return null;

            return EditorManager._loadedMap!.Events!.FirstOrDefault(ev => ev.PosX == X && ev.PosY == Y);
        }

        private void CreateEvent(int X, int Y)
        {

            if (EditorManager._loadedMap == null || EditorManager._loadedMap.Events == null)
            {
                MessageBox.Show("Load a map first");
                return;
            }

            float mouseX = X / this.scale;
            float mouseY = Y / this.scale;

            float scaledTileSize = tileSize * scale;

            foreach (MapTile tile in tiles)
            {
                float tileX = tile.PosX * scaledTileSize + offsetX;
                float tileY = tile.PosY * scaledTileSize + offsetY;

                RectangleF tileRect = new RectangleF(tileX, tileY, scaledTileSize, scaledTileSize);

                if (tileRect.Contains(mouseX, mouseY))
                {


                    MapEventDialog dialog = new MapEventDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {

                        RectangleF tileRegion = new RectangleF(tileX * scale, tileY * scale, scaledTileSize * scale, scaledTileSize * scale);

                        using (Graphics g = pnContent.CreateGraphics())
                        {
                            g.InterpolationMode = InterpolationMode.NearestNeighbor;
                            g.FillRectangle(new SolidBrush(EventColor), tileRegion);
                        }

                        GameEvent newEvent = new GameEvent();
                        newEvent.ID = Convert.ToInt32(dialog.nbEvent.Value);
                        newEvent.PosX = tile.PosX;
                        newEvent.PosY = tile.PosY;
                        EditorManager._loadedMap.Events.Add(newEvent);
                        MessageBox.Show("Event created!");

                    }

                    break;

                }
            }
        }

        private void pnContent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CreateEvent(e.X, e.Y);
            else
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
            this.Cursor = Cursors.WaitCursor;
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
            this.Cursor = Cursors.Default;
        }

        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
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
            this.Cursor = Cursors.Default;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void pnContent_Resize(object sender, EventArgs e)
        {
            InitializeTilesBufferedGraphics();
            pnContent.Invalidate();
        }

        private Color GetColorFromImage(Image img)
        {
            using (Bitmap bitmap = new Bitmap(img))
            {
                return bitmap.GetPixel(img.Width / 2, img.Height / 2);
            }
        }

        private Color GetDominantColor(Image img)
        {
            Dictionary<Color, int> colorCount = new Dictionary<Color, int>();
            using (Bitmap bitmap = new Bitmap(img))
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);

                        if (pixelColor.A == 0) continue;

                        // Contar a cor
                        if (colorCount.ContainsKey(pixelColor))
                        {
                            colorCount[pixelColor]++;
                        }
                        else
                        {
                            colorCount[pixelColor] = 1;
                        }
                    }
                }
            }

            Color dominantColor = Color.Empty;
            int maxCount = 0;

            foreach (var kvp in colorCount)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    dominantColor = kvp.Key;
                }
            }

            return dominantColor;
        }

        private SolidBrush GetBrush(Image img)
        {
            SolidBrush mapBrush;

            if (EditorSettings.UserDominantColorOnMap)
            {
                mapBrush = new SolidBrush(GetDominantColor(img));
            }
            else
            {
                mapBrush = new SolidBrush(GetColorFromImage(img));
            }

            return mapBrush;
        }

        private void pnMap_Paint(object sender, PaintEventArgs e)
        {
            InitializeMapBufferedGraphics();
            if (mapBufferedGraphics == null) return;

            Graphics g = mapBufferedGraphics.Graphics;
            g.Clear(Color.Black);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.ScaleTransform(this.scale, this.scale);

            foreach (MapTile tile in tiles)
            {
                Rectangle rect = new Rectangle(
                    tile.PosX,
                    tile.PosY,
                    1,
                    1
                );

                if (tile.Sprite != null)
                {
                    g.FillRectangle(GetBrush(tile.Sprite), rect);
                }
                else
                {
                    g.FillRectangle(Brushes.Black, rect);
                }
            }
            mapBufferedGraphics.Render(e.Graphics);
        }

        private void UpdateAllIndex()
        {
            if (EditorManager._loadedMap == null || EditorManager._loadedMap.Data == null) return;

            foreach (MapTile tile in tiles)
            {
                tile.ElementID = EditorManager._loadedMap.Data[tile.PosY][tile.PosX];
            }
        }

        private void UpdateAllSprites()
        {

            if (EditorManager._loadedImages == null) return;

            foreach (MapTile tile in tiles)
            {
                tile.Sprite = EditorManager._loadedImages[tile.ElementID];
            }

        }

        private void ChechAllBrushes()
        {
            foreach (MapTile tile in tiles)
            {

                Image? brush = ElementManager.CheckBrush(tile.ElementID, tile.PosX, tile.PosY);

                if (brush != null)
                    tile.Sprite = brush;

            }
            pnContent.Invalidate();
            ResetSettings();

        }

        private void btnAlien_Click(object sender, EventArgs e)
        {
            if (EditorManager._loadedImages == null)
            {
                MessageBox.Show("Load images first...");
                return;
            }
            //EditorManager._loadedImages = RandomNatureService.RandomizeNature(EditorManager._loadedImages);
            EditorManager._loadedImages = RandomNatureService.RandomizeNature(EditorManager._loadedMap);
            UpdateAllSprites();
            pnContent.Invalidate();
            ResetSettings();
        }

        private void btnNoise_Click(object sender, EventArgs e)
        {
            MapNoiseDialog dialog = new MapNoiseDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel) return;

            if (EditorManager._loadedMap == null || EditorManager._loadedMap.Data == null) return;

            double frequency = Convert.ToDouble(dialog.nbFrequency.Value);
            double amplitude = Convert.ToDouble(dialog.nbAmplitude.Value);

            switch (dialog.cbNoiseType.SelectedIndex)
            {
                case 0:
                    MapNoiseService.ApplySimpleNoise(EditorManager._loadedMap.Data, range);
                    break;
                case 1:
                    MapNoiseService.ApplySmoothNoise(EditorManager._loadedMap.Data, range);
                    break;
                case 2:
                    MapNoiseService.ApplyDiamondSquare(EditorManager._loadedMap.Data, range);
                    break;
                case 3:
                    MapNoiseService.ApplyPerlinNoise(EditorManager._loadedMap.Data, range, frequency, amplitude);
                    break;
                case 4:
                    MapNoiseService.ApplyWaveNoise(EditorManager._loadedMap.Data, range, frequency, amplitude);
                    break;
            }
            UpdateAllIndex();
            UpdateAllSprites();
            ResetSettings();
            pnContent.Invalidate();

        }

        private void btnBorders_Click(object sender, EventArgs e)
        {
            ChechAllBrushes();
        }
    }
}
