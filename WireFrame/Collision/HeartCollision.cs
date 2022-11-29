using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Core;
using WireFrame.Enums;

namespace WireFrame.Collision
{
    public class HeartCollision:ICollisionAction
    {
        public void PerformAction(IGame Game, GameObject Source1, GameObject Source2)
        {
            GameObject Heart;
            if (Source1.OType1 == ObjectTypes.Heart)
            {
                Heart = Source1;
            }
            else
            {
                Heart = Source2;
            }
            Game.RaiseHeartDieEvent(Heart.Pb);
        }
    }
}
