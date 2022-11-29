using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using WireFrame.Core;
using WireFrame.Movement;
using WireFrame.Enums;
using WireFrame.Collision;
using WireFrame.Firing;

namespace Game1
{
    public partial class Level2 : Form
    {
        Game g;
        Random rand;
        int EnemyLeft, EnemyTop, EnemySpeed, count, Score, PipeSpeed, CoinSpeed, Left, top, FireSpeed,MetaphorFire, count1 = 0,count2=0;
        Image EnemyHorizontalImg, EnemyZigZagImg;
        PictureBox pbPlayer;
        PictureBox EnemyLeftRight, EnemyZigZagBlue, EnemyZigZagYellow,Enemy4,Enemy5;
        PictureBox PipeBottom1, PipeBottom2, PipeTop1, PipeTop2;
        int TotalLives = 3;
        List<GameObject> CoinsList = new List<GameObject>();
        Point EnemyZigZagBluePoint = new Point();
        Point EnemyZigZagYellowPoint = new Point();
        Point EnemyLeftRightPoint = new Point();
        Point Enemy4Point = new Point();
        Point Enemy5Point = new Point();
        Point Pipe1 = new Point();
        Point Pipe2 = new Point();
        Point Pipe3 = new Point();
        Point Pipe4 = new Point();
        Point Boundary;

        PictureBox EnemyUpandDown;
        ProgressBar pbPlayerHealth;
        ProgressBar EnemyUpandDownHealth;


        int time;
        PictureBox EnemyFire;
        int EnemyUpandDownTimetoFire, EnemyUpandDownLastTimetoFire;
        PictureBox EnemyUpandDown2;
        ProgressBar EnemyUpandDown2Health;
        int EnemyUpandDown2TimeToFire, EnemyUpandDown2LastTimetoFire;

        ProgressBar EnemyLeftRightHealth;
        int EnemyLeftRightTimetoFire, EnemyLeftRightLastTimetoFire;
        string EnemyUpandDownDirection = "MoveDown";
        string EnemyUpandDownDirection2 = "MoveUp";
        string EnemyLeftRightDirection = "Left";
        List<PictureBox> PipeList = new List<PictureBox>();
        List<PictureBox> PlayerFiresList = new List<PictureBox>();
        List<PictureBox> EnemyFiresList = new List<PictureBox>();
        List<PictureBox> Enemy2FiresList = new List<PictureBox>();
        List<PictureBox> Enemy3FireListLeftRight = new List<PictureBox>();
        List<PictureBox> Pipe1FiresList = new List<PictureBox>();
        List<PictureBox> Pipe2TopFireList = new List<PictureBox>();
        List<PictureBox> TotalEnemyList = new List<PictureBox>();
        int Gravity ;
        Random random;


        int Pipe1TimeToFire, Pipe1LastTimeToFire; PictureBox Pipe1Enemy;
        int Pipe2TopTimetoFire, Pipe2TopLastTimetoFire;

        

        PictureBox Pipe2TopEnemy;

        public Level2()
        {
            InitializeComponent();
        }

