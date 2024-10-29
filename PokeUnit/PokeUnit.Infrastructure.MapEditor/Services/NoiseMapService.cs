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

        public static void ApplyPerlinNoise(int[][] data, int range)
        {
            Random random = new Random();
            double frequency = 0.1;
            double amplitude = range / 2.0;

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    double noiseValue = (Math.Sin(i * frequency) + Math.Cos(j * frequency)) * amplitude;
                    data[i][j] = Math.Clamp((int)(noiseValue + random.Next(-range / 4, range / 4)), 0, range - 1);
                }
            }
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
