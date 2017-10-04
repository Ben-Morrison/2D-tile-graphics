using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine2D
{
    public enum CameraState
    {
        Static,
        Following,
        Moving
    }

    public class Camera : IUpdate
    {
        private int x;
        private int y;

        IPosition following;

        CameraState state;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Camera(int x, int y)
        {
            this.x = x;
            this.x = y;

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

        public int X
        {
            get { return this.x; }
        }

        public int Y
        {
            get { return this.y; }
        }

        public void LookAt(IPosition pos)
        {
            this.x = pos.X;
            this.x = pos.Y;

            this.state = CameraState.Static;
        }

        public void LookAt(int x, int y)
        {
            this.x = x;
            this.x = y;

            this.state = CameraState.Static;
        }

        public void Follow(IPosition pos)
        {
            this.following = pos;

            this.x = following.X;
            this.x = following.Y;

            this.state = CameraState.Following;
        }

        public void Move(int x, int y)
        {
            this.x += x;
            this.y += y;

            this.state = CameraState.Moving;
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
