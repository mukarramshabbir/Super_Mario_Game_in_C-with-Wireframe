using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WireFrame.Movement
{
    public class ZigZag:IMovement
    {
        private int Speed;
        private Point Boundary;
        private string Direction;
        private int Offset;

        public ZigZag(int Speed, Point Boundary, string Direction)
        {
            this.Speed = Speed;
            this.Boundary = Boundary;
            this.Direction = Direction;
            Offset = 100;
        }
        public Point Move(Point Location)
        {
            if (Direction == "Up")
            {
                Location.X -= Speed;
                Location.Y -= Speed;
            }
            if (Direction == "Down")
            {
                Location.X -= Speed;
                Location.Y += Speed;
            }
            if (Location.Y >= 391)
            {
                Direction = "Up";
            }
            if (Location.Y <= 0)
            {
                Direction = "Down";
            }
            if (Location.X <= 0)
            {
                Location.X = 1800;
            }
            return Location;
        }
    }
}
