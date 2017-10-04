using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine2D
{
    public class Screen
    {
        int sizeX;
        int sizeY;

        public Screen()
        {
            this.sizeX = Default.SCREEN_SIZE_X;
            this.sizeY = Default.SCREEN_SIZE_Y;
        }

        public int SizeX
        {
            get { return this.sizeX; }
        }

        public int SizeY
        {
            get { return this.sizeY; }
        }
    }
}
