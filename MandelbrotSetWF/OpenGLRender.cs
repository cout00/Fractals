using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotSetWF
{
    public class OpenGLRender :Control
    {
        public RenderWindow RenderContext { get; private set; }
        public event EventHandler<OpenGLRenderEventsArgs> OnRender;

        public virtual void InitRender()
        {
            RenderContext = new RenderWindow(this.Handle);
        }
                
        protected virtual void Render(RenderWindow context, OpenGLRenderEventsArgs lastArgs)
        {
            
        }

        public void StartRendering()
        {
            while (Parent != null && Parent.Visible)
            {
                Application.DoEvents();
                RenderContext.DispatchEvents();
                var args = new OpenGLRenderEventsArgs();
                RenderContext.Clear(Color.White);
                OnRender?.Invoke(RenderContext, args);
                Render(RenderContext, args);
                RenderContext.Display();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (RenderContext == null)
                base.OnPaint(e);

        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            if (RenderContext == null)
                base.OnPaintBackground(pevent);
        }

        public class OpenGLRenderEventsArgs :EventArgs
        {
            public Dictionary<string, Drawable> DrawHistory { get; private set; }

            public OpenGLRenderEventsArgs()
            {
                DrawHistory=new Dictionary<string, Drawable>();
            }
        }
    }
}
