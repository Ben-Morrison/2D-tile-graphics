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
        EditorBrush brush;

        Graphics g;

        Editor form;

        public TextureForm(Form form, EditorBrush brush)
        {
            InitializeComponent();

            this.form = (Editor)form;
            this.brush = brush;
            this.selectedTexture = brush.Texture.SourceTexture;

            g = picPreview.CreateGraphics();

            UpdateTextures();

            if (brush.BrushType == BrushType.Texture)
            {
                switch (brush.Texture.TextureType)
                {
                    case TextureType.None:
                        radioTextureBase.Select();
                        break;
                    case TextureType.Base:
                        radioTextureBase.Select();
                        break;
                    case TextureType.AutoTile:
                        radioTextureAutotile.Select();
                        break;
                    case TextureType.Wall:
                        radioTextureWall.Select();
                        break;
                }

                DrawTexture();
                DrawPreview();
            }
        }

        #region Event Handlers

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (brush.BrushType == BrushType.Texture)
            {
                if (brush.Texture.TextureType != TextureType.None)
                {
                    Editor.Brush = this.brush;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You must first select a texture 2");
                }
            }
            else
            {
                MessageBox.Show("You must first select a texture 1");
            }
        }

        private void listTextures_SelectedIndexChanged(object sender, EventArgs e)
        {
            brush.Texture.TextureType = TextureType.None;

            selectedTexture = listTextures.GetItemText(listTextures.SelectedItem);
            DrawTexture();
        }

        private void picTexture_Click(object sender, EventArgs e)
        {
            brush.BrushType = BrushType.Texture;

            MouseEventArgs me = (MouseEventArgs)e;
            brush.Texture.StartX = me.X - me.X % Default.TILE_WIDTH;
            brush.Texture.StartY = me.Y - me.Y % Default.TILE_WIDTH;

            brush.Texture.SourceTexture = selectedTexture;

            if (radioTextureBase.Checked)
            {
                brush.Texture.TextureType = TextureType.Base;
                brush.Texture.SizeX = Default.TILE_WIDTH;
                brush.Texture.SizeY = Default.TILE_WIDTH;
            }
            if (radioTextureAutotile.Checked)
            {
                brush.Texture.TextureType = TextureType.AutoTile;
                brush.Texture.SizeX = Default.TILE_WIDTH * 2;
                brush.Texture.SizeY = Default.TILE_WIDTH * 3;
            }
            if (radioTextureWall.Checked)
            {
                brush.Texture.TextureType = TextureType.Wall;
                brush.Texture.SizeX = Default.TILE_WIDTH * 2;
                brush.Texture.SizeY = Default.TILE_WIDTH * 3;
            }

            DrawPreview();
        }

        #endregion

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

        private void DrawTexture()
        {
            Texture t;
            Engine.ContentManager.Textures.TryGetValue(selectedTexture, out t);

            if (t != null)
            {
                GraphicsStream stream;
                stream = TextureLoader.SaveToStream(ImageFileFormat.Bmp, t);

                Image img = Image.FromStream(stream);

                picTexture.Image = img;
                picTexture.Size = img.Size;
            }
        }        

        private void DrawPreview()
        {
            picPreview.Invalidate();
        }

        #region Radio buttons

        private void radioTextureBase_CheckedChanged(object sender, EventArgs e)
        {
            brush.Texture.TextureType = TextureType.Base;
            brush.Texture.SizeX = Default.TILE_WIDTH;
            brush.Texture.SizeY = Default.TILE_WIDTH;

            DrawPreview();
        }

        private void radioTextureAutotile_CheckedChanged(object sender, EventArgs e)
        {
            brush.Texture.TextureType = TextureType.AutoTile;
            brush.Texture.SizeX = Default.TILE_WIDTH * 2;
            brush.Texture.SizeY = Default.TILE_WIDTH * 3;

            DrawPreview();
        }

        private void radioTextureWall_CheckedChanged(object sender, EventArgs e)
        {
            brush.Texture.TextureType = TextureType.Wall;
            brush.Texture.SizeX = Default.TILE_WIDTH * 2;
            brush.Texture.SizeY = Default.TILE_WIDTH * 2;

            DrawPreview();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Engine.ContentManager.LoadTexture(Engine.DeviceManager.Device);
            UpdateTextures();
        }

        private void picPreview_Paint(object sender, PaintEventArgs e)
        {
            Texture t;
            Engine.ContentManager.Textures.TryGetValue(selectedTexture, out t);

            if (t != null)
            {
                GraphicsStream stream;
                stream = TextureLoader.SaveToStream(ImageFileFormat.Bmp, t);
                Image img = Image.FromStream(stream);
                Bitmap b = new Bitmap(img);

                g = e.Graphics;
                g.DrawImage(b, new Rectangle(0, 0, brush.Texture.SizeX, brush.Texture.SizeY), new Rectangle(brush.Texture.StartX, brush.Texture.StartY, brush.Texture.SizeX, brush.Texture.SizeY), GraphicsUnit.Pixel);
            }
        }
    }
}
