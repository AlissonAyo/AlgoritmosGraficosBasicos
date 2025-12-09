using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ayo_Alisson_Algoritmos
{
    internal class AlgoritmoLiangBarsky : TablaPuntos
    {
        public Point[] RecortarLinea(int x1, int y1, int x2, int y2, int xmin, int ymin, int xmax, int ymax)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            
            float[] p = new float[4];
            float[] q = new float[4];
            
            // Definir los valores p y q para cada borde
            p[0] = -dx;  // Izquierda
            p[1] = dx;   // Derecha
            p[2] = -dy;  // Abajo
            p[3] = dy;   // Arriba
            
            q[0] = x1 - xmin;
            q[1] = xmax - x1;
            q[2] = y1 - ymin;
            q[3] = ymax - y1;
            
            float u1 = 0.0f;
            float u2 = 1.0f;
            
            for (int i = 0; i < 4; i++)
            {
                if (p[i] == 0)
                {
                    // Línea paralela al borde
                    if (q[i] < 0)
                    {
                        // Línea está fuera del borde
                        return null;
                    }
                }
                else
                {
                    float r = q[i] / p[i];
                    
                    if (p[i] < 0)
                    {
                        // Entrando al área de recorte
                        u1 = Math.Max(u1, r);
                    }
                    else
                    {
                        // Saliendo del área de recorte
                        u2 = Math.Min(u2, r);
                    }
                }
            }
            
            if (u1 > u2)
            {
                // Línea está completamente fuera
                return null;
            }
            
            // Calcular los puntos recortados
            int x1_clip = (int)(x1 + u1 * dx);
            int y1_clip = (int)(y1 + u1 * dy);
            int x2_clip = (int)(x1 + u2 * dx);
            int y2_clip = (int)(y1 + u2 * dy);
            
            return new Point[] 
            { 
                new Point(x1_clip, y1_clip), 
                new Point(x2_clip, y2_clip) 
            };
        }
    }
}
