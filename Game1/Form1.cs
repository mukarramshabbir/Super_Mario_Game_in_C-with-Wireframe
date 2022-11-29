using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide() ;
            Flappy_Bird_Game Game = new Flappy_Bird_Game();
            Game.Show();
        }

        private void level1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Level2 l = new Level2();
            l.Show();
        }
    }
}
