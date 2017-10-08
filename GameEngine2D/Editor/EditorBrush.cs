using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine2D
{
    public class EditorBrush
    {
        private BrushType brushType;
        private GameTexture texture;

        private int layer;

        public EditorBrush(BrushType brushType)
        {
            this.brushType = brushType;

            this.texture = new GameTexture(String.Empty, TextureType.None);
            this.layer = 0;
        }

        public BrushType BrushType
        {
            get { return this.brushType; }
            set
            {
                this.brushType = value;
                this.Resetbrush();
            }
        }

        public GameTexture Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public int Layer
        {
            get { return this.layer; }
            set { this.layer = value; }
        }

        public void Resetbrush()
        {
            this.texture = new GameTexture(String.Empty, TextureType.None);
            this.layer = 0;
        }
    }
}
