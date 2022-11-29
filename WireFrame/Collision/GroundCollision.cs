using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Core;
using WireFrame.Enums;

namespace WireFrame.Collision
{
    public class GroundCollision:ICollisionAction
    {
        public void PerformAction(IGame Game, GameObject Source1, GameObject Source2)
        {
            GameObject Ground;
            if (Source1.OType1 == ObjectTypes.Ground)
            {
                Ground = Source1;
            }
            else
            {
                Ground = Source2;
            }
            Game.RaiseGroundDieEvent(Ground.Pb);
        }
    }
}
