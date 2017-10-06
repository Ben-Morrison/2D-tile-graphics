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
        private bool solid;
        private Point position;
        private TileLayer[] layers;

        public Tile(int x, int y)
        {
            this.position = new Point(x * Default.TILE_WIDTH, y * Default.TILE_WIDTH);

            layers = new TileLayer[2];
            layers[0] = new TileLayer();
            layers[1] = new TileLayer();
        }

        public Point Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public void SetLayer(int layer, GameTexture gameTexture)
        {
            this.layers[layer] = new TileLayer(gameTexture);
        }

        public TileLayer GetLayer(int layer)
        {
            return this.layers[layer];
        }

        public void DeleteLayer(int layer)
        {
            this.layers[layer].Exists = false;
        }

        public TileLayer[] GetLayers()
        {
            return this.layers;
        }

        public void Draw(Sprite s)
        {
            foreach(TileLayer layer in layers)
                if (layer.Exists)
                {
                    layer.Draw(s, position);
                }
        }
    }
}
