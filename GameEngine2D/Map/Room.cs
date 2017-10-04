using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;

namespace GameEngine2D
{
    public class Room
    {
        private int sizeX;
        private int sizeY;

        private List<GameObject> objects;

        private string enterScript;
        private string exitScript;

        private Tile[,] tiles;

        public Room(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            objects = new List<GameObject>();

            Tile[,] _tiles = new Tile[sizeX, sizeY];

            Rectangle[] rects = new Rectangle[4];
            rects[0] = new Rectangle(0, 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
            rects[1] = new Rectangle(Default.SUBTILE_WIDTH, 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
            rects[2] = new Rectangle(0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
            rects[3] = new Rectangle(Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

            for (int i = 0; i < sizeX; i++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    _tiles[i, y] = new Tile(i, y);
                    _tiles[i, y].SetLayer(0, 0, rects, TextureType.Base, 0, 0);
                }
            }

            this.tiles = _tiles;
        }

        public Room(Tile[,] tiles)
        {
            this.sizeX = tiles.GetLength(0);
            this.sizeY = tiles.GetLength(1);
            this.tiles = tiles;
        }

        public Tile[,] GetTiles()
        {
            return this.tiles;
        }

        public void AddObject(GameObject o)
        {
            this.objects.Add(o);
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }

        public void Update()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(this.objects);
            }
        }

        public void Draw(Sprite s)
        {
            int startX = (int)(Engine.Camera.X / Default.TILE_WIDTH);
            int startY = (int)(Engine.Camera.Y / Default.TILE_WIDTH);
            int endX = (int)((Engine.Camera.X + Engine.Screen.SizeX) / Default.TILE_WIDTH + 1);
            int endY = (int)((Engine.Camera.Y + Engine.Screen.SizeY) / Default.TILE_WIDTH + 1);
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

            Engine.ContentManager.DefaultFont.DrawText(s, "Tiles: " + (this.tiles.GetLength(0) * this.tiles.GetLength(1)), new Point(32, 32), Color.Red);
            Engine.ContentManager.DefaultFont.DrawText(s, "Tile Draw Calls: " + count, new Point(32, 64), Color.Red);

            Engine.ContentManager.DefaultFont.DrawText(s, "startX: " + startX, new Point(32, 96), Color.Red);
            Engine.ContentManager.DefaultFont.DrawText(s, "startY: " + startY, new Point(32, 128), Color.Red);

            Engine.ContentManager.DefaultFont.DrawText(s, "endX: " + endX, new Point(32, 160), Color.Red);
            Engine.ContentManager.DefaultFont.DrawText(s, "endY: " + endY, new Point(32, 192), Color.Red);

            Engine.ContentManager.DefaultFont.DrawText(s, "Camera: " + Engine.Camera.X + ", " + Engine.Camera.Y, new Point(32, 224), Color.Red);
        }
    }
}
