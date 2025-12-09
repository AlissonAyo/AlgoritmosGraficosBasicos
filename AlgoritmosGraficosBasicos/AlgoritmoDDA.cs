using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    internal class AlgoritmoDDA : DibujarLinea
    {
        public override void CalcularPuntos(PictureBox picCanvas, Pen pen)
        {
            int deltaX = x2 - x1;
            int deltaY = y2 - y1;
            int pasos = Math.Max(Math.Abs(deltaX), Math.Abs(deltaY));
            if (pasos == 0)
            {
                GraficarPixel(picCanvas, x1, y1,pen);
                EscribirCoordenadas(x1, y1);

                return;
            }
            
            float incX = deltaX / (float)pasos;
            float incY = deltaY / (float)pasos;
            float auxX = x1;
            float auxY = y1;

            for (int i = 0; i <= pasos; i++)
            {
                GraficarPixel(picCanvas, (int)Math.Round(auxX), (int)Math.Round(auxY),pen);
                Task.Delay(1).Wait(); // Espera 1 segundo antes de graficar
                EscribirCoordenadas((int)Math.Round(auxX), (int)Math.Round(auxY));
                auxX += incX;
                auxY += incY;
        
            }
        }
    }
}