        private void Level2_Load(object sender, EventArgs e)
        {
            RestartAgain();
        }
        private void RestartAgain()
        {
            rand = new Random();
            EnemySpeed = 7; count = 0; PipeSpeed = 7; CoinSpeed = 7; FireSpeed = 8; MetaphorFire = 0;
            g = new Game(4);
            g.onAddingGameObject += new EventHandler(AddIntoControls);
            g.OnAddingProgressBar += new EventHandler(AddProgressBar);
            g.OnPlayerDie += new EventHandler(RemovePlayer);
            g.OnRemoveProgressBar += new EventHandler(RemoveProgressBar);
            g.OnAddingFires += new EventHandler(AddFiresInControl);
            g.OnCoinDie += new EventHandler(RemoveCoinFromControls);
            g.OnHeartDie += new EventHandler(RemoveHeartFromControl);
            g.OnGroundTouch += new EventHandler(OnGoundTouchEvent);
            g.OnPipeCollision += new EventHandler(PipeCollisionEvent);
            g.OnBoundaryCollision += new EventHandler(BoundaryCollisionEvent);
            g.OnPlayerFire += new EventHandler(OnPlayerFire);
            g.OnEnemyFire += new EventHandler(OnEnemyFire);
            g.DiagonalEnemyFire += new EventHandler(DiagonalEnemyFire);
            g.RightDiagonalEnemyFire += new EventHandler(RightDiagonalEnemyFire);
            g.OnFireDead += new EventHandler(RemoveFire);
            g.OnFireCollisionWithEnemy += new EventHandler(ReducePowerOfProgressBar);
            g.IncreasePlayerPowerByPowerUps += new EventHandler(IncreasePowerPlayerEvent);
            //Fire(Playerimg, ObjectTypes.player, new HorizontalFire(FireSpeed, Direction));
            Boundary = new Point(this.Width, this.Height);
            Image PlayerImg = Game1.Properties.Resources.FlappyDown;
            pbPlayer = g.AddGameObject(PlayerImg, ObjectTypes.player, 20, 20, new KeyBoardMovement(7, Boundary, "Down"));
            EnemyHorizontalImg = Game1.Properties.Resources.flyMan_still_stand;
            EnemyLeft = rand.Next(800, 900);
            EnemyTop = rand.Next(20, EnemyHorizontalImg.Height + 20);
            EnemyLeftRightPoint.X = EnemyLeft;
            EnemyLeftRightPoint.Y = EnemyTop;
            EnemyLeftRight = g.AddGameObject(EnemyHorizontalImg, ObjectTypes.enemy, EnemyTop, EnemyLeft, new Horizontal(EnemySpeed, Boundary, "Left"));
            EnemyZigZagImg = Game1.Properties.Resources.narwhal__1___1_;
            EnemyLeft = rand.Next(900,1050);
            EnemyTop = rand.Next(20, 150);
            EnemyZigZagBluePoint.X = EnemyLeft; EnemyZigZagBluePoint.Y = EnemyTop;
            EnemyZigZagBlue = g.AddGameObject(EnemyZigZagImg, ObjectTypes.enemy, EnemyTop, EnemyLeft, new ZigZag(EnemySpeed, Boundary, "Up"));
            EnemyZigZagImg = Game1.Properties.Resources.wing;
            EnemyLeft = rand.Next(1050,1200);
            EnemyTop = rand.Next(150, 300);
            EnemyZigZagYellowPoint.X = EnemyLeft; EnemyZigZagYellowPoint.Y = EnemyTop;
            EnemyZigZagYellow = g.AddGameObject(EnemyZigZagImg, ObjectTypes.enemy, EnemyTop, EnemyLeft, new ZigZag(EnemySpeed, Boundary, "Up"));
            EnemyZigZagImg = Game1.Properties.Resources.FluffyBird;
            EnemyLeft = rand.Next(1200,1350);
            EnemyTop = rand.Next(450,550);
            Enemy4Point.X = EnemyLeft; Enemy4Point.Y = EnemyTop;
            Enemy4 =g.AddGameObject(EnemyZigZagImg,ObjectTypes.enemy,EnemyTop,EnemyLeft,new ZigZag(EnemySpeed,Boundary,"Down"));
            EnemyZigZagImg = Game1.Properties.Resources.Green__1_;
            EnemyLeft = rand.Next(1360,1500);
            EnemyTop = rand.Next(250,350);
            Enemy5Point.X = EnemyLeft; Enemy5Point.Y = EnemyTop;
             Enemy5 = g.AddGameObject(EnemyZigZagImg, ObjectTypes.enemy, EnemyTop, EnemyLeft, new Horizontal(EnemySpeed, Boundary, "Left"));

            GameObject Ground = new GameObject(pbGround, ObjectTypes.Ground, new Horizontal(0, Boundary, "Left"));
            g.AddCoinInGameObjectList(Ground);


            //---------------Collision With Pipes-------------------
            Image pipeImgBottom1 = Game1.Properties.Resources.PipeResized2;
            PipeBottom1 = g.AddGameObject(pipeImgBottom1, ObjectTypes.Pipes, 278, 391, new Horizontal(PipeSpeed, Boundary, "Left"));
            Image pipeImgBottom2 = Game1.Properties.Resources.PipeResized3;
            PipeBottom2 = g.AddGameObject(pipeImgBottom2, ObjectTypes.Pipes, 226, 645, new Horizontal(PipeSpeed, Boundary, "Left"));
            Image pipeImgTop1 = Game1.Properties.Resources.PipeTop1;
            PipeTop1 = g.AddGameObject(pipeImgTop1, ObjectTypes.Pipes, 0, 419, new Horizontal(PipeSpeed, Boundary, "Left"));
            Image PipeImgTop2 = Game1.Properties.Resources.PipeTop2;
            PipeTop2 = g.AddGameObject(PipeImgTop2, ObjectTypes.Pipes, 0, 694, new Horizontal(PipeSpeed, Boundary, "Left"));
            //---------------End Collision With Pipes-------------------
            //---------------Collision With Player and Enemies-------------------
            CollisionClass PlayerCollision = new CollisionClass(ObjectTypes.player, ObjectTypes.enemy, new PlayerCollision());
            //CollisionClass EnemyCollision = new CollisionClass(ObjectTypes.player, ObjectTypes.enemy, new EnemyCollision());
            CollisionClass WallsCollision = new CollisionClass(ObjectTypes.player, ObjectTypes.Pipes, new WallCollision());
            foreach (Control c in this.Controls)
            {
                if ((string)c.Tag == "Coin")
                {
                    GameObject coin = new GameObject((PictureBox)c, ObjectTypes.Coins, new Horizontal(CoinSpeed, Boundary, "Left"));
                    g.AddCoinInGameObjectList(coin);
                }
            }
            CollisionClass CoinsCollision = new CollisionClass(ObjectTypes.player, ObjectTypes.Coins, new CoinCollision());
            foreach (Control c in this.Controls)
            {
                if ((string)c.Tag == "Heart")
                {
                    GameObject Heart = new GameObject((PictureBox)c, ObjectTypes.Heart, new Horizontal(CoinSpeed, Boundary, "Left"));
                    g.AddCoinInGameObjectList(Heart);
                }
            }
            CollisionClass PowerUpsCollision = new CollisionClass(ObjectTypes.player, ObjectTypes.PowerUps, new PowerUpsCollision());
            foreach (Control c in this.Controls)
            {
                if ((string)c.Tag == "PowerUps")
                {
                    GameObject PowerUps = new GameObject((PictureBox)c, ObjectTypes.PowerUps, new Horizontal(CoinSpeed, Boundary, "Left"));
                    g.AddCoinInGameObjectList(PowerUps);
                }
            }
            CollisionClass HeartCollision = new CollisionClass(ObjectTypes.player, ObjectTypes.Heart, new HeartCollision());

            CollisionClass GroundCollision = new CollisionClass(ObjectTypes.player, ObjectTypes.Ground, new GroundCollision());
            CollisionClass BoundayCollision = new CollisionClass(ObjectTypes.player, ObjectTypes.Boundary, new BoundaryCollision(Boundary));
            CollisionClass FireCollisionWithEnemy = new CollisionClass(ObjectTypes.enemy, ObjectTypes.playerFires, new FireCollision());
            CollisionClass PlayerCollisionWithEnemyFire = new CollisionClass(ObjectTypes.player, ObjectTypes.EnemyFires, new PlayerFireCollision());
            g.AddCollision(PlayerCollision);
            //g.AddCollision(EnemyCollision);
            g.AddCollision(WallsCollision);
            g.AddCollision(CoinsCollision);
            g.AddCollision(HeartCollision);
            g.AddCollision(GroundCollision);
            g.AddCollision(BoundayCollision);
            g.AddCollision(FireCollisionWithEnemy);
            g.AddCollision(PlayerCollisionWithEnemyFire);
            g.AddCollision(PowerUpsCollision);
            //---------------End Collision With Player and Enemies-------------------



            //Image FireImg = Game1.Properties.Resources.laserRed07__1_;            
            //FireClass PlayerFiring = new FireClass(pbPlayer, FireImg, ObjectTypes.player, new HorizontalFire(5, "Right", Boundary));            
            //FireClass EnemyFiring = new FireClass(EnemyLeftRight, FireImg, ObjectTypes.enemy, new HorizontalFire(15, "Left", Boundary));
            //g.AddFires(PlayerFiring);
            //g.AddFires(EnemyFiring);






            GameTimer.Enabled = true;

            EnemyUpandDownHealth = new ProgressBar();
            EnemyUpandDown2Health = new ProgressBar();
            EnemyLeftRightHealth = new ProgressBar();
            EnemyUpandDownTimetoFire = 45; EnemyUpandDownLastTimetoFire = 0;
            EnemyUpandDown2TimeToFire = 55; EnemyUpandDown2LastTimetoFire = 0;
            EnemyLeftRightTimetoFire = 60; EnemyLeftRightLastTimetoFire = 0;
            //EnemyLeftRightPoint.X = Left; EnemyLeftRightPoint.Y = Top;
            Pipe1.X = 391; Pipe1.Y = 278;
            Pipe2.X = 419; Pipe2.Y = 0;
            Pipe3.X = 622; Pipe3.Y = 226;
            Pipe4.X = 674; Pipe4.Y = 0;
            Pipe1LastTimeToFire = 0; Pipe1TimeToFire = 45;
            Pipe2TopLastTimetoFire = 0; Pipe2TopTimetoFire = 45;
            //Gravity = 7;
            Score = 0;
            TotalLives = 3;
            //EnemySpeed = 4;
            time = 60;
        }

