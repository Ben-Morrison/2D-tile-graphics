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

        private static Camera camera;
        public static Camera Camera { get { return camera; } }

        private static Screen screen;
        public static Screen Screen { get { return screen; } }

        private Thread thread;
        private Stopwatch watch = new Stopwatch();

        public static Map map;

        public Engine(Control form, bool editor)
        {
            this.form = form;

            screen = new Screen();

            stateManager = new StateManager(editor);
            deviceManager = new DeviceManager(form, screen);
            contentManager = new ContentManager(deviceManager.Device);
            keyboardManager = new KeyboardManager(form);

            camera = new Camera(0, 0);

            if(!editor)
                StartLoop();
        }

        private void StartLoop()
        {
            if (!stateManager.Running)
            {
                thread = new Thread(new ThreadStart(GameLoop));
                thread.Start();
            }
        }

        public void StopLoop()
        {
            stateManager.Running = false;

            while (stateManager.IsDrawing)
            {
                Thread.Sleep(1);
            }

            deviceManager.Device.Dispose();
        }

        private void GameLoop()
        {
            float previousTime = 0.0f;
            float startTime = 0.0f;

            watch.Start();

            stateManager.Running = true;

            while (stateManager.Running)
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
            if (map != null)
                map.Update();

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
            stateManager.IsDrawing = true;

            deviceManager.Device.Clear(ClearFlags.Target, Color.Black, 0, 0);
            deviceManager.Device.BeginScene();

            Sprite s = new Sprite(deviceManager.Device);
            s.Begin(SpriteFlags.AlphaBlend);

            // Draw Current Map
            if (map != null)
                map.Draw(s);

            s.End();
            s.Dispose();

            deviceManager.Device.EndScene();
            deviceManager.Device.Present();

            stateManager.IsDrawing = false;
        }

        public void Save()
        {
            /*
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string filename = "save.sav";
            string fullpath = Path.Combine(path, filename);

            if (File.Exists(fullpath))
                File.Delete(fullpath);

            FileStream stream = File.Open(fullpath, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine();
            
            writer.Close();
            */
        }

        public void Load()
        {
            /*
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string filename = "save.sav";
            string fullpath = Path.Combine(path, filename);

            if (!File.Exists(fullpath))
                return;

            FileStream stream = File.Open(fullpath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            reader.ReadLine();

            reader.Close();
             * */
        }
    }
}
