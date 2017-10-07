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
        private GameTexture texture;

        public TileLayer(GameTexture texture)
        {
            this.texture = texture;
        }

        public GameTexture GameTexture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public void Draw(Sprite s, Point position)
        {
            int _x = position.X - (int)Engine.Camera.Position.X;
            int _y = position.Y - (int)Engine.Camera.Position.Y;

            //int _x = position.X;
            //int _y = position.Y;

            PointF subtile1 = new PointF(_x, _y);
            PointF subtile2 = new PointF(_x + Default.SUBTILE_WIDTH, _y);
            PointF subtile3 = new PointF(_x, _y + Default.SUBTILE_WIDTH);
            PointF subtile4 = new PointF(_x + Default.SUBTILE_WIDTH, _y + Default.SUBTILE_WIDTH);

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

            Texture t = Engine.ContentManager.GetTexture(this.texture.SourceTexture);

            if (t == null)
            {
                /*
                s.Draw2D(Engine.ContentManager.DefaultTexture, texture.Rects[0], new Size(Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH), subtile1, Color.White);
                s.Draw2D(Engine.ContentManager.DefaultTexture, texture.Rects[1], new Size(Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH), subtile2, Color.White);
                s.Draw2D(Engine.ContentManager.DefaultTexture, texture.Rects[2], new Size(Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH), subtile3, Color.White);
                s.Draw2D(Engine.ContentManager.DefaultTexture, texture.Rects[3], new Size(Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH), subtile4, Color.White); 
                */

                Size size = new Size(Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                s.Draw2D(Engine.ContentManager.DefaultTexture, texture.Rects[0], size, new PointF(_x, _y), Color.White);
                s.Draw2D(Engine.ContentManager.DefaultTexture, texture.Rects[1], size, new PointF(_x + Default.SUBTILE_WIDTH, _y), Color.White);
                s.Draw2D(Engine.ContentManager.DefaultTexture, texture.Rects[2], size, new PointF(_x, _y + Default.SUBTILE_WIDTH), Color.White);
                s.Draw2D(Engine.ContentManager.DefaultTexture, texture.Rects[3], size, new PointF(_x + Default.SUBTILE_WIDTH, _y + Default.SUBTILE_WIDTH), Color.White);
            }
            else
            {
                /*s.Draw2D(t, texture.Rects[0], SUBTILE_SIZE, subtile1, Color.White);
                s.Draw2D(t, texture.Rects[1], SUBTILE_SIZE, subtile2, Color.White);
                s.Draw2D(t, texture.Rects[2], SUBTILE_SIZE, subtile3, Color.White);
                s.Draw2D(t, texture.Rects[3], SUBTILE_SIZE, subtile4, Color.White);*/
            }
        }
    }
}
