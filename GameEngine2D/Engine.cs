using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Reflection;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public class Engine
    {
        private Control form;

        // Engine components
        private static StateManager stateManager;
        public static StateManager StateManager { get { return stateManager; } }

        private static DeviceManager deviceManager;
        public static DeviceManager DeviceManager { get { return deviceManager; } }

        private static ContentManager contentManager;
        public static ContentManager ContentManager { get { return contentManager; } }

        private static KeyboardManager keyboardManager;
        public static KeyboardManager KeyboardManager { get { return keyboardManager; } }

        private static DataManager dataManager;
        public static DataManager DataManager { get { return dataManager; } }

        private static Camera camera;
        public static Camera Camera { get { return camera; } }

        private static Screen screen;
        public static Screen Screen { get { return screen; } }

        private Thread thread;
        private Stopwatch watch = new Stopwatch();

        public static Game game;

        public Engine(Control form, bool editor)
        {
            this.form = form;
            Initialize(editor);
        }

        public void Initialize(bool editor)
        {
            if (stateManager == null || stateManager.EngineState == EngineState.Stopped)
            {
                stateManager = new StateManager(editor);
                screen = new Screen();
                deviceManager = new DeviceManager(form, screen);
                contentManager = new ContentManager(deviceManager.Device);
                keyboardManager = new KeyboardManager(form);
                dataManager = new GameEngine2D.DataManager();
                stateManager.EngineState = EngineState.Initialized;
                camera = new Camera(0, 0);

                if (editor)
                {

                }
                else
                {
                    OpenGame("game", false);
                }
            }
            else
            {
                MessageBox.Show("Engine already running");
            }
        }

        /// <summary>
        /// Creates a new game
        /// If a game is currently running
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <param name="editor">Is the editor running</param>
        /// <returns>Returns success or failure</returns>
        public bool NewGame(string path, bool editor)
        {
            if (Engine.game == null)
            {
                Engine.game = new Game();
                bool success = dataManager.CreateFile(path);

                if (success)
                {
                    Engine.StateManager.EngineState = EngineState.GameRunning;
                    return success;
                }
                else
                {
                    CloseGame();
                    return success;
                }
            }
            else
            {
                CloseGame();
                Engine.game = new Game();
                return dataManager.CreateFile(path);
            }
        }

        public bool OpenGame(string path, bool editor)
        {
            if (game == null)
            {
                
            }
            else
            {
                CloseGame();
            }

            /*
             * If a current game is open (not null), null the game and close the file
             * Open a file with DataManager
             * Get the data from the file
             * Create the Game object from the file
             * Keep the file open until the game is closed
             */

            // Return false if it failed
            return false;
        }

        public bool SaveGame(string path)
        {
            /*
             * Check if the file exists
             * If exists close the file
             * Then delete the file
             * Create again from the gameobject
             * Open the file
             * Keep the file and keep it open until game is closed
             */

            // Return false if it failed
            return false;
        }

        public void CloseGame()
        {
            Engine.game = null;
            dataManager.CloseFile();
            stateManager.EngineState = EngineState.Initialized;
        }

        public void Uninitialize()
        {
            StopLoop();
            CloseGame();
            stateManager.EngineState = EngineState.Stopped;
        }

        private void StartLoop()
        {
            if (stateManager.EngineState == EngineState.Initialized)
            {
                stateManager.EngineState = EngineState.GameRunning;

                thread = new Thread(new ThreadStart(GameLoop));
                thread.Start();
            }
        }

        public void StopLoop()
        {
            if (stateManager.EngineState == EngineState.GameRunning)
            {
                stateManager.EngineState = EngineState.Initialized;

                while (stateManager.IsDrawing)
                {
                    Thread.Sleep(1);
                }

                try
                {
                    thread.Abort();
                }
                catch (Exception e)
                {

                }
            }
        }

        private void GameLoop()
        {
            float previousTime = 0.0f;
            float startTime = 0.0f;

            watch.Start();

            while (stateManager.EngineState == EngineState.GameRunning)
            {
                startTime = watch.ElapsedMilliseconds;
                stateManager.Delta = ((startTime - previousTime) / 1000.0f);
                previousTime = startTime;

                stateManager.FPS = 1 / stateManager.Delta;

                Input();
                Update();
                Draw();
            }
        }

        private void Input()
        {
            keyboardManager.Update();
        }

        private void Update()
        {
            // Update Current Map
            if (game != null)
                game.Update();

            Anim();
        }

        public void Anim()
        {
            EngineVariables.anim_tile_current += stateManager.Delta;

            if (EngineVariables.anim_tile_current >= EngineVariables.anim_tile_delay)
            {
                EngineVariables.anim_tile_current = 0;
                EngineVariables.anim_tile_frame++;

                if (EngineVariables.anim_tile_frame >= EngineVariables.anim_tile_frame_max)
                    EngineVariables.anim_tile_frame = 0;
            }
        }

        public void Draw()
        {
            if (stateManager.EngineState == EngineState.GameRunning)
            {
                stateManager.IsDrawing = true;

                deviceManager.Device.Clear(ClearFlags.Target, Color.RoyalBlue, 0, 0);
                deviceManager.Device.BeginScene();

                Sprite s = new Sprite(deviceManager.Device);
                s.Begin(SpriteFlags.AlphaBlend);

                // Draw Current Map
                if (game != null)
                    game.Draw(s);

                s.End();
                s.Dispose();

                deviceManager.Device.EndScene();

                if (stateManager.EngineState == EngineState.GameRunning)
                    deviceManager.Device.Present();

                stateManager.IsDrawing = false;
            }
        }
    }
}
