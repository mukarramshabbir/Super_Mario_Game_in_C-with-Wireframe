using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Core;
using WireFrame.Enums;
namespace WireFrame.Collision
{
    public class PlayerCollision:ICollisionAction
    {
        public void PerformAction(IGame Game,GameObject Source1,GameObject Source2)
        {
            GameObject Player;
            if(Source1.OType1==ObjectTypes.player)
            {
                Player = Source1;
            }
            else
            {
                Player = Source2;
            }
            Game.RaisePlayerDieEvent(Player.Pb,Player.Health1);
        }
    }
}
