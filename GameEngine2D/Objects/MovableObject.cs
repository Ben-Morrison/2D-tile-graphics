using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectInput;

namespace GameEngine2D
{
    public class MovableObject : GameObject
    {
        private bool floating;
        Vector2 vel;

        int speed;
        int maxSpeed;
        float acceleration;

        public MovableObject(Vector2 pos, Room room)
            : base(pos, room)
        {

        }

        public void SetFloating(bool floating)
        {
            if (floating == false)
                this.vel = new Vector2(0, 0);

            this.floating = floating;
        }

        public bool GetFloating()
        {
            return this.floating;
        }

        public Vector2 GetVelocity()
        {
            return this.vel;
        }

        public virtual void Move(Vector2 dir, float speed)
        {
            dir.Normalize();

            if (this.GetFloating())
            {
                if (vel.Length() > GameVariables.MAX_PLAYER_VELOCITY)
                {
                    vel.Normalize();
                    vel = vel * GameVariables.MAX_PLAYER_VELOCITY;
                }

                vel += (dir * (acceleration * EngineVariables.GetDelta()));
            }
            else
            {
                float distanceMovedThisFrame = (speed * EngineVariables.GetDelta());
                this.SetPos(this.GetPos() + (dir * distanceMovedThisFrame));
            }
        }
    }
}
