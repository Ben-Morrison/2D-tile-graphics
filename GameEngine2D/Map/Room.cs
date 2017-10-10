using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;

namespace GameEngine2D
{
    public class Room : IDraw
    {
        private string name;

        private Tile[,] tiles;
        private List<GameObject> objects;

        public Room(string name)
        {
            this.name = name;
            this.tiles = new Tile[Default.DEFAULT_ROOM_SIZE_X, Default.DEFAULT_ROOM_SIZE_Y];
            this.objects = new List<GameObject>();
        }

        public Room(string name, int x, int y)
        {
            this.name = name;
            this.tiles = new Tile[x, y];
            this.objects = new List<GameObject>();

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    tiles[i, j] = new Tile(i, j);   
                }
            }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Tile[,] Tiles
        {
            get { return this.tiles; }
            set { this.tiles = value; }
        }

        public void Draw(Sprite s)
        {
            int startX = (int)(Engine.Camera.Position.X / Default.TILE_WIDTH);
            int startY = (int)(Engine.Camera.Position.Y / Default.TILE_WIDTH);
            int endX = (int)((Engine.Camera.Position.X + Engine.Screen.SizeX) / Default.TILE_WIDTH + 1);
            int endY = (int)((Engine.Camera.Position.Y + Engine.Screen.SizeY) / Default.TILE_WIDTH + 1);
            if (startX < 0)
                startX = 0;
            if (startY < 0)
                startY = 0;
            if (endX > tiles.GetLength(0))
                endX = tiles.GetLength(0);
            if (endY > tiles.GetLength(1))
                endY = tiles.GetLength(1);

            int count = 0;

            for (int x = startX; x < endX; x++)
            {
                for (int y = startY; y < endY; y++)
                {
                    tiles[x, y].Draw(s);
                    count++;
                }
            }

            foreach (GameObject o in objects)
                o.Draw(s);

            s.Flush();

            Sprite sprite = new Sprite(s.Device);
            sprite.Begin(SpriteFlags.AlphaBlend);

            if (Engine.StateManager.Editor || Engine.StateManager.Debug)
            {
                Engine.ContentManager.DefaultFont.DrawText(sprite, "Name: " + this.name, new Point(32, 32), Color.Red);
                /*
                Engine.ContentManager.DefaultFont.DrawText(sprite, "Tiles: " + (this.tiles.GetLength(0) * this.tiles.GetLength(1)), new Point(32, 64), Color.Red);
                Engine.ContentManager.DefaultFont.DrawText(sprite, "Tile Draw Calls: " + count, new Point(32, 96), Color.Red);

                Engine.ContentManager.DefaultFont.DrawText(sprite, "startX: " + startX, new Point(32, 128), Color.Red);
                Engine.ContentManager.DefaultFont.DrawText(sprite, "startY: " + startY, new Point(32, 160), Color.Red);

                Engine.ContentManager.DefaultFont.DrawText(sprite, "endX: " + endX, new Point(32, 192), Color.Red);
                Engine.ContentManager.DefaultFont.DrawText(sprite, "endY: " + endY, new Point(32, 224), Color.Red);

                Engine.ContentManager.DefaultFont.DrawText(sprite, "Camera: " + Engine.Camera.Position.X + ", " + Engine.Camera.Position.Y, new Point(32, 256), Color.Red);
                */
            }

            sprite.End();
            sprite.Dispose();
        }
    }
}
