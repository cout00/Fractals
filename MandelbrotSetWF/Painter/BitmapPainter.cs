using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSetWF.Painter
{
    public class BitmapPainter :IPaint<Bitmap>
    {
        private Bitmap internalBitmap;
       
        public Size GetOriginalCanvasSize()
        {
            if (internalBitmap!=null)
            {
                return internalBitmap.Size;
            }
            throw new ArgumentNullException();
        }

        public unsafe Bitmap Paint(byte[,,] data)
        {
            int width = data.GetLength(1);
            int height = data.GetLength(0);

            Bitmap Image = new Bitmap(width, height);
            BitmapData bitmapData = Image.LockBits(
                new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format32bppArgb
            );
            ColorARGB* startingPosition = (ColorARGB*)bitmapData.Scan0;

            for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
            {
                ColorARGB* position = startingPosition + j + i * width;
                position->A = 255;
                position->R = data[i, j, 0];
                position->G = data[i, j, 1];
                position->B = data[i, j, 2];
            }

            Image.UnlockBits(bitmapData);
            internalBitmap = Image;
            return Image;
        }
        public struct ColorARGB
        {
            public byte B;
            public byte G;
            public byte R;
            public byte A;

            public ColorARGB(Color color)
            {
                A = color.A;
                R = color.R;
                G = color.G;
                B = color.B;
            }

            public ColorARGB(byte a, byte r, byte g, byte b)
            {
                A = a;
                R = r;
                G = g;
                B = b;
            }

            public Color ToColor()
            {
                return Color.FromArgb(A, R, G, B);
            }
        }
    }
}
