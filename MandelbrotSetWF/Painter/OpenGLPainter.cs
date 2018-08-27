using System;
using System.Drawing;
using System.Numerics;
using SFML.Graphics;
using SFML.Window;
using Color = SFML.Graphics.Color;
using Image = SFML.Graphics.Image;

namespace MandelbrotSetWF.Painter
{
    class OpenGLPainter :IPaint<Sprite>
    {
        private Vector2u sizeVector;

        public System.Drawing.Size GetOriginalCanvasSize()
        {
            return new Size((int)sizeVector.X,(int)sizeVector.Y);
        }

        public Sprite Paint(byte[,,] data)
        {
            Image image=new Image((uint)data.GetLength(0), (uint)data.GetLength(1));
            sizeVector = image.Size;
            for (uint i = 0; i < data.GetLength(0); i++)
            {
                for (uint j = 0; j < data.GetLength(1); j++)
                {
                    Color color=new Color(data[i,j,0], data[i, j, 1], data[i, j, 2]);
                    image.SetPixel(i,j, color);
                }
            }
            Texture texture=new Texture(image);
            return new Sprite(texture);
        }
    }
}
