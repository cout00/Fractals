using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSetWF.Painter
{
    public interface IPaint<T> where T:class 
    {
        T Paint(byte[,,] data);
        Size GetOriginalCanvasSize();        
    }
}
