namespace PokeUnit.Infrastructure.MapEditor.Services
{

    public static class MapNoiseService
    {

        public static void ApplySimpleNoise(int[][] data, int range)
        {
            Random random = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    data[i][j] = random.Next(0, range);
                }
            }
        }

        public static void ApplySmoothNoise(int[][] data, int range)
        {
            Random random = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    int avgValue = (
                        GetTileValue(data, i - 1, j - 1) +
                        GetTileValue(data, i - 1, j) +
                        GetTileValue(data, i - 1, j + 1) +
                        GetTileValue(data, i, j - 1) +
                        GetTileValue(data, i, j + 1) +
                        GetTileValue(data, i + 1, j - 1) +
                        GetTileValue(data, i + 1, j) +
                        GetTileValue(data, i + 1, j + 1)
                    ) / 8;

                    data[i][j] = avgValue + random.Next(-range / 5, range / 5); // Adiciona variação leve
                    data[i][j] = Math.Clamp(data[i][j], 0, range - 1); // Limita ao intervalo
                }
            }
        }

        private static int GetTileValue(int[][] data, int x, int y)
        {
            if (x < 0 || x >= data.Length || y < 0 || y >= data[0].Length) return 0;
            return data[x][y];
        }

        public static void ApplyDiamondSquare(int[][] data, int range)
        {
            int size = data.Length;
            Random random = new Random();

            // Inicialização dos quatro cantos do mapa
            data[0][0] = random.Next(0, range);
            data[0][size - 1] = random.Next(0, range);
            data[size - 1][0] = random.Next(0, range);
            data[size - 1][size - 1] = random.Next(0, range);

            int stepSize = size - 1;
            int roughness = range / 2;

            while (stepSize > 1)
            {
                int halfStep = stepSize / 2;

                // Passo em quadrado
                for (int x = halfStep; x < size; x += stepSize)
                {
                    for (int y = halfStep; y < size; y += stepSize)
                    {
                        if (x < size && y < size)
                        {
                            int avg = (GetSafeValue(data, x - halfStep, y - halfStep) +
                                       GetSafeValue(data, x - halfStep, y + halfStep) +
                                       GetSafeValue(data, x + halfStep, y - halfStep) +
                                       GetSafeValue(data, x + halfStep, y + halfStep)) / 4;

                            data[x][y] = avg + random.Next(-roughness, roughness);
                            data[x][y] = Math.Clamp(data[x][y], 0, range - 1);
                        }
                    }
                }

                // Passo em diamante
                for (int x = 0; x < size; x += halfStep)
                {
                    for (int y = (x + halfStep) % stepSize; y < size; y += stepSize)
                    {
                        if (x < size && y < size)
                        {
                            int sum = 0;
                            int count = 0;

                            // Acessa vizinhos de forma segura
                            if (x - halfStep >= 0) { sum += data[x - halfStep][y]; count++; }
                            if (x + halfStep < size) { sum += data[x + halfStep][y]; count++; }
                            if (y - halfStep >= 0) { sum += data[x][y - halfStep]; count++; }
                            if (y + halfStep < size) { sum += data[x][y + halfStep]; count++; }

                            data[x][y] = (sum / count) + random.Next(-roughness, roughness);
                            data[x][y] = Math.Clamp(data[x][y], 0, range - 1);
                        }
                    }
                }

                roughness /= 2;
                stepSize /= 2;
            }
        }

        private static int GetSafeValue(int[][] data, int x, int y)
        {
            int size = data.Length;
            if (x < 0 || x >= size || y < 0 || y >= size) return 0;
            return data[x][y];
        }

        public static void ApplyPerlinNoise(int[][] data, int range, double frequency, double amplitude)
        {
            int width = data.Length;
            int height = data[0].Length;

            Random random = new Random();
            double offsetX = random.NextDouble() * 1000;
            double offsetY = random.NextDouble() * 1000;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double nx = (x + offsetX) * frequency;
                    double ny = (y + offsetY) * frequency;
                    double noiseValue = Perlin(nx, ny) * amplitude;

                    // Ajusta o valor do noise para ficar dentro do intervalo 0 - range
                    int terrainValue = (int)((noiseValue + 1) / 2 * range);
                    data[x][y] = Math.Clamp(terrainValue, 0, range - 1);
                }
            }
        }

        private static double Perlin(double x, double y)
        {
            // Calcula os pontos da grade
            int x0 = (int)Math.Floor(x);
            int x1 = x0 + 1;
            int y0 = (int)Math.Floor(y);
            int y1 = y0 + 1;

            // Fator de interpolação
            double sx = x - x0;
            double sy = y - y0;

            // Gradientes pseudoaleatórios para cada ponto da grade
            double n0 = DotGridGradient(x0, y0, x, y);
            double n1 = DotGridGradient(x1, y0, x, y);
            double ix0 = Lerp(n0, n1, sx);

            n0 = DotGridGradient(x0, y1, x, y);
            n1 = DotGridGradient(x1, y1, x, y);
            double ix1 = Lerp(n0, n1, sx);

            return Lerp(ix0, ix1, sy);
        }

        private static double DotGridGradient(int ix, int iy, double x, double y)
        {
            // Vetores gradiente aleatórios para cada ponto
            Random random = new Random(ix * 73856093 ^ iy * 19349663);
            double angle = random.NextDouble() * Math.PI * 2;
            double gradientX = Math.Cos(angle);
            double gradientY = Math.Sin(angle);

            // Vetor de distância
            double dx = x - ix;
            double dy = y - iy;

            return (dx * gradientX + dy * gradientY);
        }

        private static double Lerp(double a, double b, double t)
        {
            return a + t * (b - a);
        }
        
        public static void ApplyWaveNoise(int[][] data, int range, double frequency, double amplitude)
        {
            int width = data.Length;
            int height = data[0].Length;

            // Inicialize o Random para gerar variações nas ondas
            Random random = new Random();
            double phaseShiftX = random.NextDouble() * 2 * Math.PI;
            double phaseShiftY = random.NextDouble() * 2 * Math.PI;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Calcule o valor da onda para a posição (x, y) usando seno
                    double waveX = Math.Sin((x * frequency) + phaseShiftX) * amplitude;
                    double waveY = Math.Sin((y * frequency) + phaseShiftY) * amplitude;

                    // Combine as ondas para criar uma aparência de onda suave
                    int waveValue = (int)((waveX + waveY) / 2 + (range / 2));

                    // Clampe o valor para que fique entre 0 e o range - 1
                    data[x][y] = Math.Clamp(waveValue, 0, range - 1);
                }
            }
        }


    }
}
