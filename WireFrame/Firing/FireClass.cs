using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WireFrame.Enums;
using System.Drawing;
using WireFrame.Core;
using WireFrame.Movement;

namespace WireFrame.Firing
{
    public class FireClass:IMovement
    {
        //private PictureBox pbSource;
        //private PictureBox pbfire;
        //private Point FireLocation;
        //private ObjectTypes G1;
        //private IFire Fire;
        private int Speed;
        private Point Boundary;
        private string Direction;

        public FireClass(int Speed,Point Boundary,string Direction)
        {
            this.Speed = Speed;
            this.Boundary = Boundary;
            this.Direction = Direction;
        }
        //public FireClass(PictureBox pbSource,Image FireImg,ObjectTypes G1,IFire Fire)
        //{
        //    this.FireLocation1 = pbSource.Location;
        //    Pbfire = new PictureBox();
        //    Pbfire.Image = FireImg;
        //    Pbfire.Height = FireImg.Height;
        //    Pbfire.Width = FireImg.Width;
        //    Pbfire.BackColor = Color.Transparent;
        //    Pbfire.Left = pbSource.Left;
        //    Pbfire.Top = pbSource.Top +pbSource.Width/2+5;
        //    this.G11 = G1;
        //    this.Fire1 = Fire;
        //}
        //public FireClass(Image FireImg, ObjectTypes OType, int Top, int Left, IMovement movement) : base(FireImg, OType, Top, Left, movement)
        //{

        //}
        public Point Move(Point Location)
        {
            if(Direction=="Right")
            {
                Location.X += Speed;
            }
            if(Direction=="Left")
            {  
                Location.X -= Speed;
            }
            if(Direction=="Up")
            {
                Location.Y -= Speed;
            }
            if(Direction=="Down")
            {
                Location.Y += Speed;
            }
            if(Direction=="LeftDiagonal")
            {
                Location.X -= Speed;
                Location.Y += Speed;
            }
            if(Direction=="RightDiagonal")
            {
                Location.X -= Speed;
                Location.Y -= Speed;
            }
            return Location;
        }
        //public void movefire()
        //{

        //    pbfire.Location = Fire.Move(pbfire.Location);
        //}
        //public PictureBox Pb { get => pb; set => pb = value; }
        //public ObjectTypes G11 { get => G1; set => G1 = value; }
        //public IFire Fire1 { get => Fire; set => Fire = value; }
        //public PictureBox Pbfire { get => pbfire; set => pbfire = value; }
        //public Point FireLocation1 { get => FireLocation; set => FireLocation = value; }
    }
}