        private void RightDiagonalEnemyFire(object sender, EventArgs e)
        {
            PictureBox Enemy = (PictureBox)sender;
            Image FireImg = Game1.Properties.Resources.tank_explosion3;
            Point Boundary = new Point(this.Width, this.Height);
            int Top = Enemy.Location.Y;
            int Left = Enemy.Location.X;
            g.AddGameObject(FireImg, ObjectTypes.EnemyFires, Top, Left, new FireClass(FireSpeed, Boundary, "RightDiagonal"));
        }

        private void IncreasePowerPlayerEvent(object sender, EventArgs e)
        {
            ProgressBar bar = (ProgressBar)sender;
            if (bar.Value < 80)
            {
                bar.Value += 20;
            }
        }

        private void DiagonalEnemyFire(object sender, EventArgs e)
        {
            PictureBox Enemy = (PictureBox)sender;
            Image FireImg = Game1.Properties.Resources.tank_explosion3;
            Point Boundary = new Point(this.Width, this.Height);
            int Top = Enemy.Location.Y;
            int Left = Enemy.Location.X;
            g.AddGameObject(FireImg, ObjectTypes.EnemyFires, Top, Left, new FireClass(FireSpeed, Boundary, "LeftDiagonal"));
        }

        private void ReducePowerOfProgressBar(object sender, EventArgs e)
        {
            ProgressBar p = (ProgressBar)sender;
            p.Value -= 10;
        }

