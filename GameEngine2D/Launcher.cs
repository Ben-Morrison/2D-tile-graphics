using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameEngine2D
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            GameForm form = new GameForm();
            form.Show();
            this.Hide();

            form.FormClosing += new FormClosingEventHandler(ShowLauncher);
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            Editor form = new Editor();
            form.Show();
            this.Hide();

            form.FormClosing += new FormClosingEventHandler(ShowLauncher);
        }

        public void ShowLauncher(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
