using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;

namespace GameEngine2D
{
    public class DeviceManager
    {
        private Device device;

        public DeviceManager(Control control, Screen screen)
        {
            PresentParameters pp = new PresentParameters();
            pp.BackBufferWidth = screen.SizeX;
            pp.BackBufferHeight = screen.SizeY ;
            pp.BackBufferFormat = Format.A8R8G8B8;
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;
            pp.DeviceWindow = control;

            this.device = new Device(0, DeviceType.Hardware, control, CreateFlags.HardwareVertexProcessing, pp);
        }

        public Device Device
        {
            get { return this.device; }
        }
    }
}
