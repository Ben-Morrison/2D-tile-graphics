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
    public class GameObject
    {
        // Should other solid objects collide with this one
        private bool solid;
        private Vector2 pos;
        private Room currentRoom;

        public GameObject(Room currentRoom)
        {
            this.solid = false;
            this.pos = new Vector2(0, 0);
            this.currentRoom = currentRoom;
        }

        public GameObject(Vector2 pos, Room currentRoom)
        {
            this.solid = false;
            this.pos = pos;
            this.currentRoom = currentRoom;
        }

        public GameObject(bool solid, Vector2 pos, Room currentRoom)
        {
            this.solid = solid;
            this.pos = pos;
            this.currentRoom = currentRoom;
        }

        public void SetPos(Vector2 pos)
        {
            this.pos = pos;
        }

        public Vector2 GetPos()
        {
            return this.pos;
        }

        public virtual void Update(List<GameObject> objects)
        {
            
        }

        public virtual void Draw(Sprite s)
        {

        }
    }
}
