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
        private int selectedTexture;
        private int textureX;
        private int textureY;
        private int sizeX;
        private int sizeY;

        private Editor.BrushType brush;

        Graphics g;

        public TextureForm(int texture, int textureX, int textureY, Editor.BrushType brush)
        {
            InitializeComponent();

            this.selectedTexture = texture;
            this.textureX = textureX;
            this.textureY = textureY;
            this.brush = brush;

            g = picPreview.CreateGraphics();

            foreach (string s in Engine.ContentManager.TextureNames)
                listTextures.Items.Add(s);

            listTextures.SelectedIndex = selectedTexture;

            switch (brush)
            {
                case Editor.BrushType.Base:
                    radioBrush1.Select();
                    sizeX = Default.TILE_WIDTH;
                    sizeY = Default.TILE_WIDTH;
                    break;
                case Editor.BrushType.AutoTile:
                    radioBrush2.Select();
                    sizeX = Default.TILE_WIDTH * 2;
                    sizeY = Default.TILE_WIDTH * 3;
                    break;
                case Editor.BrushType.AnimatedAutoTile:
                    radioBrush3.Select();
                    sizeX = Default.TILE_WIDTH * 6;
                    sizeY = Default.TILE_WIDTH * 3;
                    break;
                case Editor.BrushType.AnimatedWaterfall:
                    radioBrush4.Select();
                    sizeX = Default.TILE_WIDTH * 2;
                    sizeY = Default.TILE_WIDTH * 2;
                    break;
                case Editor.BrushType.Wall:
                    radioBrush5.Select();
                    sizeX = Default.TILE_WIDTH * 2;
                    sizeY = Default.TILE_WIDTH * 2;
                    break;
            }

            DrawPreview();
        }

        private void Draw()
        {
            Image img = Image.FromFile(Engine.ContentManager.TexturePaths[selectedTexture]);
            picTexture.Image = img;
            picTexture.Size = img.Size;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Editor form = (Editor)(this.Owner);
            form.SetBrush(this.brush, this.selectedTexture, this.textureX, this.textureY);

            this.Close();
        }

        private void listTextures_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTexture = listTextures.SelectedIndex;
            Draw();
        }

        private void picPreview_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;

            textureX = mouse.X - mouse.X % Default.TILE_WIDTH;
            textureY = mouse.Y - mouse.Y % Default.TILE_WIDTH;

            DrawPreview();
        }

        private void DrawPreview()
        {
            g.Clear(Color.White);

            Image img = Image.FromFile(Engine.ContentManager.TexturePaths[selectedTexture]);
            Bitmap bmp = new Bitmap(img);

            g.DrawImage(bmp, new Rectangle(0, 0, sizeX, sizeY), new Rectangle(textureX, textureY, sizeX, sizeY), GraphicsUnit.Pixel);
        }

        #region Radio buttons

        private void radioBrush1_CheckedChanged(object sender, EventArgs e)
        {
            brush = Editor.BrushType.Base;
            sizeX = Default.TILE_WIDTH;
            sizeY = Default.TILE_WIDTH;
            DrawPreview();
        }

        private void radioBrush2_CheckedChanged(object sender, EventArgs e)
        {
            brush = Editor.BrushType.AutoTile;
            sizeX = Default.TILE_WIDTH * 2;
            sizeY = Default.TILE_WIDTH * 3;
            DrawPreview();
        }

        private void radioBrush3_CheckedChanged(object sender, EventArgs e)
        {
            brush = Editor.BrushType.AnimatedAutoTile;
            sizeX = Default.TILE_WIDTH * 6;
            sizeY = Default.TILE_WIDTH * 3;
            DrawPreview();
        }

        private void radioBrush4_CheckedChanged(object sender, EventArgs e)
        {
            brush = Editor.BrushType.AnimatedWaterfall;
            sizeX = Default.TILE_WIDTH * 2;
            sizeY = Default.TILE_WIDTH * 2;
            DrawPreview();
        }

        private void radioBrush5_CheckedChanged(object sender, EventArgs e)
        {
            brush = Editor.BrushType.Wall;
            sizeX = Default.TILE_WIDTH * 2;
            sizeY = Default.TILE_WIDTH * 2;
            DrawPreview();
        }

        #endregion
    }
}
