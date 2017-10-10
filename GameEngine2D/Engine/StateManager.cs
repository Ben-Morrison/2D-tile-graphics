using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace GameEngine2D
{
    public enum GameState
    {
        None,
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
        private bool initialized;
        private bool loopRunning;
        private GameState gameState;

        private bool editor;
        private bool debug;
        private bool isDrawing = false;

        private float delta = 0.0f;
        private float fps = 0;

        public StateManager(bool editor)
        {
            initialized = false;
            gameState = GameEngine2D.GameState.None;

            this.editor = editor;
        }

        public bool Initialized
        {
            get { return this.initialized; }
            set { this.initialized = value; }
        }

        public bool LoopRunning
        {
            get { return this.loopRunning; }
            set { this.loopRunning = value; }
        }

        public GameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
        }

        public bool Editor
        {
            get { return this.editor; }
        }

        public bool Debug
        {
            get { return this.debug; }
            set { this.debug = value; }
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
