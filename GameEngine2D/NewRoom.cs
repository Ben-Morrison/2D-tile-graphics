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
    public partial class NewRoom : Form
    {
        public NewRoom()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Editor form = (Editor)(this.Owner);

            string name = textName.Text;

            try
            {
                bool error = false;

                int x = int.Parse(textWidth.Text);
                int y = int.Parse(textHeight.Text);

                if(x > Default.ROOM_MAX_SIZE_X)
                {
                    MessageBox.Show("Height cannot be larger than: " + Default.ROOM_MAX_SIZE_X, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }

                if(x > Default.ROOM_MAX_SIZE_X)
                {
                    MessageBox.Show("Height cannot be larger than: " + Default.ROOM_MAX_SIZE_X, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    error = true;
                }

                if(!error)
                {
                    form.AddRoom(name, x, y);
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Enter a correct value for width and height\n" + ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
