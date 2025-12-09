using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    /// <summary>
    /// Algoritmo Polar para dibujar círculos
    /// Utiliza coordenadas polares para generar los puntos del círculo
    /// </summary>
    internal class AlgoritmoCirculoPolar : TablaPuntos
    {
        public void DibujarCirculo(PictureBox picCanvas, int xc, int yc, int radio, Pen pen)
        {
            if (radio <= 0) return;

            // Calcular el incremento del ángulo basado en el radio
            // Más puntos para círculos más grandes
            double incrementoAngulo = 1.0 / radio;
            
            // Dibujar el círculo completo usando coordenadas polares
            for (double theta = 0; theta <= 2 * Math.PI; theta += incrementoAngulo)
            {
                int x = (int)(xc + radio * Math.Cos(theta));
                int y = (int)(yc + radio * Math.Sin(theta));
                
                GraficarPixel(picCanvas, x, y, pen);
            }
        }

        public void DibujarCirculoOptimizado(PictureBox picCanvas, int xc, int yc, int radio, Pen pen)
        {
            if (radio <= 0) return;

            // Solo calculamos 1/8 del círculo y usamos simetría
            double incrementoAngulo = Math.PI / (4 * radio);
            
            for (double theta = 0; theta <= Math.PI / 4; theta += incrementoAngulo)
            {
                int x = (int)(radio * Math.Cos(theta));
                int y = (int)(radio * Math.Sin(theta));
                
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

            double incrementoAngulo = 1.0 / radio;
            
            for (double theta = 0; theta <= 2 * Math.PI; theta += incrementoAngulo)
            {
                int x = (int)(xc + radio * Math.Cos(theta));
                int y = (int)(yc + radio * Math.Sin(theta));
                
                puntos.Add((x, y));
            }

            return puntos;
        }
    }
}
