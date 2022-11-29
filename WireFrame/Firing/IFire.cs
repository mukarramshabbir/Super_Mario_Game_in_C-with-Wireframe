using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WireFrame.Enums;
using System.Drawing;

namespace WireFrame.Firing
{
    public interface IFire
    {
        //void CreateFire(PictureBox pb, string Direction);
        Point Move(Point Location);
    }
}
