using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Core;
using WireFrame.Enums;

namespace WireFrame.Collision
{
    public class PowerUpsCollision:ICollisionAction
    {
        public void PerformAction(IGame Game, GameObject Source1, GameObject Source2)
        {
            GameObject PowerUps;
            GameObject Player;
            if (Source1.OType1 == ObjectTypes.PowerUps)
            {
                PowerUps = Source1;
                Player = Source2;
            }
            else
            {
                PowerUps = Source2;
                Player = Source1;
            }
            Game.RaisePowerUpsEvent(PowerUps.Pb,Player.Pb,Player.Health1);
        }
    }
}
