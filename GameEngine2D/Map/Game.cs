using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;
using System.IO;

namespace GameEngine2D
{
    [Serializable]
    public class Game : IDraw
    {
        private List<Room> rooms;
        private int currentRoom;

        public Game()
        {
            rooms = new List<Room>();
            currentRoom = -1;
        }

        public List<Room> Rooms
        {
            get { return this.rooms; }
            set { this.rooms = value; }
        }

        public void AddRoom(Room r)
        {
            if (currentRoom == -1)
            {
                currentRoom = 0;
            }

            this.rooms.Add(r);
        }

        public void SetCurrentRoom(int room)
        {
            this.currentRoom = room;
        }

        public Room GetCurrentRoom()
        {
            if (this.rooms.Count < 1)
            {
                return null;
            }
            else
            {
                return this.rooms[this.currentRoom];
            }
        }

        public void Update()
        {

        }

        public void Draw(Sprite s)
        {
            if (currentRoom > -1 && currentRoom < rooms.Count)
            {
                rooms[currentRoom].Draw(s);
            }
        }
    }
}
