C# An Easy Way to Resize an Image

reference : https://www.codeproject.com/Articles/36990/An-Easy-Way-to-Resize-an-Image

Introduction  
This is the most common part to add an image / signature in any web/Windows applications. This article will show you how to resize an image keeping with the best graphics quality.

Background
Most of the time, developers face various problems when they resize an image runtime. In this article, I try to resize an image runtime with keeping the best graphics quality.

code:

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