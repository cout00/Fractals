using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MandelbrotSetWF.Fractals;
using MandelbrotSetWF.Painter;
using SFML.Graphics;
using SFML.Window;

namespace MandelbrotSetWF
{
    public partial class Form1 :Form
    {

        public Bitmap OriginalImage { get; set; }
        public Rectangle OriginalRectangle { get; set; }

        Fractal<MandelbrotSet, Sprite> fractal;
        Fractallnfo<MandelbrotSet, Sprite> fractallnfo;

        public Form1(){
            InitializeComponent();
            fractal = new Fractal<MandelbrotSet, Sprite>(new OpenGLPainter(), openGLRender1.Size);

            fractallnfo = new Fractallnfo<MandelbrotSet, Sprite>(new OpenGLPainter(), openGLRender1.Size);
            fractallnfo.ComplexRectange = new RectangleF(-0.7714677975501545f, 1.3759945057056568f, 0.7791495198902606f, 0.7791495198902606f);
            //fractallnfo.ComplexRectange = new RectangleF(-2,2, 4,4);
            fractallnfo.Draw(0, 0);
        }

        private void RenderContext_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            xCord.Text ="X:"+e.X.ToString();
            yCord.Text = "Y:" + e.Y.ToString();
        }


        Point _point = new Point();
        private bool isZoom = false;

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            isZoom = true;
            _point = new Point(e.X, e.Y);
        }

        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (!isZoom)
            //    return;
            ////PictureEdit pictureEdit = sender as PictureEdit;
            //Bitmap bitClone = new Bitmap(OriginalImage);
            //double scaleX = pictureEdit.Width / (double)OriginalImage.Width;
            //double scaleY = pictureEdit.Height / (double)OriginalImage.Height;

            //using (Graphics g = Graphics.FromImage(bitClone))
            //{
            //    var newWidth = (e.X / scaleX - _point.X / scaleX) > 0 ? e.X / scaleX - _point.X / scaleX : 0;
            //    var newHeight = (e.Y / scaleY - _point.Y / scaleY) > 0 ? e.Y / scaleY - _point.Y / scaleY : 0;
            //    OriginalRectangle = new Rectangle((int)(_point.X / scaleX), (int)(_point.Y / scaleY), (int)newWidth, (int)newHeight);
            //    g.DrawRectangle(Pens.Blue, OriginalRectangle);
            //}
            //pictureEdit.Image = bitClone;
        }
        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            //PictureEdit pictureEdit = sender as PictureEdit;
            //isZoom = false;
            //var resultAddState = fractal.AddState((LinkedListNode<Fractallnfo<MandelbrotSet, Bitmap>>)pictureEdit.Tag, OriginalRectangle);
            //OriginalImage = resultAddState.Value.GetFrame();
            //pictureEdit.Tag = resultAddState;
            //pictureEdit.Image=new Bitmap(OriginalImage);
        }

               
        private void Form1_Shown(object sender, EventArgs e)
        {
            openGLRender1.InitRender();
            openGLRender1.RenderContext.MouseMoved += RenderContext_MouseMoved;
            openGLRender1.StartRendering();
        }

        private void openGLRender1_OnRender(object sender, OpenGLRender.OpenGLRenderEventsArgs e)
        {
            var window = (sender as RenderWindow);
            var sprite = fractallnfo.GetFrame();
                        
            e.DrawHistory.Add("background", sprite);
            sprite.Scale=new Vector2f(openGLRender1.Width/(float)sprite.Texture.Size.X, openGLRender1.Height/ (float)sprite.Texture.Size.Y);
            window.Draw(fractallnfo.GetFrame());
        }
    }

}
