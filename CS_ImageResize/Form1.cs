using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CS_ImageResize
{
    public partial class Form1 : Form
    {
        public static bool ImageResize(String strImageSrcPath, String strImageDesPath, int intWidth=0, int intHeight=0)
        {
            bool blnAns = true;
            Image objImage = Image.FromFile(strImageSrcPath);
            if (intWidth > objImage.Width)
            {
                intWidth = objImage.Width;
            }
            if (intHeight > objImage.Height)
            {
                intHeight = objImage.Height;
            }
            if ((intWidth == 0) && (intHeight == 0))
            {
                intWidth = objImage.Width;
                intHeight = objImage.Height;
            }
            else if ((intHeight == 0) && (intWidth != 0))
            {
                intHeight = (int)(objImage.Height * intWidth / objImage.Width);
            }
            else if ((intWidth == 0) && (intHeight != 0))
            {
                intWidth = (int)(objImage.Width * intHeight / objImage.Height);
            }
            Bitmap imgOutput = new Bitmap(objImage, intWidth, intHeight);
            imgOutput.Save(strImageDesPath, objImage.RawFormat);
            objImage.Dispose();
            objImage = null;
            imgOutput.Dispose();
            imgOutput = null;
            return blnAns;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImageResize("C:\\Users\\usernb\\Documents\\ChangeDesktop\\02_(RGB)Denim.jpg", "C:\\Users\\usernb\\Desktop\\02.jpg", 1024,0);
        }
    }
}
