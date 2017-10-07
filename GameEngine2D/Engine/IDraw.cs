using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    public interface IDraw
    {
        void Draw(Sprite s);
    }
}
