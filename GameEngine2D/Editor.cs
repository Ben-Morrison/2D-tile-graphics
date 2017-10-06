using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public partial class Editor : Form
    {
        public enum BrushType
        {
            Select,
            Move,
            Texture,
            Object
        }

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
                    this.ResetBrush();
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

            public void ResetBrush()
            {
                this.texture = new GameTexture(String.Empty, TextureType.None);
                this.layer = 0;
            }
        }

        Engine engine;

        // Has the current game been saved
        private bool saved = false;
        public static EditorBrush Brush;

        public Editor()
        {
            InitializeComponent();

            Brush = new EditorBrush(BrushType.Select);
            engine = new Engine(EditorPanel, true);

            InitControls();
            LoadDefaultData();
        }

        private void InitControls()
        {
            
        }

        private void LoadDefaultData()
        {
            //engine.Load();

            Game game = new Game();

            Room room = new Room(100, 100);
            game.AddRoom(room);

            Engine.game = game;
        }

        #region Control Events

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.Uninitialize();
        }

        private void EditorPanel_Paint(object sender, PaintEventArgs e)
        {
            engine.Draw();
        }

        private void EditorPanel_MouseDown(object sender, MouseEventArgs e)
        {
            DoBrush(e);
        }

        private void EditorPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                DoBrush(e);
        }

        #region Camera

        private void btnRight_Click(object sender, EventArgs e)
        {
            Engine.Camera.Move(10, 0);
            engine.Draw();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            Engine.Camera.Move(-10, 0);
            engine.Draw();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Engine.Camera.Move(0, -10);
            engine.Draw();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Engine.Camera.Move(0, 10);
            engine.Draw();
        }

        #endregion

        #region Menu

        // File



        // Content

        private void menuTextures_Click(object sender, EventArgs e)
        {
            TextureForm form = new TextureForm(Brush);
            form.Show(this);
        }

        #endregion

        #endregion

        #region Brush Functions

        private void DoBrush(MouseEventArgs e)
        {
            if (Engine.StateManager.EngineState == EngineState.Running)
            {
                switch (Brush.BrushType)
                {
                    case BrushType.Select:
                        break;
                    case BrushType.Move:
                        break;
                    case BrushType.Texture:
                        DoTexture(e);
                        break;
                    case BrushType.Object:
                        break;
                    default:
                        break;
                }
            }
        }

        private void DoSelect(MouseEventArgs e)
        {

        }

        private void DoMove(MouseEventArgs e)
        {

        }

        private void DoTexture(MouseEventArgs e)
        {
            if (Brush.Texture.TextureType != TextureType.None)
            {
                Room room = Engine.game.GetCurrentRoom();

                for (int i = 0; i < room.GetTiles().GetLength(0); i++)
                {
                    for (int y = 0; y < room.GetTiles().GetLength(1); y++)
                    {
                        Tile tile = room.GetTiles()[i, y];
                        if (e.X + Engine.Camera.X >= tile.Position.X && e.X + Engine.Camera.X < tile.Position.X + Default.TILE_WIDTH)
                        {
                            if (e.Y + Engine.Camera.Y >= tile.Position.Y && e.Y + Engine.Camera.Y < tile.Position.Y + Default.TILE_WIDTH)
                            {
                                if (Brush.BrushType == BrushType.Texture)
                                {
                                    switch (Brush.Texture.TextureType)
                                    {
                                        case TextureType.Base:
                                            Rectangle[] rects = new Rectangle[4];
                                            rects[0] = new Rectangle(Brush.Texture.StartX, Brush.Texture.StartY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                                            rects[1] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH, Brush.Texture.StartY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                                            rects[2] = new Rectangle(Brush.Texture.StartX, Brush.Texture.StartY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                                            rects[3] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH, Brush.Texture.StartY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

                                            tile.SetLayer(Brush.Layer, Brush.Texture);
                                            break;

                                        case TextureType.AutoTile:
                                            DoAutoTile(Brush.Texture, i, y, false, true);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }

                engine.Draw();
            }
        }

        private void DoObject()
        {

        }

        private void DoAutoTile(GameTexture checkTexture, int i, int y, bool checkonly, bool repeat)
        {
            bool left = false;
            bool right = false;
            bool up = false;
            bool down = false;

            bool leftup = false;
            bool rightup = false;
            bool leftdown = false;
            bool rightdown = false;

            if (checkonly)
            {
                if (i != 0)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                            left = true;

                // Get tile to the right
                if (i != Engine.game.GetCurrentRoom().GetTiles().GetLength(0) - 1)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                            right = true;

                // Get tile above
                if (y != 0)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                            up = true;

                // Get tile below
                if (y != Engine.game.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                            down = true;

                if (i != 0 && y != 0)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                            leftup = true;

                if (i != Engine.game.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != 0)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                            rightup = true;

                if (i != 0 && y != Engine.game.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                            leftdown = true;

                if (i != Engine.game.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != Engine.game.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                            rightdown = true;
            }
            else
            {
                if (i != 0)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(Brush.Layer).GameTexture.Equals(checkTexture))
                            left = true;

                // Get tile to the right
                if (i != Engine.game.GetCurrentRoom().GetTiles().GetLength(0) - 1)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(Brush.Layer).GameTexture.Equals(checkTexture))
                            right = true;

                // Get tile above
                if (y != 0)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(Brush.Layer).GameTexture.Equals(checkTexture))
                                    up = true;

                // Get tile below
                if (y != Engine.game.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(Brush.Layer).GameTexture.Equals(checkTexture))
                                    down = true;

                if (i != 0 && y != 0)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(Brush.Layer).GameTexture.Equals(checkTexture))
                                    leftup = true;

                if (i != Engine.game.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != 0)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(Brush.Layer).GameTexture.Equals(checkTexture))
                                    rightup = true;

                if (i != 0 && y != Engine.game.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(Brush.Layer).GameTexture.Equals(checkTexture))
                                    leftdown = true;

                if (i != Engine.game.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != Engine.game.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(Brush.Layer).GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(Brush.Layer).GameTexture.Equals(checkTexture))
                            rightdown = true;

                Rectangle[] rects = new Rectangle[4];

                rects[0] = new Rectangle(Brush.Texture.StartX, Brush.Texture.StartY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[1] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH, Brush.Texture.StartY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[2] = new Rectangle(Brush.Texture.StartX, Brush.Texture.StartY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[3] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH, Brush.Texture.StartY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

                // Top left
                if (left && up)
                {
                    rects[0] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && !up)
                {
                    rects[0] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 2, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!left && up)
                {
                    rects[0] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 0, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && up && leftup)
                {
                    rects[0] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Top Right
                if (up && right)
                {
                    rects[1] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 3, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (up && !right)
                {
                    rects[1] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 3, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!up && right)
                {
                    rects[1] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 1, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 2, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (up && right && rightup)
                {
                    rects[1] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 1, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Bottom Left
                if (left && down)
                {
                    rects[2] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 1, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && !down)
                {
                    rects[2] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 5, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!left && down)
                {
                    rects[2] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 0, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && down && leftdown)
                {
                    rects[2] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Bottom Right
                if (down && right)
                {
                    rects[3] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 3, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 1, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (down && !right)
                {
                    rects[3] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 3, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!down && right)
                {
                    rects[3] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 1, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 5, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (down && right && rightdown)
                {
                    rects[3] = new Rectangle(Brush.Texture.StartX + Default.SUBTILE_WIDTH * 1, Brush.Texture.StartY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                GameTexture texture = new GameTexture("default", TextureType.AutoTile, Brush.Texture.StartX, Brush.Texture.StartY, Default.TILE_WIDTH, Default.TILE_WIDTH, rects);
                Engine.game.GetCurrentRoom().GetTiles()[i, y].SetLayer(Brush.Layer, texture);
            }

            if (repeat)
            {
                if (left)
                    DoAutoTile(Engine.game.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(Brush.Layer).GameTexture, i - 1, y, false, false);
                if (right)
                    DoAutoTile(Engine.game.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(Brush.Layer).GameTexture, i + 1, y, false, false);
                if (up)
                    DoAutoTile(Engine.game.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(Brush.Layer).GameTexture, i, y - 1, false, false);
                if (down)
                    DoAutoTile(Engine.game.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(Brush.Layer).GameTexture, i, y + 1, false, false);
                if (leftup)
                    DoAutoTile(Engine.game.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(Brush.Layer).GameTexture, i - 1, y - 1, false, false);
                if (rightup)
                    DoAutoTile(Engine.game.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(Brush.Layer).GameTexture, i + 1, y - 1, false, false);
                if (leftdown)
                    DoAutoTile(Engine.game.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(Brush.Layer).GameTexture, i - 1, y + 1, false, false);
                if (rightdown)
                    DoAutoTile(Engine.game.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(Brush.Layer).GameTexture, i + 1, y + 1, false, false);
            }
        }

        #endregion
    }
}
