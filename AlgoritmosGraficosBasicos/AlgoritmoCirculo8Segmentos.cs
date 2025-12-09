using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    /// <summary>
    /// Algoritmo de 8 Segmentos (Bresenham) para dibujar círculos
    /// Utiliza la simetría de 8 octantes del círculo
    /// </summary>
    internal class AlgoritmoCirculo8Segmentos : TablaPuntos
    {
        public void DibujarCirculo(PictureBox picCanvas, int xc, int yc, int radio, Pen pen)
        {
            if (radio <= 0) return;

            int x = 0;
            int y = radio;
            int d = 3 - 2 * radio;

            // Dibujar los 8 puntos iniciales
            DibujarPuntos8Segmentos(picCanvas, xc, yc, x, y, pen);

            while (y >= x)
            {
                x++;

                // Verificar y actualizar el parámetro de decisión
                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }

                // Dibujar los 8 puntos simétricos
                DibujarPuntos8Segmentos(picCanvas, xc, yc, x, y, pen);
            }
        }

        private void DibujarPuntos8Segmentos(PictureBox picCanvas, int xc, int yc, int x, int y, Pen pen)
        {
            // Los 8 octantes del círculo
            GraficarPixel(picCanvas, xc + x, yc + y, pen);  // Octante 1
            GraficarPixel(picCanvas, xc - x, yc + y, pen);  // Octante 4
            GraficarPixel(picCanvas, xc + x, yc - y, pen);  // Octante 8
            GraficarPixel(picCanvas, xc - x, yc - y, pen);  // Octante 5
            GraficarPixel(picCanvas, xc + y, yc + x, pen);  // Octante 2
            GraficarPixel(picCanvas, xc - y, yc + x, pen);  // Octante 3
            GraficarPixel(picCanvas, xc + y, yc - x, pen);  // Octante 7
            GraficarPixel(picCanvas, xc - y, yc - x, pen);  // Octante 6
        }

        public List<(int x, int y)> ObtenerPuntosCirculo(int xc, int yc, int radio)
        {
            List<(int x, int y)> puntos = new List<(int x, int y)>();
            
            if (radio <= 0) return puntos;

            int x = 0;
            int y = radio;
            int d = 3 - 2 * radio;

            AgregarPuntos8Segmentos(puntos, xc, yc, x, y);

            while (y >= x)
            {
                x++;

                if (d > 0)
                {
                    y--;
                    d = d + 4 * (x - y) + 10;
                }
                else
                {
                    d = d + 4 * x + 6;
                }

                AgregarPuntos8Segmentos(puntos, xc, yc, x, y);
            }

            return puntos;
        }

        private void AgregarPuntos8Segmentos(List<(int x, int y)> puntos, int xc, int yc, int x, int y)
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
