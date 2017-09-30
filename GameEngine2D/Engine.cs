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
        private Device device;
        private Control form;
        private Thread thread;

        private Stopwatch watch = new Stopwatch();
        private float FPS = 0;

        public Engine(Control form, bool editor)
        {
            this.form = form;
            EngineVariables.editor = editor;
            InitDevice();
            LoadContent();
            KeyboardManager.InitKeyboard(form);
            StartLoop();
        }

        private void InitDevice()
        {
            PresentParameters pp = new PresentParameters();
            pp.BackBufferWidth = 1280;
            pp.BackBufferHeight = 720;
            pp.BackBufferFormat = Format.A8R8G8B8;
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;
            pp.DeviceWindow = this.form;

            device = new Device(0, DeviceType.Hardware, this.form, CreateFlags.HardwareVertexProcessing, pp);
        }

        private void LoadContent()
        {
            // Clear content
            Clean();

            // Create Defaults
            System.Drawing.Font systemFont = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular);
            EngineVariables.DefaultFont = new Microsoft.DirectX.Direct3D.Font(device, systemFont);
            string[] textures;
           
            // Get all tile textures
            textures = Directory.GetFiles(EngineVariables.TextureDirectory + @"\tiles");

            for (int i = 0; i < textures.Length; i++)
            {
                string name = Path.GetFileNameWithoutExtension(textures[i]);
                ImageInformation info = TextureLoader.ImageInformationFromFile(textures[i]);
                Texture texture = TextureLoader.FromFile(device, textures[i], info.Width, info.Height, 1, Usage.None, Format.A8R8G8B8, Pool.Managed, Filter.None, Filter.None, 0);
                EngineVariables.Textures.Add(texture);
                EngineVariables.TexturePaths.Add(Path.GetFullPath(textures[i]));
                EngineVariables.TextureNames.Add(name);
            }
        }

        private void StartLoop()
        {
            if (!EngineVariables.editor)
            {
                thread = new Thread(new ThreadStart(GameLoop));
                thread.Start();
            }
        }

        public void StopLoop()
        {
            EngineVariables.EngineRunning = false;

            while (EngineVariables.Drawing)
            {
                Thread.Sleep(1);
            }

            device.Dispose();

            // Clean Engine Variables
            Clean();

            EngineVariables.DefaultFont = null;
            EngineVariables.anim_tile_current = 0;
            EngineVariables.anim_tile_frame = 0;

            EngineVariables.editor = false;
            EngineVariables.Drawing = false;
            EngineVariables.EngineRunning = false;
            EngineVariables.SetGameState(GameStates.Initializing);
        }

        private void Clean()
        {
            EngineVariables.Textures.Clear();
            EngineVariables.TexturePaths.Clear();
            EngineVariables.TextureNames.Clear();
        }

        private void GameLoop()
        {
            float previousTime = 0.0f;
            float startTime = 0.0f;

            watch.Start();

            EngineVariables.EngineRunning = true;

            while (EngineVariables.EngineRunning)
            {
                startTime = watch.ElapsedMilliseconds;
                EngineVariables.SetDelta((startTime - previousTime) / 1000.0f);
                previousTime = startTime;

                FPS = 1 / EngineVariables.GetDelta();

                Input();
                Update();
                Draw();
            }
        }

        private void Input()
        {
            KeyboardManager.Update();
        }

        private void Update()
        {
            // Update Current Map
            if (EngineVariables.map != null)
                EngineVariables.map.Update();

            Anim();
        }

        public void Anim()
        {
            EngineVariables.anim_tile_current += EngineVariables.GetDelta();

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
            EngineVariables.Drawing = true;

            device.Clear(ClearFlags.Target, Color.Black, 0, 0);
            device.BeginScene();

            Sprite s = new Sprite(device);
            s.Begin(SpriteFlags.AlphaBlend);

            // Draw Current Map
            if (EngineVariables.map != null)
                EngineVariables.map.Draw(s);

            s.End();
            s.Dispose();
            
            device.EndScene();
            device.Present();

            EngineVariables.Drawing = false;
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
