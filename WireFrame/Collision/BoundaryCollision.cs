using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WireFrame.Core;
using WireFrame.Enums;

namespace WireFrame.Collision
{
    public class BoundaryCollision:ICollisionAction
    {
        private Point Boundary;
        public BoundaryCollision(Point Boundary)
        {
            Boundary=new Point();
            this.Boundary = Boundary;
        }
        public void PerformAction(IGame Game, GameObject Source1, GameObject Source2)
        {
            GameObject PlayerCollidingwithBoundary;
            bool flag = false;
            if (Source1.OType1 == ObjectTypes.player)
            {
                PlayerCollidingwithBoundary = Source1;
            }
            else
            {
                PlayerCollidingwithBoundary = Source2;
            }
            if(PlayerCollidingwithBoundary.Pb.Location.Y<=0)
            {
                flag = true;
            }
            Game.RaiseBoundaryCollidingEvent(flag);
        }
    }
}
