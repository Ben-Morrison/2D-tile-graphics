﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.IO;

namespace GameEngine2D
{
    public partial class GameForm : Form
    {
        Engine engine;

        public GameForm()
        {
            InitializeComponent();
            engine = new Engine(this, false);

            string path = Application.StartupPath + @"\save.gm";
            this.Text = Path.GetFileNameWithoutExtension(path);

            bool success = engine.OpenGame(path, false);

            if (!success)
                MessageBox.Show("Could not load game");
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.Uninitialize();
        }
    }
}