        private void RemoveFire(object sender, EventArgs e)
        {
            this.Controls.Remove((PictureBox)sender);
        }

        private void OnEnemyFire(object sender, EventArgs e)
        {
            PictureBox Enemy = (PictureBox)sender;
            Image FireImg = Game1.Properties.Resources.laserBlue03__1_;
            Point Boundary = new Point(this.Width, this.Height);
            int Top = Enemy.Location.Y;
            int Left = Enemy.Location.X;
            g.AddGameObject(FireImg, ObjectTypes.EnemyFires, Top, Left, new FireClass(FireSpeed, Boundary, "Left"));
        }

        

        private void OnPlayerFire(object sender, EventArgs e)
        {
            PictureBox pbPlayer = (PictureBox)sender;
            Image FireImg = Game1.Properties.Resources.laserRed07__1_;
            Point Boundary = new Point(this.Width, this.Height);
            int Top = pbPlayer.Location.Y;
            int Left = pbPlayer.Location.X;
            g.AddGameObject(FireImg, ObjectTypes.playerFires, Top, Left, new FireClass(FireSpeed, Boundary, "Right"));
            //FireClass f = new FireClass(FireImg, ObjectTypes.playerFires, Top, Left, new Horizontal(FireSpeed, Boundary, "Right"));
            //g.AddFiresInFiringList(f);
        }

        private void BoundaryCollisionEvent(object sender, EventArgs e)
        {
            bool flag = (bool)sender;
            if (flag == true)
            {
                TotalLives--;
                Thread.Sleep(1000);
                RestartGame();
            }
        }

        private void PipeCollisionEvent(object sender, EventArgs e)
        {
            if (TotalLives > 0)
            {
                TotalLives--;
                Thread.Sleep(1000);
                RestartGame();
            }
        }

        private void OnGoundTouchEvent(object sender, EventArgs e)
        {
            if (TotalLives > 0)
            {
                TotalLives--;
                Thread.Sleep(1000);
                RestartGame();
            }
        }

        private void RemoveHeartFromControl(object sender, EventArgs e)
        {
            TotalLives++;
            this.Controls.Remove((PictureBox)sender);
        }

        private void RemoveCoinFromControls(object sender, EventArgs e)
        {
            Score++;
            this.Controls.Remove((PictureBox)sender);
        }

        private void AddFiresInControl(object sender, EventArgs e)
        {
            this.Controls.Add((PictureBox)sender);
        }

