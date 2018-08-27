using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandelbrotSetWF.Fractals;
using MandelbrotSetWF.Painter;

namespace MandelbrotSetWF
{
    public class Fractal<TFractal, TDraw> :LinkedList<Fractallnfo<TFractal, TDraw>>
        where TFractal : IFractalState, new()
        where TDraw : class
    {
        private readonly IPaint<TDraw> _painter;
        private readonly Size _canvasSize;



        public TDraw Canvas { get; private set; }


        public LinkedListNode<Fractallnfo<TFractal, TDraw>> AddState(LinkedListNode<Fractallnfo<TFractal, TDraw>> node, Rectangle area)
        {
            var complexRectange = node.Value.ComplexRectange;
            var pixelRectange = node.Value.PixelRectangle;
            var newBasisWeightByX = complexRectange.Width / pixelRectange.Width;
            var newBasisWeightByY = complexRectange.Height/ pixelRectange.Height;

            RectangleF newBasis = new RectangleF(
                complexRectange.Left+area.Left*newBasisWeightByX,
                complexRectange.Top - area.Top * newBasisWeightByY, 
                newBasisWeightByX*area.Width, 
                newBasisWeightByY*area.Height);
            var newScaleX = (float)node.Value.ScaleByAxisX / ((float)pixelRectange.Width / area.Width);
            var newScaleY = (float)node.Value.ScaleByAxisY / ((float)pixelRectange.Height / area.Height);

            Fractallnfo<TFractal, TDraw> fractallnfo=new Fractallnfo<TFractal, TDraw>(_painter, _canvasSize);
            fractallnfo.ComplexRectange = newBasis;
            fractallnfo.Draw(newScaleX, newScaleY);
            return AddAfter(node, fractallnfo);
        }



        public Fractal(IPaint<TDraw> painter, Size canvasSize)
        {
            _painter = painter;
            _canvasSize = canvasSize;

        }
    }
}
