using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

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

    public class StateManager
    {
        private GameStates gameState;

        private bool running = false;
        private bool editor = false;
        private bool isDrawing = false;

        private float delta = 0.0f;
        private float fps = 0;

        public StateManager(bool editor)
        {
            gameState = GameStates.Initializing;
        }

        public GameStates GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        public bool Running
        {
            get { return this.running; }
            set { this.running = value; }
        }

        public bool Editor
        {
            get { return this.editor; }
        }

        public bool IsDrawing
        {
            get { return this.isDrawing; }
            set { this.isDrawing = value; }
        }

        public float Delta
        {
            get { return this.delta; }
            set { this.delta = value; }
        }

        public float FPS
        {
            get { return this.fps; }
            set { this.fps = value; }
        }
    }
}
