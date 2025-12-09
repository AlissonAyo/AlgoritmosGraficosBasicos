using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    internal class AlgoritmoScanline : TablaPuntos
    {
        public void RellenarScanline(PictureBox picCanvas, List<(int x, int y)> vertices)
        {
            if (vertices == null || vertices.Count < 3)
            {
                MessageBox.Show("Se requiere al menos un polígono con 3 vértices.");
                return;
            }

            // Convertir a puntos
            List<Point> puntos = vertices.Select(v => new Point(v.x, v.y)).ToList();

            int ymin = puntos.Min(p => p.Y);
            int ymax = puntos.Max(p => p.Y);

            for (int y = ymin; y <= ymax; y++)
            {
                List<int> interseccionesX = new List<int>();

                for (int i = 0; i < puntos.Count; i++)
                {
                    Point p1 = puntos[i];
                    Point p2 = puntos[(i + 1) % puntos.Count];

                    if ((p1.Y < y && p2.Y >= y) || (p2.Y < y && p1.Y >= y))
                    {
                        int x = p1.X + (y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y);
                        interseccionesX.Add(x);
                    }
                }

                interseccionesX.Sort();

                for (int i = 0; i < interseccionesX.Count - 1; i += 2)
                {
                    int xInicio = interseccionesX[i];
                    int xFin = interseccionesX[i + 1];

                    for (int x = xInicio; x <= xFin; x++)
                    {
                        GraficarPixelR(picCanvas, x, y);
                        EscribirCoordenadas(x, y);
                    }
                }
            }
        }
    }
}
