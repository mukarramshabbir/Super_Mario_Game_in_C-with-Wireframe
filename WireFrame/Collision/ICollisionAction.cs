using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireFrame.Core;

namespace WireFrame.Collision
{
    public interface ICollisionAction
    {
        void PerformAction(IGame game, GameObject Source1, GameObject Source2);
    }
}
