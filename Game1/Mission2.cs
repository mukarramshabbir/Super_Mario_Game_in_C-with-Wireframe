using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace Game1
{
    public partial class Mission2Form : Form
    {
        bool GameRunning = true;
        PictureBox pbPlayer;
        ProgressBar pbPlayerHealth;
        bool PlayerRightDirection = false,PlayerLeftDirection=false;
        
        public Mission2Form()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
        private void CreatePlayer()
        {
            pbPlayer = new PictureBox();
            Image img= Game1.Properties.Resources.pbplayer2;
            pbPlayer.Image = img;
            pbPlayer.Width = img.Width;
            pbPlayer.Height = img.Height;
            pbPlayer.BackColor = Color.Transparent;
            pbPlayer.Left = this.Width / 10;
            pbPlayer.Top = this.Height - (img.Height + 77);
            pbPlayerHealth = new ProgressBar();
            pbPlayerHealth.Value = 100;
            pbPlayerHealth.Step = 10;
            pbPlayerHealth.Height = 10;

            this.Controls.Add(pbPlayerHealth);
            this.Controls.Add(pbPlayer);
        }

        private void Mission2Form_Load(object sender, EventArgs e)
        {
            CreatePlayer();
        }

        private void Gametimer_Tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if (pbPlayer.Left < this.Width && GameRunning==true)
                {
                    pbPlayer.Left = pbPlayer.Left + 10;
                }
                else
                {
                    GameRunning = false;
                    MessageBox.Show("Game Over");
                }
            }
            pbPlayerHealth.Left = pbPlayer.Left;
            pbPlayerHealth.Top = pbPlayer.Height + pbPlayer.Top;
        }
    }
}
