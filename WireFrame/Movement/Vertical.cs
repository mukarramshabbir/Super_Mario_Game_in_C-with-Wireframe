using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WireFrame.Movement
{
    public class Vertical:IMovement
    {
        private int Speed;
        private Point Boundary;
        private string Direction;
        private int Offset;
        int count = 0;
        public Vertical()
        {

        }
        public Vertical(int Speed, Point Boundary, string Direction)
        {
            this.Speed = Speed;
            this.Boundary = Boundary;
            this.Direction = Direction;
            Offset = 100;
        }
        public Point Move(Point Location/*,Image img*/)
        {
            if (Direction == "Up")
            {
                Location.Y -= Speed;
                Location.X -= 2;
            }
            if (Direction == "Down")
            {
                Location.Y += Speed;
                Location.X -= 2;
            }
            return Location;
        }
    }
}
