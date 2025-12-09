using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    /// <summary>
    /// Algoritmo del Punto Medio para dibujar círculos
    /// Más eficiente y preciso que el método de 8 segmentos
    /// </summary>
    internal class AlgoritmoCirculoPuntoMedio : TablaPuntos
    {
        public void DibujarCirculo(PictureBox picCanvas, int xc, int yc, int radio, Pen pen)
        {
            if (radio <= 0) return;

            int x = 0;
            int y = radio;
            int p = 1 - radio;

            // Dibujar los 8 puntos simétricos iniciales
            DibujarPuntosCirculo(picCanvas, xc, yc, x, y, pen);

            while (x < y)
            {
                x++;

                if (p < 0)
                {
                    // Punto medio está dentro del círculo
                    p = p + 2 * x + 1;
                }
                else
                {
                    // Punto medio está fuera del círculo
                    y--;
                    p = p + 2 * (x - y) + 1;
                }

                // Dibujar los 8 puntos simétricos
                DibujarPuntosCirculo(picCanvas, xc, yc, x, y, pen);
            }
        }

        private void DibujarPuntosCirculo(PictureBox picCanvas, int xc, int yc, int x, int y, Pen pen)
        {
            // Los 8 puntos simétricos del círculo
            GraficarPixel(picCanvas, xc + x, yc + y, pen);
            GraficarPixel(picCanvas, xc - x, yc + y, pen);
            GraficarPixel(picCanvas, xc + x, yc - y, pen);
            GraficarPixel(picCanvas, xc - x, yc - y, pen);
            GraficarPixel(picCanvas, xc + y, yc + x, pen);
            GraficarPixel(picCanvas, xc - y, yc + x, pen);
            GraficarPixel(picCanvas, xc + y, yc - x, pen);
            GraficarPixel(picCanvas, xc - y, yc - x, pen);
        }

        public List<(int x, int y)> ObtenerPuntosCirculo(int xc, int yc, int radio)
        {
            List<(int x, int y)> puntos = new List<(int x, int y)>();
            
            if (radio <= 0) return puntos;

            int x = 0;
            int y = radio;
            int p = 1 - radio;

            AgregarPuntosCirculo(puntos, xc, yc, x, y);

            while (x < y)
            {
                x++;

                if (p < 0)
                {
                    p = p + 2 * x + 1;
                }
                else
                {
                    y--;
                    p = p + 2 * (x - y) + 1;
                }

                AgregarPuntosCirculo(puntos, xc, yc, x, y);
            }

            return puntos;
        }

        private void AgregarPuntosCirculo(List<(int x, int y)> puntos, int xc, int yc, int x, int y)
        {
            puntos.Add((xc + x, yc + y));
            puntos.Add((xc - x, yc + y));
            puntos.Add((xc + x, yc - y));
            puntos.Add((xc - x, yc - y));
            puntos.Add((xc + y, yc + x));
            puntos.Add((xc - y, yc + x));
            puntos.Add((xc + y, yc - x));
            puntos.Add((xc - y, yc - x));
        }
    }
}
