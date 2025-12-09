using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    internal class AlgortimoBresenham : DibujarLinea
    {
        public override void CalcularPuntos(PictureBox picCanvas, Pen pen)
        {
            int deltaX = Math.Abs(x2 - x1);
            int deltaY = Math.Abs(y2 - y1);
            int auxX = x1;
            int auxY = y1;
            float m = deltaX == 0 ? float.MaxValue : Math.Abs((float)deltaY / deltaX); // evita división por cero
            float p = 0;

            int incX = x2 >= x1 ? 1 : -1;
            int incY = y2 >= y1 ? 1 : -1;

            if (m > 1)
            {
                p = 2 * deltaX - deltaY;

                while (auxY != y2)
                {
                    GraficarPixel(picCanvas, auxX, auxY, pen);
                    EscribirCoordenadas(auxX, auxY);

                    if (p < 0)
                    {
                        auxY += incY;
                        p += 2 * deltaX;
                    }
                    else
                    {
                        auxX += incX;
                        auxY += incY;
                        p += 2 * (deltaX - deltaY);
                    }

                    Task.Delay(1).Wait();
                }
            }
            else
            {
                p = 2 * deltaY - deltaX;

                while (auxX != x2)
                {
                    GraficarPixel(picCanvas, auxX, auxY, pen);
                    EscribirCoordenadas(auxX, auxY);

                    if (p < 0)
                    {
                        auxX += incX;
                        p += 2 * deltaY;
                    }
                    else
                    {
                        auxX += incX;
                        auxY += incY;
                        p += 2 * (deltaY - deltaX);
                    }

                    Task.Delay(1).Wait();
                }
            }

            GraficarPixel(picCanvas, x2, y2, pen);
            EscribirCoordenadas(x2, y2);
        }


    }
}
