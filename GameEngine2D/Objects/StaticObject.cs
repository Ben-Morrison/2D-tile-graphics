using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public class StaticObject
    {
        private int x;
        private int y;

        private int sizeX;
        private int sizeY;

        private int texture;     

        public StaticObject(int x, int y, int texture)
        {
            this.x = x;
            this.y = y;
            this.texture = texture;
        }

        public void SetX(int x) { this.x = x; }
        public void SetY(int y) { this.y = y; }
        public int GetX() { return this.x; }
        public int GetY() { return this.y; }
        public int GetTexture() { return this.texture; }
        public int GetSizeX() { return this.sizeX; }
        public int GetSizeY() { return this.sizeY; }

        public virtual void Use()
        {

        }

        public void Draw(Sprite s)
        {

        }
    }
}
