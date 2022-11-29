using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Core;
using WireFrame.Enums;
namespace WireFrame.Collision
{
    public class EnemyCollision:ICollisionAction
    {
        public void PerformAction(IGame Game, GameObject Source1, GameObject Source2)
        {
            GameObject Enemy;
            if(Source1.OType1==ObjectTypes.enemy)
            {
                Enemy = Source1;
            }
            else
            {
                Enemy = Source2;
            }
            Game.RaisePlayerDieEvent(Enemy.Pb,Enemy.Health1);
        }
    }
}
