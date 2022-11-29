using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using WireFrame.Core;
namespace WireFrame.Firing
{
    public class HorizontalFire:IFire
    {
        private int Speed;
        private string Direction;
        private Point boundary;
        //private PictureBox Source;
        //private Image Img;
        bool Fire = false;
        public HorizontalFire(int Speed,string Direction,Point boundary/*,PictureBox Source,Image Img*/)
        {
            this.Speed = Speed;
            this.Direction = Direction;
            this.boundary = boundary;
            //this.Source = Source;
            //this.Img = Img;
        }
        public void KeyPressedByUser(Keys KeyCode)
        {
            if(KeyCode==Keys.Space)
            {
                Fire = true;
                
            }
        }
        public Point Move(Point Location)
        {
            if (Fire == true)
            {
                if (Direction == "Left")
                {
                    Location.X -= Speed;
                }
                if (Direction == "Right")
                {
                    Location.X += Speed;
                }
                Fire = false;
            }
            return Location;
        }
        //public PictureBox CreateFire()
        //{
        //    if(Fire==true)
        //    {
        //        PictureBox pbfire = new PictureBox();
        //        pbfire.Image = Img;
        //        pbfire.Width = Img.Width;
        //        pbfire.Height = Img.Height;
        //        pbfire.BackColor = Color.Transparent;
        //        Point FireLocation = new Point();
        //        FireLocation.X = Source.Left + (Source.Width / 2) - 5;
        //        FireLocation.Y = Source.Top;
        //        pbfire.Location = FireLocation;
        //        return pbfire;
        //    }
        //    return null;
        //}
        //public void CreateFire(PictureBox pb,string Direction)
        //{

        //}
        //public Point RunFire2(Point SourceLocation,PictureBox pbFire)
        //{
        //    Point FireLocation = new Point();
        //    FireLocation.X = SourceLocation.Y + (SourceLocation.X / 2) - 5;
        //    FireLocation.Y = SourceLocation.Y;
        //    pbFire.Location = FireLocation;
        //    return FireLocation;
        //}
    }
}
