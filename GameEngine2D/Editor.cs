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
        Engine engine;

        // Which item to place
        private int selectedLayer = 0;
        private int selectedTexture = 0;
        private int textureX = 0;
        private int textureY = 0;

        public enum BrushType
        {
            Base,
            AutoTile,
            AnimatedAutoTile,
            AnimatedWaterfall,
            Wall,
            Fill,
            Select,
            Remove
        }

        private BrushType Brush = BrushType.Base;

        public Editor()
        {
            InitializeComponent();

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

            Map map = new Map();

            Room room = new Room(100, 100);
            map.AddRoom(room);

            Engine.map = map;
        }

        #region Control Events

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
            TextureForm form = new TextureForm(selectedTexture, textureX, textureY, Brush);
            form.Show(this);
        }

        #endregion

        #endregion

        public void SetBrush(BrushType type, int texture, int x, int y)
        {
            this.Brush = type;
            this.selectedTexture = texture;
            this.textureX = x;
            this.textureY = y;
        }

        private void DoBrush(MouseEventArgs e)
        {
            Room room = Engine.map.GetCurrentRoom();

            switch(Brush)
            {
                case BrushType.Base:
                    for (int i = 0; i < room.GetTiles().GetLength(0); i++)
                    {
                        for (int y = 0; y < room.GetTiles().GetLength(1); y++)
                        {
                            Tile tile = room.GetTiles()[i, y];
                            if (e.X + Engine.Camera.X >= tile.GetX() && e.X + Engine.Camera.X < tile.GetX() + Default.TILE_WIDTH)
                            {
                                if (e.Y + Engine.Camera.Y >= tile.GetY() && e.Y + Engine.Camera.Y < tile.GetY() + Default.TILE_WIDTH)
                                {
                                    Rectangle[] rects = new Rectangle[4];
                                    rects[0] = new Rectangle(textureX, textureY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                                    rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH, textureY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                                    rects[2] = new Rectangle(textureX, textureY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                                    rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH, textureY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

                                    tile.SetLayer(this.selectedLayer, selectedTexture, rects, TextureType.Base, this.textureX, this.textureY);
                                }
                            }

                        }
                    }
                break;

                case BrushType.AutoTile:
                    for (int i = 0; i < room.GetTiles().GetLength(0); i++)
                    {
                        for (int y = 0; y < room.GetTiles().GetLength(1); y++)
                        {
                            Tile tile = room.GetTiles()[i, y];
                            if (e.X + Engine.Camera.X >= tile.GetX() && e.X + Engine.Camera.X < tile.GetX() + Default.TILE_WIDTH)
                            {
                                if (e.Y + Engine.Camera.Y >= tile.GetY() && e.Y + Engine.Camera.Y < tile.GetY() + Default.TILE_WIDTH)
                                {
                                    DoAutoTile(selectedTexture, i, y, false, true);
                                }
                            }

                        }
                    }
                    break;

                case BrushType.AnimatedAutoTile:
                    for (int i = 0; i < room.GetTiles().GetLength(0); i++)
                    {
                        for (int y = 0; y < room.GetTiles().GetLength(1); y++)
                        {
                            Tile tile = room.GetTiles()[i, y];
                            if (e.X + Engine.Camera.X >= tile.GetX() && e.X + Engine.Camera.X < tile.GetX() + Default.TILE_WIDTH)
                            {
                                if (e.Y + Engine.Camera.Y >= tile.GetY() && e.Y + Engine.Camera.Y < tile.GetY() + Default.TILE_WIDTH)
                                {
                                    DoAnimatedAutoTile(selectedTexture, i, y, false, true);
                                }
                            }

                        }
                    }
                    break;
            }

            engine.Draw();
        }

        private void DoAutoTile(int checkTexture, int i, int y, bool checkonly, bool repeat)
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
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                            left = true;

                // Get tile to the right
                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                            right = true;

                // Get tile above
                if (y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                            up = true;

                // Get tile below
                if (y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                            down = true;

                if (i != 0 && y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                            leftup = true;

                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                            rightup = true;

                if (i != 0 && y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                            leftdown = true;

                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                            rightdown = true;
            }
            else
            {
                if (i != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetX() == textureX &&
                               Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetY() == textureY)
                                left = true;

                // Get tile to the right
                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetY() == textureY)
                                    right = true;

                // Get tile above
                if (y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetY() == textureY)
                                    up = true;

                // Get tile below
                if (y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetY() == textureY)
                                    down = true;

                if (i != 0 && y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetY() == textureY)
                                    leftup = true;

                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetY() == textureY)
                                    rightup = true;

                if (i != 0 && y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetY() == textureY)
                                    leftdown = true;

                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetY() == textureY)
                            rightdown = true;

                Rectangle[] rects = new Rectangle[4];

                rects[0] = new Rectangle(textureX, textureY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH, textureY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[2] = new Rectangle(textureX, textureY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH, textureY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

                // Top left
                if (left && up)
                {
                    rects[0] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && !up)
                {
                    rects[0] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 2, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!left && up)
                {
                    rects[0] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 0, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && up && leftup)
                {
                    rects[0] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Top Right
                if (up && right)
                {
                    rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 3, textureY + Default.SUBTILE_WIDTH * 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (up && !right)
                {
                    rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 3, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!up && right)
                {
                    rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 1, textureY + Default.SUBTILE_WIDTH * 2, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (up && right && rightup)
                {
                    rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 1, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Bottom Left
                if (left && down)
                {
                    rects[2] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 1, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && !down)
                {
                    rects[2] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 5, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!left && down)
                {
                    rects[2] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 0, textureY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && down && leftdown)
                {
                    rects[2] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Bottom Right
                if (down && right)
                {
                    rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 3, textureY + Default.SUBTILE_WIDTH * 1, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (down && !right)
                {
                    rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 3, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!down && right)
                {
                    rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 1, textureY + Default.SUBTILE_WIDTH * 5, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (down && right && rightdown)
                {
                    rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 1, textureY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                Engine.map.GetCurrentRoom().GetTiles()[i, y].SetLayer(selectedLayer, checkTexture, rects, TextureType.AutoTile, textureX, textureY);
            }

            if (repeat)
            {
                if (left)
                    DoAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetTexture(), i - 1, y, false, false);
                if (right)
                    DoAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetTexture(), i + 1, y, false, false);
                if (up)
                    DoAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetTexture(), i, y - 1, false, false);
                if (down)
                    DoAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetTexture(), i, y + 1, false, false);
                if (leftup)
                    DoAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetTexture(), i - 1, y - 1, false, false);
                if (rightup)
                    DoAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetTexture(), i + 1, y - 1, false, false);
                if (leftdown)
                    DoAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetTexture(), i - 1, y + 1, false, false);
                if (rightdown)
                    DoAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetTexture(), i + 1, y + 1, false, false);
            }
        }
        private void DoAnimatedAutoTile(int checkTexture, int i, int y, bool checkonly, bool repeat)
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
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        left = true;

                // Get tile to the right
                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        right = true;

                // Get tile above
                if (y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        up = true;

                // Get tile below
                if (y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        down = true;

                if (i != 0 && y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        leftup = true;

                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        rightup = true;

                if (i != 0 && y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        leftdown = true;

                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        rightdown = true;
            }
            else
            {
                if (i != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetX() == textureX &&
                               Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetY() == textureY)
                                left = true;

                // Get tile to the right
                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetY() == textureY)
                                right = true;

                // Get tile above
                if (y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetY() == textureY)
                                up = true;

                // Get tile below
                if (y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetY() == textureY)
                                down = true;

                if (i != 0 && y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetY() == textureY)
                                leftup = true;

                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != 0)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetY() == textureY)
                                rightup = true;

                if (i != 0 && y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetY() == textureY)
                                leftdown = true;

                if (i != Engine.map.GetCurrentRoom().GetTiles().GetLength(0) - 1 && y != Engine.map.GetCurrentRoom().GetTiles().GetLength(1) - 1)
                    if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetTextureType() == TextureType.AnimatedAutoTile)
                        if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetTexture() == checkTexture)
                            if (Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetX() == textureX &&
                                Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetY() == textureY)
                                rightdown = true;

                Rectangle[] rects = new Rectangle[4];

                rects[0] = new Rectangle(textureX, textureY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH, textureY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[2] = new Rectangle(textureX, textureY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH, textureY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

                // Top left
                if (left && up)
                {
                    rects[0] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && !up)
                {
                    rects[0] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 2, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!left && up)
                {
                    rects[0] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 0, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && up && leftup)
                {
                    rects[0] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Top Right
                if (up && right)
                {
                    rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 3, textureY + Default.SUBTILE_WIDTH * 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (up && !right)
                {
                    rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 3, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!up && right)
                {
                    rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 1, textureY + Default.SUBTILE_WIDTH * 2, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (up && right && rightup)
                {
                    rects[1] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 1, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Bottom Left
                if (left && down)
                {
                    rects[2] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 1, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && !down)
                {
                    rects[2] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 5, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!left && down)
                {
                    rects[2] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 0, textureY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && down && leftdown)
                {
                    rects[2] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 2, textureY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Bottom Right
                if (down && right)
                {
                    rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 3, textureY + Default.SUBTILE_WIDTH * 1, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (down && !right)
                {
                    rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 3, textureY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!down && right)
                {
                    rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 1, textureY + Default.SUBTILE_WIDTH * 5, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (down && right && rightdown)
                {
                    rects[3] = new Rectangle(textureX + Default.SUBTILE_WIDTH * 1, textureY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                Engine.map.GetCurrentRoom().GetTiles()[i, y].SetLayer(selectedLayer, checkTexture, rects, TextureType.AnimatedAutoTile, textureX, textureY);
            }

            if (repeat)
            {
                if (left)
                    DoAnimatedAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i - 1, y].GetLayer(selectedLayer).GetTexture(), i - 1, y, false, false);
                if (right)
                    DoAnimatedAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i + 1, y].GetLayer(selectedLayer).GetTexture(), i + 1, y, false, false);
                if (up)
                    DoAnimatedAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i, y - 1].GetLayer(selectedLayer).GetTexture(), i, y - 1, false, false);
                if (down)
                    DoAnimatedAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i, y + 1].GetLayer(selectedLayer).GetTexture(), i, y + 1, false, false);
                if (leftup)
                    DoAnimatedAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i - 1, y - 1].GetLayer(selectedLayer).GetTexture(), i - 1, y - 1, false, false);
                if (rightup)
                    DoAnimatedAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i + 1, y - 1].GetLayer(selectedLayer).GetTexture(), i + 1, y - 1, false, false);
                if (leftdown)
                    DoAnimatedAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i - 1, y + 1].GetLayer(selectedLayer).GetTexture(), i - 1, y + 1, false, false);
                if (rightdown)
                    DoAnimatedAutoTile(Engine.map.GetCurrentRoom().GetTiles()[i + 1, y + 1].GetLayer(selectedLayer).GetTexture(), i + 1, y + 1, false, false);
            }
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.StopLoop();
        }
    }
}
