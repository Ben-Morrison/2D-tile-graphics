using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using System.Windows.Forms;

namespace GameEngine2D
{
    public class Game
    {
        private string name;
        private string path;

        private List<Room> rooms;
        private int currentRoom = 0;

        private int newRoom = 0;        // Which room you will start in on a new game
        private int newLocationX = 0;   // Which position you will start in on a new game
        private int newLocationY = 0;

        private Dictionary<string, object> Variables;

        public Game()
        {
            rooms = new List<Room>();
            Variables = new Dictionary<string, object>();
        }

        public void AddRoom(Room room)
        {
            this.rooms.Add(room);
        }

        public List<Room> GetRooms()
        {
            return this.rooms;
        }

        public void SetCurrentRoom(int room)
        {
            this.currentRoom = room;
        }

        public Room GetCurrentRoom()
        {
            if (rooms.Count == 0)
            {
                return null;
            }
            else
            {
                return this.rooms[currentRoom];
            }
        }

        public void SetNewRoom(int room)
        {
            this.newRoom = room;
        }

        public void SetNewLocationX(int x)
        {
            this.newLocationX = x;
        }

        public void SetNewLocationY(int y)
        {
            this.newLocationY = y;
        }

        public void SetGameVariable(string s, object o)
        {
            if (Variables.ContainsKey(s))
                MessageBox.Show("Key already exists in Dictionary");
            else
                Variables.Add(s, o);
        }

        public object GetGameVariable(string s)
        {
            return Variables[s];
        }

        public void Update()
        {
            if (rooms.Count == 0)
            {

            }
            else
            {
                rooms[currentRoom].Update();
            }
        }

        public void Draw(Sprite s)
        {
            if (rooms.Count == 0)
            {

            }
            else
            {
                rooms[currentRoom].Draw(s);
            }
        }
    }
}
