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
            if (stateManager == null || !stateManager.Initialized)
            {
                stateManager = new StateManager(editor);
                screen = new Screen();
                deviceManager = new DeviceManager(form, screen);
                contentManager = new ContentManager(deviceManager.Device);
                keyboardManager = new KeyboardManager(form);
                dataManager = new GameEngine2D.DataManager(new SaveText());
                camera = new Camera(0, 0);
                stateManager.Initialized = true;

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

        public bool IsGameOpen()
        {
            return (stateManager.Initialized && game != null);
        }

        public bool NewGame(string path, bool editor)
        {
            if (IsGameOpen())
                CloseGame();

            Engine.game = new Game();
            bool success = dataManager.CreateFile(path);

            if (success)
            {
                return true;
            }
            else
            {
                CloseGame();
                return false;
            }
        }

        public bool OpenGame(string path, bool editor)
        {
            CloseGame();

            SaveClass success =  DataManager.OpenFile(path);

            if (success == null)
            {
                return false;
            }
            else
            {
                game = success.Game;

                foreach (KeyValuePair<string, Texture> o in success.Textures)
                {
                    contentManager.AddTexture(o.Key, o.Value);
                }

                if (!editor)
                    StartLoop();

                return true;
            }
        }            

        public bool SaveGame(string path)
        {
            if (IsGameOpen())
            {
                bool success = dataManager.CreateFile(path);

                if (success)
                    return true;
                else
                    return false;
            }
            else
                return false;

            /*
             * Check if the file exists
             * If exists close the file
             * Then delete the file
             * Create again from the gameobject
             * Open the file
             * Keep the file and keep it open until game is closed
             */

            // Return false if it failed
        }

        public void CloseGame()
        {
            Engine.game = null;
            contentManager.ClearContent();
            dataManager.CloseFile();
        }

        public void Uninitialize()
        {
            StopLoop();
            CloseGame();
            stateManager.Initialized = false;
        }

        private void StartLoop()
        {
            if (IsGameOpen() && !stateManager.LoopRunning)
            {
                thread = new Thread(new ThreadStart(GameLoop));
                thread.Start();

                stateManager.LoopRunning = true;
            }
        }

        public void StopLoop()
        {
            if (stateManager.LoopRunning)
            {
                stateManager.LoopRunning = false;

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

            while (stateManager.LoopRunning)
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
            if (IsGameOpen())
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

                if (IsGameOpen())
                    deviceManager.Device.Present();

                stateManager.IsDrawing = false;
            }
        }
    }
}
