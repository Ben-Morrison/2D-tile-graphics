using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace GameEngine2D
{
    public class ContentManager
    {
        private bool defaultLoaded = false;
        private bool loaded = false;

        private Microsoft.DirectX.Direct3D.Font defaultFont;
        private Texture defaultTexture;
        private Dictionary<string, Texture> textures;

        private string error;

        public ContentManager(Device device)
        {
            this.textures = new Dictionary<string, Texture>();
            this.LoadDefaultContent(device);
        }

        public Microsoft.DirectX.Direct3D.Font DefaultFont
        {
            get { return this.defaultFont; }
        }

        public Texture DefaultTexture
        {
            get { return this.defaultTexture; }
        }

        public Dictionary<string, Texture> Textures
        {
            get { return textures; }
        }

        public Texture GetTexture(string key)
        {
            Texture t;
            bool found = Engine.ContentManager.Textures.TryGetValue(key, out t);

            if (found)
                return t;
            else
            {
                return null;
            }
        }

        public void LoadDefaultContent(Device device)
        {
            if (!defaultLoaded)
            {
                System.Drawing.Font systemFont = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular);
                defaultFont = new Microsoft.DirectX.Direct3D.Font(device, systemFont);

                ImageInformation info = TextureLoader.ImageInformationFromFile(Default.DEFAULT_CONTENT_DIRECTORY + @"\default.png");
                this.defaultTexture = TextureLoader.FromFile(device, Default.DEFAULT_CONTENT_DIRECTORY + @"\default.png", info.Width, info.Height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed, Filter.None, Filter.None, 0);
            }
        }

        public Game LoadGame(string path)
        {
            // Get textures from the file
            // Get other content from the file

            // Get the rooms, tiles, objects and everything else

            return new Game();
        }

        public void UnloadGame()
        {

        }

        public void LoadTexture(Device device)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PNG Image (*.png)|*.png";

            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                try
                {
                    string path = dialog.FileName;
                    string fileName = Path.GetFileNameWithoutExtension(path);

                    ImageInformation info = TextureLoader.ImageInformationFromFile(path);
                    Texture texture = TextureLoader.FromFile(device, path, info.Width, info.Height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed, Filter.None, Filter.None, 0);
                    
                    if(textures.ContainsKey(fileName))
                    {
                        MessageBox.Show("Texture already added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        textures.Add(fileName, texture);
                    }
                }
                catch(Exception e)
                {
                    error = e.Message;
                }
            } 
        }

        public void RemoveTexture(string name)
        {
            // Check all tiles and objects that may be using this texture
        }

        public string GetError()
        {
            return this.error;
        }
    }
}
