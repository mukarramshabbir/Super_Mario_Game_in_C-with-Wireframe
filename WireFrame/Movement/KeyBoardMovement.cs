using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using WireFrame.Firing;

namespace WireFrame.Movement
{
    public class KeyBoardMovement :IMovement
    {
        private int Speed;
        private Point Boundary;
        private string Direction;
        private string ArrowAction;
        private bool FireAction;
        public KeyBoardMovement(int Speed, Point Boundary, string Direction)
        {
            this.Speed = Speed;
            this.Boundary = Boundary;
            this.Direction = Direction;
            FireAction = false;
        }
        public void KeyPresssedBuUser(Keys KeyCode)
        {
            if (KeyCode == Keys.Up)
            {
                ArrowAction = "Up";
            }
            else if (KeyCode == Keys.Down)
            {
                ArrowAction = "Down";
            }
            //else if(KeyCode==Keys.Space)
            //{
            //    FireAction = true;   
            //}
        }
        public Point Move(Point Location)
        {
            if (ArrowAction == "Up")
            {
                Location.Y -= Speed;
            }
            if (ArrowAction == "Down")
            {
                Location.Y += Speed;
            }
            if(FireAction==true)
            {
                //FireClass f=new FireClass()
            }
            return Location;
        }
    }
}
