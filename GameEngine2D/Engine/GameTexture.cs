using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameEngine2D
{
    public enum TextureType
    {
        None,
        Base,
        AutoTile,
        Wall
    }

    public enum AnimationType
    {
        None,
        AutoTile,
        Waterfall
    }

    public class GameTexture
    {
        private string sourceTexture;

        private TextureType textureType;
        private AnimationType animationType;

        private int startX;
        private int startY;

        private int sizeX;
        private int sizeY;

        private int frames;

        private Rectangle[] rects;

        public GameTexture(string sourceTexture, TextureType textureType)
        {
            this.sourceTexture = sourceTexture;
            this.textureType = textureType;

            this.startX = 0;
            this.startY = 0;

            this.sizeX = Default.TILE_WIDTH;
            this.sizeY = Default.TILE_WIDTH;

            this.frames = 0;

            this.rects = new Rectangle[4];
            this.rects[0] = new Rectangle(0, 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
            this.rects[1] = new Rectangle(Default.SUBTILE_WIDTH, 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
            this.rects[2] = new Rectangle(0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
            this.rects[3] = new Rectangle(Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
        }

        public GameTexture(string sourceTexture, TextureType textureType, int startX, int startY, int sizeX, int sizeY, Rectangle[] rects)
        {
            this.sourceTexture = sourceTexture;
            this.textureType = textureType;

            this.startX = startX;
            this.startY = startY;

            this.sizeX = sizeX;
            this.sizeY = sizeY;

            this.frames = 0;

            this.rects = rects;
        }

        public string SourceTexture
        {
            get { return this.sourceTexture; }
            set { this.sourceTexture = value; }
        }

        public TextureType TextureType
        {
            get { return this.textureType; }
            set { this.textureType = value; }
        }

        public AnimationType AnimationType
        {
            get { return this.animationType; }
            set { this.animationType = value; }
        }

        public int StartX
        {
            get { return this.startX; }
            set { this.startX = value; }
        }

        public int StartY
        {
            get { return this.startY; }
            set { this.startY = value; }
        }

        public int SizeX
        {
            get { return this.sizeX; }
            set { this.sizeX = value; }
        }

        public int SizeY
        {
            get { return this.sizeY; }
            set { this.sizeY = value; }
        }

        public int Frames
        {
            get { return this.frames; }
            set { this.frames = value; }
        }

        public Rectangle[] Rects
        {
            get { return this.rects; }
            set { this.rects = value; }
        }
    }
}
