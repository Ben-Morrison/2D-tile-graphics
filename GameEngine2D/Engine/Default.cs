﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameEngine2D
{
    public static class Default
    {
        public static readonly int      SCREEN_SIZE_X = 1280;
        public static readonly int      SCREEN_SIZE_Y = 720;

        public static readonly string   CONTENT_DIRECTORY = Application.StartupPath + @"\content";
        public static readonly string   TEXTURE_DIRECTORY = CONTENT_DIRECTORY + @"\textures";

        public static readonly int      TILE_WIDTH = 32;
        public static readonly int      SUBTILE_WIDTH = 16;
    }
}