        private void RemoveProgressBar(object sender, EventArgs e)
        {
            ProgressBar p = (ProgressBar)sender;
            if (p.Value <= 0)
            {
                this.Controls.Remove((ProgressBar)sender);
            }
        }

        private void AddProgressBar(object sender, EventArgs e)
        {
            this.Controls.Add((ProgressBar)sender);
        }

        private void RemovePlayer(object sender, EventArgs e)
        {
            if (TotalLives >= 0)
            {
                TotalLives--;
                Thread.Sleep(1000);
                RestartGame();
                //this.Controls.Remove((PictureBox)sender);
            }
        }

        private void AddIntoControls(object sender, EventArgs e)
        {

            this.Controls.Add((PictureBox)sender);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private void ChangePlayerImages()
        {
            count2++;
            if(count2==3)
            {
                pbPlayer.Image = Game1.Properties.Resources.FlappyDown;
            }
            if(count2==6)
            {
                pbPlayer.Image = Game1.Properties.Resources.FlappyBirdMid;
            }
            if(count2==9)
            {
                pbPlayer.Image = Game1.Properties.Resources.FlappyBirdUp;
                count2 = 0;
            }
        }
        private void ChangePicsEnemyYellow()
        {
            count++;
            if (count == 5)
            { EnemyZigZagYellow.Image = Game1.Properties.Resources.wing__1_; }
            if (count == 10)
            { EnemyZigZagYellow.Image = Game1.Properties.Resources.wingMan1__1_; }
            if (count == 15)
            { EnemyZigZagYellow.Image = Game1.Properties.Resources.wingMan2__1_; }
            if (count == 20)
            { EnemyZigZagYellow.Image = Game1.Properties.Resources.wingMan4__1_; }
            if (count == 25)
            { EnemyZigZagYellow.Image = Game1.Properties.Resources.wingMan5__1_; count = 0; }
        }
        private void ChangePicsEnemyHorizontal()
        {
            count1++;
            if (count1 == 5)
            {
                EnemyLeftRight.Image = Game1.Properties.Resources.flyMan_fly1;
            }
            if (count1 == 10)
            {
                EnemyLeftRight.Image = Game1.Properties.Resources.flyMan_jump2;
            }
            if (count1 == 15)
            {
                EnemyLeftRight.Image = Game1.Properties.Resources.flyMan_still_fly;
            }
            if (count1 == 20)
            {
                EnemyLeftRight.Image = Game1.Properties.Resources.flyMan_still_stand;
                count1 = 0;
            }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            g.Update();
            ChangePlayerImages();
            ChangePicsEnemyYellow();
            ChangePicsEnemyHorizontal();

            lblScore.Text = "Score: " + Score + "/40 ";
            LivesRemainimg.Text = "Lives: " + TotalLives;
            pbPlayer.BringToFront();
            //DetectCollisionWithBoundary();
            MetaphorFire++;
            if(MetaphorFire>60)
            {
                int Left = rand.Next(0, this.Width);
                g.AddGameObject(Game1.Properties.Resources.PipeFire, ObjectTypes.EnemyFires, 0, Left, new Vertical(FireSpeed, Boundary, "Down"));
                MetaphorFire = 0;
            }



            pbCactus.Left -= PipeSpeed;
            pbMushRoom.Left -= PipeSpeed;
            pbCloud.Left -= PipeSpeed;
            RepeatPipes();
            if (Score > 6)
            {
                PipeSpeed = 10;
            }
            WinGame();
            EndGame();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblTime1.Text = "Time Left: " + time-- + " sec";
        }
        private void WinGame()
        {
            if (Score > 40)
            {
                GameTimer.Enabled = false;
                Timer.Enabled = false;
                lblScore.Text += "Game Won";
                Image img = Game1.Properties.Resources.download__2_;
                EndGameForm moreForm = new EndGameForm(img);
                DialogResult Result = moreForm.ShowDialog();
                if (Result == DialogResult.Yes)
                {
                    //this.Close();
                    Level2 g = new Level2();
                    g.Show();

                    //this.Controls.Remove(pbPlayer);
                    //this.Controls.Remove(EnemyLeftRight);
                    //this.Controls.Remove(EnemyUpandDown);
                    //this.Controls.Remove(EnemyUpandDown2);
                    //this.Controls.Remove(pbPlayerHealth);
                    //this.Controls.Remove(EnemyUpandDownHealth);
                    //this.Controls.Remove(EnemyUpandDown2Health);
                    //this.Controls.Remove(EnemyLeftRightHealth);
                    ////EnemyFiresList.Clear();
                    ////Enemy2FiresList.Clear();
                    ////Enemy3FireListLeftRight.Clear();
                    //RestartAgain();

                }
                if (Result == DialogResult.No)
                {
                    this.Hide();
                    Form1 f = new Form1();
                    f.Show();
                }
            }
        }
        public void EndGame()
        {
            if (TotalLives <= 0 || time <= 0)
            {
                GameTimer.Stop();
                Timer.Stop();
                lblScore.Text += "  Game Over";
                Image img = Game1.Properties.Resources.download__1_;
                EndGameForm moreForm = new EndGameForm(img);
                DialogResult Result = moreForm.ShowDialog();
                if (Result == DialogResult.Yes)
                {
                    this.Hide();
                    Level2 g = new Level2();
                    g.Show();

                    //this.Controls.Remove(pbPlayer);
                    //this.Controls.Remove(EnemyLeftRight);
                    //this.Controls.Remove(EnemyUpandDown);
                    //this.Controls.Remove(EnemyUpandDown2);
                    //this.Controls.Remove(pbPlayerHealth);
                    //this.Controls.Remove(EnemyUpandDownHealth);
                    //this.Controls.Remove(EnemyUpandDown2Health);
                    //this.Controls.Remove(EnemyLeftRightHealth);
                    //this.Controls.Clear();
                    //EnemyFiresList.Clear();
                    //Enemy2FiresList.Clear();
                    //Enemy3FireListLeftRight.Clear();
                    RestartAgain();
                }
                if (Result == DialogResult.No)
                {
                    this.Hide();
                    Form1 f = new Form1();
                    f.Show();
                }
            }
        }
        public void RestartGame()
        {
            Point player = new Point();
            player.X = 20;
            player.Y = 20;
            pbPlayer.Location = player;
            EnemyLeftRight.Location = EnemyLeftRightPoint;
            EnemyZigZagBlue.Location = EnemyZigZagBluePoint;
            EnemyZigZagYellow.Location = EnemyZigZagYellowPoint;
            Enemy4.Location = Enemy4Point;
            Enemy5.Location = Enemy5Point;
            Pipe1.X = 391; Pipe1.Y = 278;
            PipeBottom1.Location = Pipe1;
            Pipe2.X = 419; Pipe2.Y = 0;
            PipeTop1.Location = Pipe2;
            Pipe3.X = 622; Pipe3.Y = 226;
            PipeBottom2.Location = Pipe3;
            Pipe4.X = 674; Pipe4.Y = 0;
            PipeTop2.Location = Pipe4;


            //Pipe1.X = 391; Pipe1.Y = 278;
            //this.Controls.Clear();
            //RestartAgain();
            //GameTimer.Enabled = true;
            //Refresh();
            //Image img = Game1.Properties.Resources.bird;
            //pbPlayerHealth.Value = 100;
            //Score = 0;
            //pbPlayer.Left = this.Width / 10;
            //pbPlayer.Top = this.Width / 2 - (img.Height + 200);

            //if (EnemyUpandDownHealth.Value > 0 && EnemyUpandDown.Visible==true)
            //{
            //    EnemyUpandDown.Location = EnemyUpandDownPoint;

            //}
            //if (EnemyUpandDown2Health.Value > 0 && EnemyUpandDown2.Visible==true)
            //{
            //    EnemyUpandDown2.Location = EnemyUpandDownPoint2;
            //}
            //if(EnemyLeftRightHealth.Value>0 && EnemyLeftRight.Visible==true)
            //{
            //    EnemyLeftRight.Location = EnemyLeftRightPoint;
            //}
            //time = 60;
        }
        public void RepeatPipes()
        {

            if (pbCactus.Left <= -50)
            {
                pbCactus.Left = 825;
            }
            if (pbMushRoom.Left <= -50)
            {
                pbMushRoom.Left = 825;
            }
            if (pbCloud.Left <= -50)
            {
                pbCloud.Left = 825;
            }
        }
        private void GameKeyisDown(object sender, KeyEventArgs e)
        {
           
        }
        private void Level2_KeyDown(object sender, KeyEventArgs e)
        {
            g.KeyPressed(e.KeyCode);
            g.KeyPressedForFiring(e.KeyCode);
        }
    }
}
