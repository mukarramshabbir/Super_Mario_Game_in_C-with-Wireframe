using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Core;
using WireFrame.Enums;

namespace WireFrame.Collision
{
    public class PlayerFireCollision:ICollisionAction
    {
        public void PerformAction(IGame Game, GameObject Source1, GameObject Source2)
        {
            GameObject Player;
            GameObject EnemyFire;
            if (Source1.OType1 == ObjectTypes.EnemyFires)
            {
                Player = Source2;
                EnemyFire = Source1;
            }
            else
            {
                Player = Source1;
                EnemyFire = Source2;
            }
            //Enemy.Health1.Value -= 10;
            Game.RaiseFireCollisionWithEnemyEvent(Player.Pb, EnemyFire.Pb, Player.Health1);
        }
    }
}
