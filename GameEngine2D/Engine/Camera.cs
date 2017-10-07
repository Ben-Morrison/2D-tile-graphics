using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameEngine2D
{
    public enum CameraState
    {
        Static,
        Following,
        Moving,
        Transitioning
    }

    public class Camera : IUpdate, IPosition
    {
        private Point position;
        IPosition following;

        CameraState state;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Camera(int x, int y)
        {
            this.position = new Point(x, y);
            this.state = CameraState.Static;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        public Camera(IPosition pos)
        {
            this.Follow(pos);
        }

        public Point Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public void LookAt(IPosition pos)
        {
            this.position = pos.Position;
            this.state = CameraState.Static;
        }

        public void LookAt(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
            this.state = CameraState.Static;
        }

        public void Follow(IPosition pos)
        {
            this.following = pos;
            this.position = this.following.Position;
            this.state = CameraState.Following;
        }

        public void Move(int x, int y)
        {
            this.position.X += x;
            this.position.Y += y;
            this.state = CameraState.Moving;
        }

        /// <summary>
        /// Moves the camera at a given speed towards a given position then stops
        /// </summary>
        /// <param name="x">The X position</param>
        /// <param name="y">The Y position</param>
        /// <param name="speed">How long it should take</param>
        /// <param name="after"></param>
        public void Transition(int x, int y, int speed, CameraState after)
        {
            
        }

        public void Update()
        {
            if(this.state == CameraState.Following)
            {
                if(this.following != null)
                {
                    this.LookAt(this.following);
                } else {
                    this.state = CameraState.Static;
                }
            }
        }
    }
}
