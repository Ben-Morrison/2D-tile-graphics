using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectInput;

namespace GameEngine2D
{
    public class Player : Unit
    {
        public Player(Vector2 pos, Room room)
            : base(pos, room)
        {

        }

        public override void Update(List<GameObject> objects)
        {
            Vector2 moveVector = new Vector2(0, 0);

            if (Engine.KeyboardManager.IsKeyHeld(Key.W))
                moveVector += new Vector2(0, -1);
            if (Engine.KeyboardManager.IsKeyHeld(Key.A))
                moveVector += new Vector2(-1, 0);
            if (Engine.KeyboardManager.IsKeyHeld(Key.S))
                moveVector += new Vector2(0, 1);
            if (Engine.KeyboardManager.IsKeyHeld(Key.D))
                moveVector += new Vector2(1, 0);

            Move(moveVector, GameVariables.DEFAULT_RUNSPEED);

            if (Engine.KeyboardManager.IsKeyPressedOnce(Key.Space))
                if (this.GetFloating() == true) { this.SetFloating(false); }
                else { this.SetFloating(true); }

            if (this.GetFloating())
            {
                this.SetPos(this.GetPos() + (this.GetVelocity() * Engine.StateManager.Delta));
            }
        }
    }
}
