using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public partial class TextureForm : Form
    {
        private string selectedTexture; // Texture to display on the left
        Editor.EditorBrush brush;

        Graphics g;

        public TextureForm(Editor.EditorBrush brush)
        {
            InitializeComponent();

            this.brush = brush;
            this.selectedTexture = brush.Texture.SourceTexture;

            g = picPreview.CreateGraphics();

            UpdateTextures();

            switch (brush.Texture.TextureType)
            {
                case TextureType.None:
                    radioBrush1.Select();
                    break;
                case TextureType.Base:
                    radioBrush1.Select();
                    break;
                case TextureType.AutoTile:
                    radioBrush2.Select();
                    break;
                case TextureType.Wall:
                    radioBrush3.Select();
                    break;
            }

            DrawTexture();
            DrawPreview();
        }

        public void UpdateTextures()
        {
            listTextures.Items.Clear();

            foreach (KeyValuePair<string, Texture> t in Engine.ContentManager.Textures)
            {
                listTextures.Items.Add(t.Key);

                if (t.Key.Equals(brush.Texture.SourceTexture))
                    listTextures.SelectedIndex = listTextures.Items.IndexOf(t.Key);
            }
        }

        #region Event Handlers

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void listTextures_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTexture = listTextures.GetItemText(listTextures.SelectedItem);
            DrawTexture();
        }

        #endregion

        private void DrawTexture()
        {
            Texture t;
            Engine.ContentManager.Textures.TryGetValue(selectedTexture, out t);

            if (t != null)
            {
                Image img;

                GraphicsStream stream;
                stream = TextureLoader.SaveToStream(ImageFileFormat.Bmp, t);

                img = Image.FromStream(stream);

                picTexture.Image = img;
                picTexture.Size = img.Size;
            }
        }        

        private void DrawPreview()
        {
            /*g.Clear(Color.White);

            Image img = Image.FromFile(Engine.ContentManager.TexturePaths[selectedTexture]);
            Bitmap bmp = new Bitmap(img);

            g.DrawImage(bmp, new Rectangle(0, 0, sizeX, sizeY), new Rectangle(textureX, textureY, sizeX, sizeY), GraphicsUnit.Pixel);*/
        }

        #region Radio buttons

        private void radioBrush1_CheckedChanged(object sender, EventArgs e)
        {
            /*brush = Editor.BrushType.Base;
            sizeX = Default.TILE_WIDTH;
            sizeY = Default.TILE_WIDTH;
            DrawPreview();*/
        }

        private void radioBrush2_CheckedChanged(object sender, EventArgs e)
        {
            /*brush = Editor.BrushType.AutoTile;
            sizeX = Default.TILE_WIDTH * 2;
            sizeY = Default.TILE_WIDTH * 3;
            DrawPreview();*/
        }

        private void radioBrush3_CheckedChanged(object sender, EventArgs e)
        {
            /*brush = Editor.BrushType.AnimatedAutoTile;
            sizeX = Default.TILE_WIDTH * 6;
            sizeY = Default.TILE_WIDTH * 3;
            DrawPreview();*/
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Engine.ContentManager.LoadTexture(Engine.DeviceManager.Device);
            UpdateTextures();
        }
    }
}
