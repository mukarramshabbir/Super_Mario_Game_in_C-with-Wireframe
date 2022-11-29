using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Core;
using WireFrame.Enums;

namespace WireFrame.Collision
{
    public class FireCollision:ICollisionAction
    {
        public void PerformAction(IGame Game, GameObject Source1, GameObject Source2)
        {
            GameObject Enemy;
            GameObject PlayerFire;
            if (Source1.OType1 == ObjectTypes.playerFires)
            {
                Enemy = Source2;
                PlayerFire = Source1;
            }
            else
            {
                Enemy = Source1;
                PlayerFire = Source2;
            }
            //Enemy.Health1.Value -= 10;
            Game.RaiseFireCollisionWithEnemyEvent(Enemy.Pb,PlayerFire.Pb,Enemy.Health1);
        }
    }
}
