using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public partial class GameForm : Form
    {
        Engine engine;

        public GameForm()
        {
            InitializeComponent();
            engine = new Engine(this, false);

            /*for (int i = 0; i < GameVariables.Tiles.GetLength(0); i++)
            {
                for (int y = 0; y < GameVariables.Tiles.GetLength(1); y++)
                {
                    GameVariables.Tiles[i, y] = new Tile(i * EngineVariables.TILE_WIDTH, y * EngineVariables.TILE_WIDTH);

                    Rectangle[] rects = new Rectangle[4];

                    rects[0] = new Rectangle(0, 0, EngineVariables.SUBTILE_WIDTH, EngineVariables.SUBTILE_WIDTH);
                    rects[1] = new Rectangle(EngineVariables.SUBTILE_WIDTH, 0, EngineVariables.SUBTILE_WIDTH, EngineVariables.SUBTILE_WIDTH);
                    rects[2] = new Rectangle(0, EngineVariables.SUBTILE_WIDTH, EngineVariables.SUBTILE_WIDTH, EngineVariables.SUBTILE_WIDTH);
                    rects[3] = new Rectangle(EngineVariables.SUBTILE_WIDTH, EngineVariables.SUBTILE_WIDTH, EngineVariables.SUBTILE_WIDTH, EngineVariables.SUBTILE_WIDTH);

                    GameVariables.Tiles[i, y].SetLayer(0, 3, rects);
                    GameVariables.Tiles[i, y].SetLayer(1, 0, rects);
                }
            }*/

            engine.Load();

            //GameVariables.GameObjects.Add(new GameObject(new Vector2(0, 0)));
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.StopLoop();
        }
    }
}
