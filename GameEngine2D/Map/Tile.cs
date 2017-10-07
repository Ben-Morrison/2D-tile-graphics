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
    public class Tile : IPosition, IDraw
    {
        private Point position;
        private TileLayer[] layers;

        public Tile(int x, int y)
        {
            this.position = new Point(x * Default.TILE_WIDTH, y * Default.TILE_WIDTH);
            this.layers = new TileLayer[2];

            this.layers[0] = new TileLayer(new GameTexture("defalt", TextureType.None));
            this.layers[1] = new TileLayer(new GameTexture("defalt", TextureType.None));
        }

        public Point Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public TileLayer[] Layers
        {
            get { return this.layers; }
        }

        public void SetLayer(int layer, GameTexture texture)
        {
            this.layers[layer].GameTexture = texture;
        }

        public void Draw(Sprite s)
        {
            foreach (TileLayer l in layers)
            {
                l.Draw(s, this.position);
            }
        }
    }
}
