using PokeUnit.Infrastructure.MapEditor.Core;

namespace PokeUnit.Infrastructure.MapEditor.Services
{
    public static class RandomNatureService
    {

        private static Color HSLToColor(float hue, float saturation, float lightness)
        {
            float c = (1 - Math.Abs(2 * lightness - 1)) * saturation;
            float x = c * (1 - Math.Abs((hue / 60) % 2 - 1));
            float m = lightness - c / 2;

            float r = 0, g = 0, b = 0;
            if (0 <= hue && hue < 60) { r = c; g = x; b = 0; }
            else if (60 <= hue && hue < 120) { r = x; g = c; b = 0; }
            else if (120 <= hue && hue < 180) { r = 0; g = c; b = x; }
            else if (180 <= hue && hue < 240) { r = 0; g = x; b = c; }
            else if (240 <= hue && hue < 300) { r = x; g = 0; b = c; }
            else if (300 <= hue && hue < 360) { r = c; g = 0; b = x; }

            int rInt = (int)((r + m) * 255);
            int gInt = (int)((g + m) * 255);
            int bInt = (int)((b + m) * 255);

            return Color.FromArgb(255, rInt, gInt, bInt);
        }

        private static void ColorToHSL(Color color, out float hue, out float saturation, out float lightness)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            float delta = max - min;

            hue = 0;
            saturation = 0;
            lightness = (max + min) / 2;

            if (delta != 0)
            {
                saturation = lightness < 0.5 ? delta / (max + min) : delta / (2 - max - min);

                if (max == r)
                {
                    hue = (g - b) / delta + (g < b ? 6 : 0);
                }
                else if (max == g)
                {
                    hue = (b - r) / delta + 2;
                }
                else
                {
                    hue = (r - g) / delta + 4;
                }
                hue *= 60;
            }
        }

        public static List<Image> RandomizeNature(List<Image> imagensOriginais)
        {
            List<Image> imagensAjustadas = new List<Image>();

            Random rand = new Random();
            float hueAdjustment = (float)(rand.NextDouble() * 60) - 30; // Ajuste de matiz entre -30 e +30 para evitar extremos
            float saturationFactor = 0.8f + (float)(rand.NextDouble() * 0.4f); // Saturação entre 0.8 e 1.2

            foreach (var originalImage in imagensOriginais)
            {
                Bitmap originalBitmap = new Bitmap(originalImage);
                Bitmap adjustedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    for (int y = 0; y < originalBitmap.Height; y++)
                    {
                        Color originalColor = originalBitmap.GetPixel(x, y);

                        if (originalColor.A > 0) // Ajusta apenas pixels visíveis
                        {
                            float hue, saturation, lightness;
                            ColorToHSL(originalColor, out hue, out saturation, out lightness);

                            hue = (hue + hueAdjustment + 360) % 360; // Ajuste suave do matiz
                            saturation = Math.Min(1.0f, saturation * saturationFactor); // Saturação levemente ajustada

                            Color adjustedColor = HSLToColor(hue, saturation, lightness);
                            adjustedBitmap.SetPixel(x, y, adjustedColor);
                        }
                        else
                        {
                            adjustedBitmap.SetPixel(x, y, originalColor); // Mantém pixels transparentes
                        }
                    }
                }

                imagensAjustadas.Add(adjustedBitmap);
            }

            return imagensAjustadas;
        }

    }
}
