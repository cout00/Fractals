using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace MandelbrotSetWF.OpenGL
{
    public class DischargeRenderContainer :OpenGLRender
    {        
        Vector2f _selectionStartPoint = new Vector2f();
        IntRect _selectionRect = new IntRect();
        private bool isZoom = false;
        private IntRect _intRectBackGround;

        public override void InitRender()
        {
            base.InitRender();
            RenderContext.MouseButtonPressed += RenderContext_MouseButtonPressed;
            RenderContext.MouseMoved += RenderContext_MouseMoved;
            RenderContext.MouseButtonReleased += RenderContext_MouseButtonReleased;
        }

        private void RenderContext_MouseButtonReleased(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            isZoom = false;
            _selectionRect=new IntRect();
            _selectionStartPoint=new Vector2f();
        }

        private void RenderContext_MouseMoved(object sender, SFML.Window.MouseMoveEventArgs e)
        {
            if (!isZoom)
                return;
            double scaleX = Width / (double)_intRectBackGround.Width;
            double scaleY = Height / (double)_intRectBackGround.Height;


            //var newWidth = (e.X / scaleX - _selectionStartPoint.X / scaleX) > 0 ? e.X / scaleX - _selectionStartPoint.X / scaleX : 0;
            //var newHeight = (e.Y / scaleY - _selectionStartPoint.Y / scaleY) > 0 ? e.Y / scaleY - _selectionStartPoint.Y / scaleY : 0;
            
            //_selectionRect = new IntRect((int)(_selectionStartPoint.X / scaleX), (int)(_selectionStartPoint.Y / scaleY), (int)newWidth, (int)newHeight);

            var newWidth = (e.X - _selectionStartPoint.X) > 0 ? e.X - _selectionStartPoint.X  : 0;
            var newHeight = (e.Y - _selectionStartPoint.Y) > 0 ? e.Y - _selectionStartPoint.Y  : 0;

            newWidth = newWidth >= newHeight ? newHeight : newWidth;
            newHeight = newHeight >= newWidth ? newWidth : newHeight;

            _selectionRect = new IntRect((int)(_selectionStartPoint.X), (int)(_selectionStartPoint.Y), (int)newWidth, (int)newHeight);


        }

        private void RenderContext_MouseButtonPressed(object sender, SFML.Window.MouseButtonEventArgs e)
        {
            isZoom = true;
            _selectionStartPoint = new Vector2f(e.X, e.Y);
        }

        protected override void Render(RenderWindow context, OpenGLRenderEventsArgs lastArgs)
        {
            base.Render(context, lastArgs);
            if (!isZoom)
                return;
            var drawBackGround = (lastArgs.DrawHistory["background"] as Sprite);
            _intRectBackGround = drawBackGround.TextureRect;
            
            Shape shape = new RectangleShape(new Vector2f(_selectionRect.Width, _selectionRect.Height));
            shape.Position=new Vector2f(_selectionRect.Left, _selectionRect.Top);
            shape.OutlineColor=Color.Red;
            shape.OutlineThickness = 2f;
            shape.FillColor=Color.Transparent;
            context.Draw(shape);
        }
    }

    public class SelectionRectEventArgs:EventArgs
    {
        public IntRect NotScaledRect { get; private set; }
        public IntRect ScaledRect { get; private set; }
        public FloatRect OriginalBasisRect { get; private set; }

        public SelectionRectEventArgs()
        {
             
        }

    }


}
