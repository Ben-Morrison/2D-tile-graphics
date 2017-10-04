using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;
using System.IO;

namespace GameEngine2D
{
    public enum TextureType
    {
        Base,
        AutoTile,
        AnimatedAutoTile,
        AnimatedWaterfall,
        Wall
    }

    public enum AnimationType
    {
        None,
        AutoTile,
        Waterfall
    }

    public class ContentManager
    {
        private Microsoft.DirectX.Direct3D.Font defaultFont;

        private List<Texture> textures;
        private List<string> texturePaths;
        private List<string> textureNames;

        public ContentManager(Device device)
        {
            textures = new List<Texture>();
            texturePaths = new List<string>();
            textureNames = new List<string>();

            LoadContent(device);
        }

        public Microsoft.DirectX.Direct3D.Font DefaultFont
        {
            get { return defaultFont; }
        }

        public List<Texture> Textures
        {
            get { return textures; }
        }

        public List<string> TexturePaths
        {
            get { return texturePaths; }
        }

        public List<string> TextureNames
        {
            get { return textureNames; }
        }

        public void LoadContent(Device device)
        {
            System.Drawing.Font systemFont = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular);
            defaultFont = new Microsoft.DirectX.Direct3D.Font(device, systemFont);
            string[] files;

            // Get all tile textures
            files = Directory.GetFiles(Default.TEXTURE_DIRECTORY + @"\tiles");

            for (int i = 0; i < files.Length; i++)
            {
                string name = Path.GetFileNameWithoutExtension(files[i]);
                ImageInformation info = TextureLoader.ImageInformationFromFile(files[i]);
                Texture texture = TextureLoader.FromFile(device, files[i], info.Width, info.Height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed, Filter.None, Filter.None, 0);
                textures.Add(texture);
                texturePaths.Add(Path.GetFullPath(files[i]));
                textureNames.Add(name);
            }
        }
    }
}
