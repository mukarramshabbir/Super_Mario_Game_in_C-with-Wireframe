using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WireFrame.Core
{
    public interface IGame
    {
        void RaisePlayerDieEvent(PictureBox pb,ProgressBar Health);
        void RaiseFiringEvent(PictureBox FireImg);
        void RaiseCoinDieEvent(PictureBox CoinImg);
        void RaiseHeartDieEvent(PictureBox HeartImg);
        void RaiseGroundDieEvent(PictureBox pbGround);
        void RaisePipeCollisionEvent(PictureBox pbPlayer);
        void RaiseBoundaryCollidingEvent(bool flag);
        void RaiseFireCollisionWithEnemyEvent(PictureBox pbEnemy,PictureBox PlayerFire, ProgressBar pbBar);
        void RaisePowerUpsEvent(PictureBox pbPowerUps, PictureBox pbPlayer, ProgressBar BarPlayer);
    }
}
