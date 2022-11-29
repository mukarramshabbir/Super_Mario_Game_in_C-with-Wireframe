using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WireFrame.Movement;
using WireFrame.Enums;
using WireFrame.Collision;
using WireFrame.Firing;
namespace WireFrame.Core
{
    public class Game:IGame
    {
        private List<GameObject> GameObjectsList;
        //private List<ProgressBar> ProgressBarList;
        private List<CollisionClass> CollisionList;
        private List<FireClass> FiringList;
        private int Gravity;
        public event EventHandler onAddingGameObject;
        public event EventHandler OnAddingProgressBar;
        public event EventHandler OnPlayerDie;
        public event EventHandler OnRemoveProgressBar;
        public event EventHandler OnAddingFires;
        public event EventHandler OnCoinDie;
        public event EventHandler OnHeartDie;
        public event EventHandler OnGroundTouch;
        public event EventHandler OnPipeCollision;
        public event EventHandler OnBoundaryCollision;
        public event EventHandler OnPlayerFire;
        public event EventHandler OnEnemyFire;
        public event EventHandler DiagonalEnemyFire;
        public event EventHandler RightDiagonalEnemyFire;
        public event EventHandler OnFireDead;
        public event EventHandler OnFireCollisionWithEnemy;
        public event EventHandler IncreasePlayerPowerByPowerUps;
        public Game(int Gravity)
        {
            GameObjectsList = new List<GameObject>();
            //ProgressBarList = new List<ProgressBar>();
            CollisionList = new List<CollisionClass>();
            FiringList = new List<FireClass>();
            this.Gravity = Gravity;
        }
        public PictureBox AddGameObject(Image img,ObjectTypes OType, int Top, int Left, IMovement Movement)
        {
            GameObject go = new GameObject(img,OType, Top, Left, Movement);
            GameObjectsList.Add(go);
            onAddingGameObject?.Invoke(go.Pb, EventArgs.Empty);
            if(OType==ObjectTypes.enemy || OType==ObjectTypes.player)
            {
                OnAddingProgressBar?.Invoke(go.Health1, EventArgs.Empty);
            }            
            return go.Pb;
        }
        public void AddGameObject(GameObject g)
        {
            GameObjectsList.Add(g);
        }
        public void MoveProgressBar()
        {
            int Left, Top;
            Point p = new Point();
            foreach(GameObject g in GameObjectsList)
            {
                if (g.OType1 == ObjectTypes.player || g.OType1 == ObjectTypes.enemy)
                {
                    Left = g.Pb.Location.X;
                    Top = g.Pb.Location.Y;
                    p.X = Left;
                    p.Y = Top + g.Pb.Height + 5;
                    g.Health1.Location = p;
                }
            }
        }
        int Count = 0, count1 = 0;
        public void Update()
        {
            DetectCollision();
            MoveProgressBar();
            foreach (GameObject g in GameObjectsList)
            {
                g.GameObjectMove();                
            }
            //foreach(FireClass f in FiringList)
            //{
            //    f.movefire();
            //}
            EnemyFire();
            RemoveFire();
        }
        public void KeyPressed(Keys KeyCode)
        {
            foreach (GameObject g in GameObjectsList)
            {
                if (g.Movement1.GetType() == typeof(KeyBoardMovement))
                {
                    KeyBoardMovement keyBoardHandle = (KeyBoardMovement)g.Movement1;
                    keyBoardHandle.KeyPresssedBuUser(KeyCode);
                }
            }            
        }
        public void KeyPressedForFiring(Keys KeyCode )
        {
            if (KeyCode == Keys.Space)
            {               
                foreach(GameObject g in GameObjectsList)
                {
                    if(g.OType1==ObjectTypes.player)
                    {
                        OnPlayerFire?.Invoke(g.Pb, EventArgs.Empty);
                        
                        break;
                    }
                }
            }
        }
        public void AddFiresInFiringList(FireClass f)
        {
            FiringList.Add(f);
        }
        public void EnemyFire()
        {
            Count++;
            if(Count==60)
            {
                for(int i=0;i<GameObjectsList.Count;i++)
                {
                    if(GameObjectsList[i].OType1 == ObjectTypes.enemy)
                    {
                        DiagonalEnemyFire?.Invoke(GameObjectsList[i].Pb, EventArgs.Empty);
                        break;
                    }
                }
            }
            if (Count == 70)
            {                
                for(int i=0;i<GameObjectsList.Count;i++)
                {
                    if(GameObjectsList[i].OType1==ObjectTypes.enemy)
                    {
                        count1++;
                        if (count1 >1 && count1<5)
                        {
                            OnEnemyFire?.Invoke(GameObjectsList[i].Pb, EventArgs.Empty);
                        }
                        if(count1>=5)
                        {
                            RightDiagonalEnemyFire?.Invoke(GameObjectsList[i].Pb, EventArgs.Empty);
                            
                        }
                        
                    }
                }
                Count = 0;
                count1 = 0;
            }
        }
        public void RemoveFire()
        {
            foreach(GameObject g in GameObjectsList)
            {
                if(g.OType1==ObjectTypes.EnemyFires || g.OType1==ObjectTypes.playerFires)
                {
                    if(g.Pb.Location.X<0)
                    {
                        GameObjectsList.Remove(g);
                    }
                    else if(g.Pb.Location.X>1000)
                    {
                        GameObjectsList.Remove(g);
                    }
                    else if(g.Pb.Location.Y>600)
                    {
                        GameObjectsList.Remove(g);
                    }
                    OnFireDead?.Invoke(g.Pb, EventArgs.Empty);
                    break;
                }
            }
        }
        public void AddCollision(CollisionClass c)
        {
            CollisionList.Add(c);
        }
        public void RaisePlayerDieEvent(PictureBox PlayerGameObject,ProgressBar Health)
        {
            OnPlayerDie?.Invoke(PlayerGameObject, EventArgs.Empty);
            OnRemoveProgressBar?.Invoke(Health, EventArgs.Empty);
        }
        public void DetectCollision()
        {
            int valu = 10;
            for(int i=0;i<GameObjectsList.Count;i++)
            {
                for(int j=0;j<GameObjectsList.Count;j++)
                {
                    if(GameObjectsList[i].Pb.Bounds.IntersectsWith(GameObjectsList[j].Pb.Bounds))
                    {
                        //foreach(CollisionClass c in CollisionList)
                        //{
                        //    if(GameObjectsList[i].OType1==c.G1 && GameObjectsList[j].OType1==c.G2)
                        //    {
                        //        c.Behaviour1.PerformAction(this, GameObjectsList[i], GameObjectsList[j]);
                        //        break;
                        //        //GameObjectsList[i].Health1.Value = GameObjectsList[i].Health1.Value- valu;
                        //    }
                        //}
                        for(int k=0;k<CollisionList.Count;k++)
                        {
                            if(GameObjectsList[i].OType1==CollisionList[k].G1 && GameObjectsList[j].OType1==CollisionList[k].G2)
                            {
                                CollisionList[k].Behaviour1.PerformAction(this, GameObjectsList[i], GameObjectsList[j]);
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void AddFires(FireClass f)
        {
            FiringList.Add(f);
            //RaiseFiringEvent(f.Pbfire);
        }
        public void RaiseFiringEvent(PictureBox FireImg)
        {
            OnAddingFires?.Invoke(FireImg, EventArgs.Empty);
        }
        public void RaiseFireCollisionWithEnemyEvent(PictureBox pbEnemy,PictureBox pbPlayerFire,ProgressBar pbBarEnemy)
        {
            if(pbBarEnemy.Value<=0)
            {
                OnRemoveProgressBar?.Invoke(pbBarEnemy, EventArgs.Empty);
                OnFireDead?.Invoke(pbEnemy, EventArgs.Empty);
                Remove(pbEnemy);
            }
            if (pbBarEnemy.Value > 0)
            {
                OnFireCollisionWithEnemy?.Invoke(pbBarEnemy, EventArgs.Empty);
                OnFireDead?.Invoke(pbPlayerFire, EventArgs.Empty);                
                Remove(pbPlayerFire);
            }
        }
        public void Remove(PictureBox pb)
        {           
            for(int i=0;i<GameObjectsList.Count;i++)
            {
                if(GameObjectsList[i].Pb==pb)
                {
                    GameObjectsList.Remove(GameObjectsList[i]);
                }
            }
        }
        public void AddCoinInGameObjectList(GameObject g)
        {
            GameObjectsList.Add(g);
        }
        public void RaiseCoinDieEvent(PictureBox CoinImg)
        {
            OnCoinDie?.Invoke(CoinImg, EventArgs.Empty);
            Remove(CoinImg);
        }
        public void RaiseHeartDieEvent(PictureBox HeartImg)
        {
            Remove(HeartImg);
            OnHeartDie?.Invoke(HeartImg, EventArgs.Empty);            
        }
        public void RaiseGroundDieEvent(PictureBox pbGround)
        {
            OnGroundTouch?.Invoke(pbGround, EventArgs.Empty);
        }
        public void RaisePipeCollisionEvent(PictureBox pbPlayer)
        {
            OnPipeCollision?.Invoke(pbPlayer, EventArgs.Empty);
        }
        public void RaiseBoundaryCollidingEvent(bool flag)
        {
            OnBoundaryCollision?.Invoke(flag, EventArgs.Empty);
        }
        public void RaisePowerUpsEvent(PictureBox pbPowerUps,PictureBox pbPlayer,ProgressBar BarPlayer)
        {
            if (BarPlayer.Value < 80)
            {
                IncreasePlayerPowerByPowerUps?.Invoke(BarPlayer, EventArgs.Empty);
                OnFireDead?.Invoke(pbPowerUps, EventArgs.Empty);
            }
        }
    }
}
