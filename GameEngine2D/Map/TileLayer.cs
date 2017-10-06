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
        private static readonly SizeF TILE_SIZE = new SizeF(Default.TILE_WIDTH, Default.TILE_WIDTH);
        private static readonly SizeF SUBTILE_SIZE = new SizeF(Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

        private bool exists;
        private GameTexture texture;

        public TileLayer()
        {
            this.exists = false;
        }

        public TileLayer(GameTexture texture)
        {
            this.texture = texture;
            this.exists = true;
        }

        public bool Exists
        {
            get { return this.exists; }
            set
            {
                if (value == false)
                {
                    this.texture = null;
                    this.exists = value;
                }
            }
        }

        public GameTexture GameTexture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public void Draw(Sprite s, Point position)
        {
            int _x = position.X - (int)Engine.Camera.X;
            int _y = position.Y - (int)Engine.Camera.Y;

            Point subtile1 = new Point(_x, _y);
            Point subtile2 = new Point(_x + Default.SUBTILE_WIDTH, _y);
            Point subtile3 = new Point(_x, _y + Default.SUBTILE_WIDTH);
            Point subtile4 = new Point(_x + Default.SUBTILE_WIDTH, _y + Default.SUBTILE_WIDTH);

            /*
            switch (texture.TextureType)
            {
                case TextureType.AutoTile:
                    Rectangle rect0 = new Rectangle(this.rectangles[0].X + (EngineVariables.anim_tile_frame * 64), this.rectangles[0].Y, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                    Rectangle rect1 = new Rectangle(this.rectangles[1].X + (EngineVariables.anim_tile_frame * 64), this.rectangles[1].Y, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                    Rectangle rect2 = new Rectangle(this.rectangles[2].X + (EngineVariables.anim_tile_frame * 64), this.rectangles[2].Y, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                    Rectangle rect3 = new Rectangle(this.rectangles[3].X + (EngineVariables.anim_tile_frame * 64), this.rectangles[3].Y, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], rect0, size, new PointF(x, y), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], rect1, size, new PointF(x + Default.SUBTILE_WIDTH, y), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], rect2, size, new PointF(x, y + Default.SUBTILE_WIDTH), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], rect3, size, new PointF(x + Default.SUBTILE_WIDTH, y + Default.SUBTILE_WIDTH), Color.White);
                    break;
                case TextureType.Wall:
                    break;
                default:
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], this.rectangles[0], size, new Point(_x, _y), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], this.rectangles[1], size, new Point(_x + Default.SUBTILE_WIDTH, _y), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], this.rectangles[2], size, new Point(_x, _y + Default.SUBTILE_WIDTH), Color.White);
                    s.Draw2D(Engine.ContentManager.Textures[this.GetTexture()], this.rectangles[3], size, new Point(_x + Default.SUBTILE_WIDTH, _y + Default.SUBTILE_WIDTH), Color.White);
                    break;
              
            }
            */

            Texture t = Engine.ContentManager.GetTexture(this.GameTexture.SourceTexture);

            if (t == null)
            {
                s.Draw2D(Engine.ContentManager.DefaultTexture, new Rectangle(position.X, position.Y, Default.TILE_WIDTH, Default.TILE_WIDTH), TILE_SIZE, subtile1, Color.White);
            }
            else
            {
                s.Draw2D(t, texture.Rects[0], SUBTILE_SIZE, subtile1, Color.White);
                s.Draw2D(t, texture.Rects[1], SUBTILE_SIZE, subtile2, Color.White);
                s.Draw2D(t, texture.Rects[2], SUBTILE_SIZE, subtile3, Color.White);
                s.Draw2D(t, texture.Rects[3], SUBTILE_SIZE, subtile4, Color.White);
            }
        }
    }
}
