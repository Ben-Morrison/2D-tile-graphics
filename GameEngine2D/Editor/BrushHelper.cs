using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GameEngine2D
{
    /// <summary>
    /// Contains static methods for the different kind of brushes the editor will use
    /// </summary>
    public static class BrushHelper
    {
        /// <summary>
        /// Select a tile or object
        /// </summary>
        /// <param name="brush">The current Editor brush</param>
        /// <param name="e">The arguments from the Mouse</param>
        public static void DoSelect(EditorBrush brush, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Move a tile or object
        /// </summary>
        /// <param name="brush">The current Editor brush</param>
        /// <param name="e">The arguments from the Mouse</param>
        public static void DoMove(EditorBrush brush, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Place a texture on a tile
        /// </summary>
        /// <param name="brush">The current Editor brush</param>
        /// <param name="e">The arguments from the Mouse</param>
        public static void DoTexture(EditorBrush brush, MouseEventArgs e)
        {
            if (brush.Texture.TextureType != TextureType.None)
            {
                Room room = Engine.game.GetCurrentRoom();

                for (int i = 0; i < room.Tiles.GetLength(0); i++)
                {
                    for (int y = 0; y < room.Tiles.GetLength(1); y++)
                    {
                        Tile tile = room.Tiles[i, y];
                        if (e.X + Engine.Camera.Position.X >= tile.Position.X && e.X + Engine.Camera.Position.X < tile.Position.X + Default.TILE_WIDTH)
                        {
                            if (e.Y + Engine.Camera.Position.Y >= tile.Position.Y && e.Y + Engine.Camera.Position.Y < tile.Position.Y + Default.TILE_WIDTH)
                            {
                                if (brush.BrushType == BrushType.Texture)
                                {
                                    switch (brush.Texture.TextureType)
                                    {
                                        case TextureType.Base:
                                            Rectangle[] rects = new Rectangle[4];
                                            rects[0] = new Rectangle(brush.Texture.StartX, brush.Texture.StartY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                                            rects[1] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH, brush.Texture.StartY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                                            rects[2] = new Rectangle(brush.Texture.StartX, brush.Texture.StartY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                                            rects[3] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH, brush.Texture.StartY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

                                            brush.Texture.Rects = rects;
                                            tile.SetLayer(brush.Layer, brush.Texture);
                                            break;
                                        case TextureType.AutoTile:
                                            DoAutoTile(brush, brush.Texture, i, y, false, true);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void DoObject(EditorBrush brush)
        {

        }

        /// <summary>
        /// Places an autotile
        /// </summary>
        /// <param name="brush"></param>
        /// <param name="checkTexture"></param>
        /// <param name="i"></param>
        /// <param name="y"></param>
        /// <param name="checkonly"></param>
        /// <param name="repeat"></param>
        public static void DoAutoTile(EditorBrush brush, GameTexture checkTexture, int i, int y, bool checkonly, bool repeat)
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
                    if (Engine.game.GetCurrentRoom().Tiles[i - 1, y].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        left = true;

                // Get tile to the right
                if (i != Engine.game.GetCurrentRoom().Tiles.GetLength(0) - 1)
                    if (Engine.game.GetCurrentRoom().Tiles[i + 1, y].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        right = true;

                // Get tile above
                if (y != 0)
                    if (Engine.game.GetCurrentRoom().Tiles[i, y - 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        up = true;

                // Get tile below
                if (y != Engine.game.GetCurrentRoom().Tiles.GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().Tiles[i, y + 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        down = true;

                if (i != 0 && y != 0)
                    if (Engine.game.GetCurrentRoom().Tiles[i - 1, y - 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        leftup = true;

                if (i != Engine.game.GetCurrentRoom().Tiles.GetLength(0) - 1 && y != 0)
                    if (Engine.game.GetCurrentRoom().Tiles[i + 1, y - 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        rightup = true;

                if (i != 0 && y != Engine.game.GetCurrentRoom().Tiles.GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().Tiles[i - 1, y + 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        leftdown = true;

                if (i != Engine.game.GetCurrentRoom().Tiles.GetLength(0) - 1 && y != Engine.game.GetCurrentRoom().Tiles.GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().Tiles[i + 1, y + 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        rightdown = true;
            }
            else
            {
                if (i != 0)
                    if (Engine.game.GetCurrentRoom().Tiles[i - 1, y].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().Tiles[i - 1, y].Layers[brush.Layer].GameTexture.CompareTextures(checkTexture))
                            left = true;

                // Get tile to the right
                if (i != Engine.game.GetCurrentRoom().Tiles.GetLength(0) - 1)
                    if (Engine.game.GetCurrentRoom().Tiles[i + 1, y].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().Tiles[i + 1, y].Layers[brush.Layer].GameTexture.CompareTextures(checkTexture))
                            right = true;

                // Get tile above
                if (y != 0)
                    if (Engine.game.GetCurrentRoom().Tiles[i, y - 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().Tiles[i, y - 1].Layers[brush.Layer].GameTexture.CompareTextures(checkTexture))
                            up = true;

                // Get tile below
                if (y != Engine.game.GetCurrentRoom().Tiles.GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().Tiles[i, y + 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().Tiles[i, y + 1].Layers[brush.Layer].GameTexture.CompareTextures(checkTexture))
                            down = true;

                if (i != 0 && y != 0)
                    if (Engine.game.GetCurrentRoom().Tiles[i - 1, y - 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().Tiles[i - 1, y - 1].Layers[brush.Layer].GameTexture.CompareTextures(checkTexture))
                            leftup = true;

                if (i != Engine.game.GetCurrentRoom().Tiles.GetLength(0) - 1 && y != 0)
                    if (Engine.game.GetCurrentRoom().Tiles[i + 1, y - 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().Tiles[i + 1, y - 1].Layers[brush.Layer].GameTexture.CompareTextures(checkTexture))
                            rightup = true;

                if (i != 0 && y != Engine.game.GetCurrentRoom().Tiles.GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().Tiles[i - 1, y + 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().Tiles[i - 1, y + 1].Layers[brush.Layer].GameTexture.CompareTextures(checkTexture))
                            leftdown = true;

                if (i != Engine.game.GetCurrentRoom().Tiles.GetLength(0) - 1 && y != Engine.game.GetCurrentRoom().Tiles.GetLength(1) - 1)
                    if (Engine.game.GetCurrentRoom().Tiles[i + 1, y + 1].Layers[brush.Layer].GameTexture.TextureType == TextureType.AutoTile)
                        if (Engine.game.GetCurrentRoom().Tiles[i + 1, y + 1].Layers[brush.Layer].GameTexture.CompareTextures(checkTexture))
                            rightdown = true;

                Rectangle[] rects = new Rectangle[4];

                rects[0] = new Rectangle(brush.Texture.StartX, brush.Texture.StartY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[1] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH, brush.Texture.StartY, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[2] = new Rectangle(brush.Texture.StartX, brush.Texture.StartY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                rects[3] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH, brush.Texture.StartY + Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);

                // Top left
                if (left && up)
                {
                    rects[0] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, brush.Texture.StartY + Default.SUBTILE_WIDTH * 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && !up)
                {
                    rects[0] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, brush.Texture.StartY + Default.SUBTILE_WIDTH * 2, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!left && up)
                {
                    rects[0] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 0, brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && up && leftup)
                {
                    rects[0] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Top Right
                if (up && right)
                {
                    rects[1] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 3, brush.Texture.StartY + Default.SUBTILE_WIDTH * 0, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (up && !right)
                {
                    rects[1] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 3, brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!up && right)
                {
                    rects[1] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 1, brush.Texture.StartY + Default.SUBTILE_WIDTH * 2, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (up && right && rightup)
                {
                    rects[1] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 1, brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Bottom Left
                if (left && down)
                {
                    rects[2] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, brush.Texture.StartY + Default.SUBTILE_WIDTH * 1, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && !down)
                {
                    rects[2] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, brush.Texture.StartY + Default.SUBTILE_WIDTH * 5, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!left && down)
                {
                    rects[2] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 0, brush.Texture.StartY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (left && down && leftdown)
                {
                    rects[2] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 2, brush.Texture.StartY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                // Bottom Right
                if (down && right)
                {
                    rects[3] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 3, brush.Texture.StartY + Default.SUBTILE_WIDTH * 1, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (down && !right)
                {
                    rects[3] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 3, brush.Texture.StartY + Default.SUBTILE_WIDTH * 4, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (!down && right)
                {
                    rects[3] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 1, brush.Texture.StartY + Default.SUBTILE_WIDTH * 5, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }
                if (down && right && rightdown)
                {
                    rects[3] = new Rectangle(brush.Texture.StartX + Default.SUBTILE_WIDTH * 1, brush.Texture.StartY + Default.SUBTILE_WIDTH * 3, Default.SUBTILE_WIDTH, Default.SUBTILE_WIDTH);
                }

                brush.Texture.Rects = rects;
                //GameTexture texture = new GameTexture(brush., TextureType.AutoTile, brush.Texture.StartX, brush.Texture.StartY, Default.TILE_WIDTH, Default.TILE_WIDTH, rects);
                Engine.game.GetCurrentRoom().Tiles[i, y].SetLayer(brush.Layer, brush.Texture);
            }

            if (repeat)
            {
                if (left)
                    DoAutoTile(brush, Engine.game.GetCurrentRoom().Tiles[i - 1, y].Layers[brush.Layer].GameTexture, i - 1, y, false, false);
                if (right)
                    DoAutoTile(brush, Engine.game.GetCurrentRoom().Tiles[i + 1, y].Layers[brush.Layer].GameTexture, i + 1, y, false, false);
                if (up)
                    DoAutoTile(brush, Engine.game.GetCurrentRoom().Tiles[i, y - 1].Layers[brush.Layer].GameTexture, i, y - 1, false, false);
                if (down)
                    DoAutoTile(brush, Engine.game.GetCurrentRoom().Tiles[i, y + 1].Layers[brush.Layer].GameTexture, i, y + 1, false, false);
                if (leftup)
                    DoAutoTile(brush, Engine.game.GetCurrentRoom().Tiles[i - 1, y - 1].Layers[brush.Layer].GameTexture, i - 1, y - 1, false, false);
                if (rightup)
                    DoAutoTile(brush, Engine.game.GetCurrentRoom().Tiles[i + 1, y - 1].Layers[brush.Layer].GameTexture, i + 1, y - 1, false, false);
                if (leftdown)
                    DoAutoTile(brush, Engine.game.GetCurrentRoom().Tiles[i - 1, y + 1].Layers[brush.Layer].GameTexture, i - 1, y + 1, false, false);
                if (rightdown)
                    DoAutoTile(brush, Engine.game.GetCurrentRoom().Tiles[i + 1, y + 1].Layers[brush.Layer].GameTexture, i + 1, y + 1, false, false);
            }
        }
    }
}
