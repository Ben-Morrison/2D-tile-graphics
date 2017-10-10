using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GameEngine2D
{
    public interface ISave
    {
        SaveClass LoadGame(FileStream file);
        void SaveGame(FileStream file, SaveClass game);
    }
}
