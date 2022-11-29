using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WireFrame.Movement;
using WireFrame.Enums;

namespace WireFrame.Core
{
    public class GameObject
    {
        private PictureBox pb;
        private IMovement Movement;
        private ObjectTypes OType;
        private ProgressBar Health;

        public PictureBox Pb { get => pb; set => pb = value; }
        public IMovement Movement1 { get => Movement; set => Movement = value; }
        public ObjectTypes OType1 { get => OType; set => OType = value; }
        public ProgressBar Health1 { get => Health; set => Health = value; }

        public GameObject(Image img,ObjectTypes OType, int Top, int Left, IMovement Movement)
        {
            pb = new PictureBox();
            Health1 = new ProgressBar();
            pb.Image = img;
            pb.Height = img.Height;
            pb.Width = img.Width;
            pb.BackColor = Color.Transparent;
            pb.Top = Top;
            pb.Left = Left;           
            Health.Value = 100;
            Health.Step = 10;
            Health.Height = 9;
            Health.Width = 80;
            Health1.Left = pb.Left;
            Health1.Top = pb.Top -( pb.Height + 50);
            this.OType1 = OType;
            this.Movement1 = Movement;
        }
        public GameObject(PictureBox pb,ObjectTypes Otype,IMovement Movement)
        {
            this.pb = pb;
            this.OType = Otype;
            this.Movement = Movement;
        }
        public GameObject(PictureBox pb)
        {
            this.pb = pb;
            
        }
        public void GameObjectMove()
        {
            pb.Location = Movement1.Move(pb.Location/*,pb.Image*/);
        }
    }
}
