using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;

namespace GameEngine2D
{
    public class Tile
    {
        private int x;
        private int y;

        private TileLayer[] layers;

        public Tile(int x, int y)
        {
            this.x = x * Default.TILE_WIDTH;
            this.y = y * Default.TILE_WIDTH;

            layers = new TileLayer[2];
            layers[0] = new TileLayer();
            layers[1] = new TileLayer();
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public void SetLayer(int layer, int texture, Rectangle[] rectangles, TextureType type, int x, int y)
        {
            this.layers[layer] = new TileLayer(texture, rectangles, type, x, y);
        }

        public TileLayer GetLayer(int layer)
        {
            return this.layers[layer];
        }

        public void DeleteLayer(int layer)
        {
            this.layers[layer].SetExists(false);
        }

        public TileLayer[] GetLayers()
        {
            return this.layers;
        }

        public void Draw(Sprite s)
        {
            foreach(TileLayer layer in layers)
                if (layer.GetExists())
                {
                    layer.Draw(s, x, y);
                }
        }
    }
}
