namespace PokeUnit.Infrastructure.MapEditor.Core
{
    public static class ElementManager
    {

        private static readonly string ElementDirectory = "Sprites";
        private static readonly string ElementExtension = ".png";

        public static void VerifyDirectory()
        {
            if(Directory.Exists(ElementDirectory))
                Directory.CreateDirectory(ElementDirectory);
        }

        private static string GetPath(int ID)
        {
            return Path.Combine(ElementDirectory, (ID + ElementExtension));
        }

        public static Image? LoadElement(int ID)
        {

            VerifyDirectory();

            string path = GetPath(ID);

            if (!File.Exists(path))
                return null;

            return Image.FromFile(path);
        }

    }
}
