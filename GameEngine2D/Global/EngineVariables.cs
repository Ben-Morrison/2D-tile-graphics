using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public enum GameStates
    {
        Initializing,
        Intro,
        MainMenu,
        InGameSingleplayer,
        InGameSingleplayerPaused,
        InGameMultiplayerServer,
        InGameMultiplayerClient,
        InGameMultiplayerPaused,
        PostGame
    }

    public enum TextureType
    {
        Base,
        AutoTile,
        AnimatedAutoTile,
        AnimatedWaterfall,
        Wall
    }

    public static class EngineVariables
    {
        // Public variables
        public static Map map;

        // System
        public static int ScreenX = 1280;
        public static int ScreenY = 720;

        // Camera
        public static int CameraX = 0;
        public static int CameraY = 0;

        // Textures
        public static List<Texture> Textures = new List<Texture>();
        public static List<string> TextureNames = new List<string>();
        public static List<string> TexturePaths = new List<string>();

        public static Microsoft.DirectX.Direct3D.Font DefaultFont;
        public static readonly string TextureDirectory = @"C:\game\textures\";

        // Tiles
        public static readonly int TILE_WIDTH = 32;
        public static readonly int SUBTILE_WIDTH = 16;

        // Animation
        public static readonly float     anim_tile_delay = 0.50f;
        public static readonly int       anim_tile_frame_max = 3;
        public static readonly int       anim_tile_width = EngineVariables.TILE_WIDTH * 2;
        public static float              anim_tile_current = 0.0f;
        public static int                anim_tile_frame = 0;

        // Flags
        public static bool editor;
        public static bool Drawing = false;
        public static bool EngineRunning = false;

        // Private variables
        private static float delta = 0.0f;
        private static GameStates gameState;

        // Public Getters and Setters for private variables
        public static void SetDelta(float delta)
        {
            EngineVariables.delta = delta;
        }

        public static float GetDelta()
        {
            return EngineVariables.delta;
        }

        public static void SetGameState(GameStates state)
        {
            EngineVariables.gameState = state;
        }

        public static GameStates GetGameState()
        {
            return EngineVariables.gameState;
        }
    }


}
