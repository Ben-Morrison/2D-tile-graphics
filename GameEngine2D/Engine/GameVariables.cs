using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public static class GameVariables
    {
        public static readonly int tiles_x = 40;
        public static readonly int tiles_y = 23;

        public static readonly float DEFAULT_WALKSPEED = 100.0f;
        public static readonly float DEFAULT_RUNSPEED = 250.0f;
        public static readonly float DEFAULT_PLAYER_ACCELERATION = 50.0f;
        public static readonly float MAX_PLAYER_VELOCITY = 200.0f;
    }
}
