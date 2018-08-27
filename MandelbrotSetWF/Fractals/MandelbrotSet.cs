using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSetWF.Fractals
{
    [FractalName("Mandelbrot")]
    public class MandelbrotSet :FractalBase
    {
        void step_clr(ref float red, ref float green, ref float blue)
        {
            red = (int)(red + 5) < 0xff ? red + 5 : 0xff;
            if ((int)red == 0xff)
                green = (int)(green + 3.5f) < 0xff ? green + 3.5f : 0xff;
            if ((int)green == 0xff)
                blue = (int)(blue + 2.2f) < 0xff ? blue + 2.2f : 0xff;
        }
        
        protected override void FillFractalArray(ref byte[,,] fillData, double xLeft, double xRight, double yTop, double yBottom, double stepX, double stepY)
        {
            int max_it = 120;
            int infinity_sqr = 1000;
            var xim = 0;
            var yim = 0;
            for (double currx = xLeft; currx <= xRight; currx += stepX, ++xim)
            {
                yim = 0;
                while (xim >= fillData.GetLength(0))
                    --xim;
                for (double curry = yTop; curry >= yBottom; curry -= stepY, ++yim)
                {
                    while (yim >= fillData.GetLength(1))
                        --yim;
                    float red = 0, green = 0, blue = 0;
                    Complex curr = new Complex();

                    for (int i = 0; i < max_it; ++i)
                    {
                        if (curr.Magnitude >= infinity_sqr)
                        {
                            fillData[xim, yim, 0] = (byte)red;
                            fillData[xim, yim, 1] = (byte)green;
                            fillData[xim, yim, 2] = (byte)blue;
                            break;
                        }
                        curr = curr * curr + new Complex(currx, curry);
                        step_clr(ref red, ref green, ref blue);
                    }
                }
            }            
        }
    }
}
