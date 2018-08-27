using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandelbrotSetWF.Painter;
using Image = SFML.Graphics.Image;

namespace MandelbrotSetWF.Fractals
{
    public class Fractallnfo<TFractal, TPainter> where TFractal : IFractalState, new() where TPainter : class
    {
        private readonly Size _canvasSize;
        private readonly IPaint<TPainter> _painter;
        private readonly Fractallnfo<TFractal, TPainter> _baseInfo;
        public double ScaleByAxisX { get; private set; }
        public double ScaleByAxisY { get; private set; }

        public double ScaleCanvasByAxisX { get; private set; }
        public double ScaleCanvasByAxisY { get; private set; }


        public Rectangle PixelRectangle { get; set; }
        public RectangleF ComplexRectange { get; set; }
        TFractal _fractal = new TFractal();
        TPainter state;
        public Fractallnfo(IPaint<TPainter> painter, Size canvasSize)
        {
            _painter = painter;
            _canvasSize = canvasSize;
            //Image
        }

        public TPainter Draw(float stepByX, float stepByY)
        {
            ScaleByAxisX = stepByX;
            ScaleByAxisY = stepByY;
            state = _painter.Paint(_fractal.GetFractalData(ComplexRectange, new Size(300,300)));
            _fractal.GetFractalDataAsync(ComplexRectange, new Size(700, 700))
                .ContinueWith(task =>{
                    state = _painter.Paint(task.Result);
                });
            _fractal.GetFractalDataAsync(ComplexRectange, new Size(1400, 1400))
                .ContinueWith(task => {
                    state = _painter.Paint(task.Result);
                });
            PixelRectangle = new Rectangle(new Point(), _painter.GetOriginalCanvasSize());
            return state;
        }

        public TPainter GetFrame()
        {
            return state;
        }


        public Fractallnfo(IPaint<TPainter> painter, Size canvasSize, Fractallnfo<TFractal, TPainter> baseInfo) : this(painter, canvasSize)
        {
            _baseInfo = baseInfo;
            //ScaleByAxisY = canvasSize.Height / (double)painter.GetOriginalCanvasSize().Height;
            //ScaleByAxisX = canvasSize.Width / (double)painter.GetOriginalCanvasSize().Width;
        }

        void CalculateSizes()
        {

        }

    }
}
