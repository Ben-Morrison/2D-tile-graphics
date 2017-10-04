using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;
using System.IO;

namespace GameEngine2D
{
    public class EngineVariables
    {
        // Animation
        public static readonly float   anim_tile_delay = 0.50f;
        public static readonly int anim_tile_frame_max = 3;
        public static readonly int anim_tile_width = Default.TILE_WIDTH * 2;
        public static float anim_tile_current = 0.0f;
        public static int anim_tile_frame = 0;
    }
}
