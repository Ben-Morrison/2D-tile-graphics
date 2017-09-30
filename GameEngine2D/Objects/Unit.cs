using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace GameEngine2D
{
    // Class that represents an alive object in the game for example: An alien
    public class Unit : MovableObject
    {
        private int health;
        // Make weapon classes then put an array of weapons the unit currently has
        private float walkSpeed;
        private float runSpeed;

        public Unit(Vector2 pos, Room room)
            : base(pos, room)
        {
            this.walkSpeed = GameVariables.DEFAULT_WALKSPEED;
            this.runSpeed = GameVariables.DEFAULT_RUNSPEED;
        }

        public float GetWalkSpeed() { return this.walkSpeed; }
        public void SetWalkSpeed(float speed) { this.walkSpeed = speed; }

        public float GetRunSpeed() { return this.runSpeed; }
        public void SetRunSpeed(float speed) { this.runSpeed = speed; }

    }
}
