using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WireFrame.Movement
{
    public class Horizontal :IMovement
    {

        private int Speed;
        private Point Boundary;
        private string Direction;
        private int Offset;
        int count = 0;
        public Horizontal()
        {

        }
        public Horizontal(int Speed, Point Boundary, string Direction)
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
                int SetStartingLocation = 1800;
                if (Location.X <= -50)
                {
                    Location.X = SetStartingLocation;
                }
                Location.X -= Speed;
            }
            if(Direction=="Right")
            {
                Location.X += Speed;
            }
            return Location;
        }


        //private void CreateRandomEnemy(PictureBox Enemy)
        //{
        //    Random rand=new Random();
        //    if (Enemy.Location.X <= 0)
        //    {
        //        int Left = rand.Next(300, 800);
        //        int Top = rand.Next(100, 200);
        //        Point p = new Point();
        //        p.X = Left;
        //        p.Y = Top;
        //        Enemy.Location = p;
        //    }
        //}
    }
}
