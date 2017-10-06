using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameEngine2D
{
    static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Run(new Launcher());
        }
    }
}
