using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Enums;
using WireFrame.Core;

namespace WireFrame.Collision
{
    public class CoinCollision:ICollisionAction
    {
        public void PerformAction(IGame Game, GameObject Source1, GameObject Source2)
        {
            GameObject Coin;
            if (Source1.OType1 == ObjectTypes.Coins)
            {
                Coin = Source1;
            }
            else
            {
                Coin = Source2;
            }
            Game.RaiseCoinDieEvent(Coin.Pb);
        }
    }
}
