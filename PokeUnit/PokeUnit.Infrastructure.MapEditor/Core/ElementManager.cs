namespace PokeUnit.Infrastructure.MapEditor.Core
{
    public static class ElementManager
    {

        private static readonly string ElementDirectory = "Sprites";
        private static readonly string ElementExtension = ".png";
        private static List<Image> Tilesets = new List<Image>();

        //1  2   4
        //8  0   16
        //32 64  128

        private static Dictionary<int, Rectangle> tileSprites = new Dictionary<int, Rectangle>
        {
            { 0, new Rectangle(25, 100, 24, 24)},
            { 208, new Rectangle(0, 0, 24, 24)},
            { 248, new Rectangle(25, 0, 24, 24)},
            { 104, new Rectangle(50, 0, 24, 24)},
            { 214, new Rectangle(0, 25, 24, 24)},
            { 255, new Rectangle(25, 25, 24, 24)},
            { 107, new Rectangle(50, 25, 24, 24)},
            { 22, new Rectangle(0, 50, 24, 24)},
            { 31, new Rectangle(25, 50, 24, 24)},
            { 11, new Rectangle(50, 50, 24, 24)},
            { 80, new Rectangle(0, 75, 24, 24)},
            { 24, new Rectangle(25, 75, 24, 24)},
            { 72, new Rectangle(50, 75, 24, 24)},
            { 66, new Rectangle(0, 100, 24, 24)},
            { 18, new Rectangle(0, 125, 24, 24)},
            { 10, new Rectangle(50, 125, 24, 24)},
            { 64, new Rectangle(25, 150, 24, 24)},
            { 16, new Rectangle(0, 175, 24, 24)},
            { 90, new Rectangle(25, 175, 24, 24)},
            { 8, new Rectangle(50, 175, 24, 24)},
            { 2, new Rectangle(25, 200, 24, 24)},
            { 88, new Rectangle(25, 225, 24, 24)},
            { 82, new Rectangle(0, 250, 24, 24)},
            { 74, new Rectangle(50, 250, 24, 24)},
            { 26, new Rectangle(25, 275, 24, 24)},
            { 95, new Rectangle(25, 300, 24, 24)},
            { 123, new Rectangle(0, 325, 24, 24)},
            { 222, new Rectangle(50, 325, 24, 24)},
            { 250, new Rectangle(25, 350, 24, 24)},
            { 127, new Rectangle(0, 375, 24, 24)},
            { 223, new Rectangle(25, 375, 24, 24)},
            { 251, new Rectangle(0, 400, 24, 24)},
            { 254, new Rectangle(25, 400, 24, 24)},
            { 86, new Rectangle(0, 425, 24, 24)},
            { 75, new Rectangle(25, 425, 24, 24)},
            { 210, new Rectangle(0, 450, 24, 24)},
            { 106, new Rectangle(25, 450, 24, 24)},
            { 120, new Rectangle(0, 475, 24, 24)},
            { 216, new Rectangle(25, 475, 24, 24)},
            { 27, new Rectangle(0, 500, 24, 24)},
            { 30, new Rectangle(25, 500, 24, 24)},
            { 218, new Rectangle(0, 525, 24, 24)},
            { 122, new Rectangle(25, 525, 24, 24)},
            { 94, new Rectangle(0, 550, 24, 24)},
            { 91, new Rectangle(25, 550, 24, 24)},
            { 126, new Rectangle(0, 575, 24, 24)},
            { 219, new Rectangle(25, 575, 24, 24)},
        };

        public static void VerifyDirectory()
        {
            if(!Directory.Exists(ElementDirectory))
                Directory.CreateDirectory(ElementDirectory);
        }

        private static string GetPath(int ID)
        {
            return Path.Combine(ElementDirectory, (ID + ElementExtension));
        }

        private static int CalculateTileMask(int[][] data, int x, int y)
        {
            int rows = data.Length;
            int cols = data[0].Length;
            int tileValue = data[y][x];
            int mask = 0;

            // Define as posições e valores de máscara para cada vizinho ao redor do tile
            int[][] directions = new int[][]
            {
                new int[] { -1, -1, 1 },  // Top-Left
                new int[] { -1,  0, 2 },  // Top
                new int[] { -1,  1, 4 },  // Top-Right
                new int[] {  0, -1, 8 },  // Left
                new int[] {  0,  1, 16 }, // Right
                new int[] {  1, -1, 32 }, // Bottom-Left
                new int[] {  1,  0, 64 }, // Bottom
                new int[] {  1,  1, 128 } // Bottom-Right
            };

            // Itera sobre os vizinhos e calcula a máscara
            foreach (var direction in directions)
            {
                int dy = y + direction[0];
                int dx = x + direction[1];
                int bitValue = direction[2];

                // Verifica se está dentro dos limites e se o vizinho é igual ao valor do tile central
                if (dy >= 0 && dy < rows && dx >= 0 && dx < cols && data[dy][dx] == tileValue)
                {
                    mask |= bitValue;  // Adiciona o valor do bit à máscara
                }
            }

            return mask;
        }

        private static int CalculateTileMaskWithoutDiagonals(int[][] data, int x, int y)
        {
            int rows = data.Length;
            int cols = data[0].Length;
            int tileValue = data[y][x];
            int mask = 0;

            // Define as posições e valores de máscara apenas para os vizinhos horizontais e verticais
            int[][] directions = new int[][]
            {
                new int[] { -1, 0, 2 },  // Cima
                new int[] { 0, -1, 8 },  // Esquerda
                new int[] { 0, 1, 16 },  // Direita
                new int[] { 1, 0, 64 }   // Baixo
            };

            // Itera sobre os vizinhos e calcula a máscara
            foreach (var direction in directions)
            {
                int dy = y + direction[0];
                int dx = x + direction[1];
                int bitValue = direction[2];

                // Verifica se está dentro dos limites e se o vizinho é igual ao valor do tile central
                if (dy >= 0 && dy < rows && dx >= 0 && dx < cols && data[dy][dx] == tileValue)
                {
                    mask |= bitValue;  // Adiciona o valor do bit à máscara
                }
            }

            return mask;
        }

        public static Image? CheckBrush(int ElementID, int PosX, int PosY)
        {

            if (EditorManager._loadedMap == null || EditorManager._loadedMap.Data == null || EditorManager._loadedImages == null) return null;

            int Neighbors = CalculateTileMask(EditorManager._loadedMap.Data, PosX, PosY);
            int Sides = CalculateTileMaskWithoutDiagonals(EditorManager._loadedMap.Data, PosX, PosY);
            Rectangle rect;


            try 
            {
                rect = tileSprites[Sides];
                return CropElement(Tilesets[ElementID],rect);
            }
            catch
            {
                return null;
            }

        }

        public static Image CropElement(Image source, Rectangle cropArea)
        {
            Bitmap croppedBitmap = new Bitmap(cropArea.Width, cropArea.Height);

            using (Graphics g = Graphics.FromImage(croppedBitmap))
            {
                g.DrawImage(source,
                            new Rectangle(0, 0, cropArea.Width, cropArea.Height),
                            cropArea,
                            GraphicsUnit.Pixel);
            }

            return croppedBitmap;
        }

        public static Image? LoadElement(int ID)
        {

            VerifyDirectory();

            Rectangle baseRect = new Rectangle()
            {
                Width = 24,
                Height = 24,
                X = 25,
                Y = 25,
            };

            string path = GetPath(ID);

            if (!File.Exists(path))
                return null;

            Tilesets.Add(Image.FromFile(path));

            return CropElement(Image.FromFile(path), baseRect);
        }

    }
}
