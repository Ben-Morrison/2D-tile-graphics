using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public class TileLayer
    {
        private static SizeF size = new SizeF(Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

        private bool exists;

        private int texture;
        private int textureX;
        private int textureY;
        private TextureType textureType;

        private Rectangle[] rectangles;

        public TileLayer()
        {
            this.exists = false;
        }
        
        public TileLayer(int texture, Rectangle[] rectangles, TextureType type, int x, int y)
        {
            this.texture = texture;
            this.rectangles = rectangles;
            this.exists = true;
            this.textureType = type;
            this.textureX = x;
            this.textureY = y;
        }

        public void SetExists(bool exists) { this.exists = exists; }
        public bool GetExists() { return this.exists; }
        public int GetTexture() { return this.texture; }
        public void SetTexture(int t) { this.texture = t; this.exists = true; }
        public TextureType GetTextureType() { return this.textureType; }
        public Rectangle[] GetRectangles() { return this.rectangles; }
        public int GetX() { return this.textureX; }
        public int GetY() { return this.textureY; }

        public void Draw(Sprite s, int x, int y)
        {
            int _x = x - (int)Engine.Camera.X;
            int _y = y - (int)Engine.Camera.Y;

            switch (textureType)
            {
                case TextureType.AnimatedAutoTile:
                    Rectangle rect0 = new Rectangle(this.rectangles[0].X + (EngineVariables.anim_tile_frame * 64), this.rectangles[0].Y, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                    Rectangle rect1 = new Rectangle(this.rectangles[1].X + (EngineVariables.anim_tile_frame * 64), this.rectangles[1].Y, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                    Rectangle rect2 = new Rectangle(this.rectangles[2].X + (EngineVariables.anim_tile_frame * 64), this.rectangles[2].Y, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                    Rectangle rect3 = new Rectangle(this.rectangles[3].X + (EngineVariables.anim_tile_frame * 64), this.rectangles[3].Y, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], rect0, size, new PointF(x, y), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], rect1, size, new PointF(x + Default.SUBTILE_WIDTH, y), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], rect2, size, new PointF(x, y + Default.SUBTILE_WIDTH), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], rect3, size, new PointF(x + Default.SUBTILE_WIDTH, y + Default.SUBTILE_WIDTH), Color.White);
                    break;
                case TextureType.AnimatedWaterfall:
                    break;
                default:
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], this.rectangles[0], size, new Point(_x, _y), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], this.rectangles[1], size, new Point(_x + Default.SUBTILE_WIDTH, _y), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], this.rectangles[2], size, new Point(_x, _y + Default.SUBTILE_WIDTH), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], this.rectangles[3], size, new Point(_x + Default.SUBTILE_WIDTH, _y + Default.SUBTILE_WIDTH), Color.White);
                    break;
              
            }
            
        }
    }
}
