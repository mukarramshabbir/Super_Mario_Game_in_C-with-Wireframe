using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WireFrame.Movement
{
    public class Diagonal:IMovement
    {
        private int Speed;
        private Point Boundary;
        private string Direction;
        private int Offset;
        int count = 0;
        public Diagonal()
        {

        }
        public Diagonal(int Speed, Point Boundary, string Direction)
        {
            this.Speed = Speed;
            this.Boundary = Boundary;
            this.Direction = Direction;
            Offset = 100;
        }
        public Point Move(Point Location/*,Image img*/)
        {
            if (Direction == "Left")
            {
                //int SetStartingLocation = 1800;
                //if (Location.X <= -50)
                //{
                //    Location.X = SetStartingLocation;
                //}
                Location.X -= Speed;
                Location.Y += Speed;
            }
            if (Direction == "Right")
            {
                Location.X += Speed;
                Location.Y += Speed;
                //if(Location.X>=1800)
                //{
                //    Location.X = -50;
                //}
            }
            return Location;
        }
    }
}
