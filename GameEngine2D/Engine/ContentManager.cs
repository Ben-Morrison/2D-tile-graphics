using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
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

        public void ClearContent()
        {
            textures = new Dictionary<string,Texture>();
        }

        public void AddTexture(string key, Texture texture)
        {
            textures.Add(key, texture);
        }

        public Texture GetTexture(string key)
        {
            Texture t;
            bool found = textures.TryGetValue(key, out t);

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

        public string LoadTexture(Device device)
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
                        return String.Empty;
                    }
                    else
                    {
                        textures.Add(fileName, texture);
                        return fileName;
                    }
                }
                catch(Exception e)
                {
                    error = e.Message;
                    return String.Empty;
                }
            }

            return String.Empty;
        }

        public void RemoveTexture(string name)
        {
            // Check all tiles and objects that may be using this texture
        }

        public static Bitmap TextureToBitmap(Texture t)
        {
            GraphicsStream stream;
            stream = TextureLoader.SaveToStream(ImageFileFormat.Bmp, t);
            Image img = Image.FromStream(stream);
            Bitmap b = new Bitmap(img);

            return b;
        }

        public string GetError()
        {
            return this.error;
        }
    }
}
