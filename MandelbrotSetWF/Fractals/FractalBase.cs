using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSetWF.Fractals
{
    abstract public class FractalBase :IFractalState
    {


        abstract protected void FillFractalArray(ref byte[,,] fillData, double xLeft, double xRight, double yTop, double yBottom, double stepX, double stepY);
        
        public byte[,,] GetFractalData(RectangleF area, Size dataSize)
        {
            double imgCordLeft = area.Top - area.Height;
            double imgCordRight = area.Top;
            double realCordLeft = area.Left;
            double realCordRight = area.Left + area.Width;

            byte[,,] set = new byte[
                dataSize.Width,
                dataSize.Height,
                3];
            var stepY = area.Height / set.GetLength(0);
            var stepX = area.Width / set.GetLength(1);
            FillFractalArray(ref set, realCordLeft, realCordRight, imgCordRight, imgCordLeft, stepX, stepY);
            return set;
        }

        public async Task<byte[,,]> GetFractalDataAsync(RectangleF area, Size dataSize)
        {
            TaskFactory<byte[,,]> factory=new TaskFactory<byte[,,]>();
            return await factory.StartNew(() =>
            {
                return GetFractalData(area, dataSize);
            });
        }
    }
}
