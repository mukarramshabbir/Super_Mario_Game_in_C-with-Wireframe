using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Core;
using WireFrame.Enums;

namespace WireFrame.Collision
{
    public class WallCollision:ICollisionAction
    {
        public void PerformAction(IGame Game, GameObject Source1, GameObject Source2)
        {
            GameObject PlayerCollidingwithWall;
            if(Source1.OType1==ObjectTypes.Pipes)
            {
                PlayerCollidingwithWall = Source1;
            }
            else
            {
                PlayerCollidingwithWall = Source2;
            }
            Game.RaisePipeCollisionEvent(PlayerCollidingwithWall.Pb);
        }
    }
}
