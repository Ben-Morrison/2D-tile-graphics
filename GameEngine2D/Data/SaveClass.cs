using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public class SaveClass
    {
        private Game game;
        private Dictionary<string, Texture> textures;

        public SaveClass(Game game, Dictionary<string, Texture> textures)
        {
            this.game = game;
            this.textures = textures;
        }

        public Game Game
        {
            get { return this.game; }
        }

        public Dictionary<string, Texture> Textures
        {
            get { return this.textures; }
        }
    }
}
