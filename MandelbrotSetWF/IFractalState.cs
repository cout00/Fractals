using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSetWF
{
    public interface IFractalState
    {
        byte[,,] GetFractalData(RectangleF area, Size dataSize);
        Task<byte[,,]> GetFractalDataAsync(RectangleF area, Size dataSize);

    }



}
