using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace GameEngine2D
{
    public enum EngineState
    {
        Stopped,
        Initialized,
        GameRunning
    }

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
        private EngineState engineState;
        private GameState gameState;

        private bool editor;
        private bool isDrawing = false;

        private float delta = 0.0f;
        private float fps = 0;

        public StateManager(bool editor)
        {
            engineState = GameEngine2D.EngineState.Stopped;
            gameState = GameEngine2D.GameState.None;

            this.editor = editor;
        }

        public EngineState EngineState
        {
            get { return this.engineState; }
            set { this.engineState = value; }
        }

        public GameState GameState
        {
            get { return this.gameState; }
            set { this.gameState = value; }
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
